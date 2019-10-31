using XF.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace XF.CQRS.Abstractions
{
    public static class Extensions
    {
        public static ICommandResponse<T> Post<T>(this ICommandService<T> service, T model) where T : class, new()
        {
            ICommandContext<T> context = new CommandContext<T>().Post(model);
            return service.Post(context).Response;
        }
        public static ICommandResponse<T> Put<T>(this ICommandService<T> service, T model) where T : class, new()
        {
            ICommandContext<T> context = new CommandContext<T>().Put(model);
            return service.Put(context).Response;
        }
        public static ICommandResponse<T> Delete<T>(this ICommandService<T> service, string id) where T : class, new()
        {
            ICommandContext<T> context = new CommandContext<T>().Delete(id);
            return service.Delete(context).Response;
        }

        public static IQueryContext<T> Execute<T>(this IQueryService<T> service, IQueryRequest request, int paginationOffset = 2) where T : class, new()
        {
            IQueryContext<T> context = new QueryContext<T>()
            {
                Request = request,
                Response = new QueryResponse<T>() { Page = new Page<T>() { Index = request.PageIndex, Size = request.PageSize } }
            };
            IQueryContext<T> ctx = service.Execute(context).Paginate(paginationOffset);
            return ctx;
        }
        public static IQueryContext<T> Paginate<T>(this IQueryContext<T> context, int maxOffset = 2) where T : class, new()
        {
            Page<T> page = context.Response.Page;

            int pagecount = (page.Total % page.Size) == 0 ? page.Total / page.Size : (page.Total / page.Size) + 1;
            int paginationmax = (int)(Math.Pow(2, maxOffset) + 1);
            int maxslot = pagecount > paginationmax ? paginationmax : pagecount;

            List<PageIndex> list = new List<PageIndex>();
            for (int i = 0; i <= maxOffset + 1; i++)
            {
                if (i == 0)
                {
                    list.Add(new PageIndex()
                    {
                        Index = page.Index,
                        Display = (page.Index + 1).ToString(),
                        Command = "none"
                    });
                }
                else if (list.Count < maxslot)
                {
                    if (page.Index - i >= 0)
                    {
                        list.Insert(0, new PageIndex() { Index = page.Index - i, Display = (page.Index - i + 1).ToString(), Command = "offset" });
                    }
                    if (page.Index + i < pagecount)
                    {
                        list.Add(new PageIndex() { Index = page.Index + i, Display = (page.Index + i - 1).ToString(), Command = "offset" });
                    }
                }

            }
            int missingcount = maxslot - list.Count;
            if (missingcount > 0)
            {
                for (int i = 0; i < missingcount; i++)
                {
                    if (list[0].Index > 0)
                    {
                        int j = list[0].Index - 1;
                        list.Insert(0, new PageIndex()
                        {
                            Index = j,
                            Display = j.ToString(),
                            Command = "offset"
                        });
                    }
                    else
                    {
                        int j = list[list.Count - 1].Index + 1;
                        list.Add(new PageIndex()
                        {
                            Index = j,
                            Display = j.ToString(),
                            Command = "offset"
                        });
                    }
                }
            }
            int firstSlotIndex = list[0].Index;
            int lastSlotIndex = list[list.Count - 1].Index;

            list.Insert(0, new PageIndex()
            {
                Index = page.Index - 1,
                Display = "{",
                Command = (page.Index > 0) ? "previous" : "none"
            });

            list.Add(new PageIndex()
            {
                Index = page.Index + 1,
                Display = "}",
                Command = (page.Index < lastSlotIndex) ? "next" : "none"
            });


            list.Insert(0, new PageIndex()
            {
                Index = 0,
                Display = "[[",
                Command = (firstSlotIndex > 0) ? "first" : "none"
            });

            list.Add(new PageIndex()
            {
                Index = pagecount - 1,
                Display = "]]",
                Command = (lastSlotIndex < pagecount - 1) ? "last" : "none"
            });

            page.Pagination = list;

            return context;
        }
    }
}
