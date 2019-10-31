﻿using XF.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace XF.Rest.Abstractions
{
    public interface IRequest<T> where T : class, new()
    {
        string Verb { get; set; }

        T Model { get; set; }

        IEnumerable<T> Content { get; set; }

        IParameters Parameters { get; }

        IProjections Projections { get; set; }

        DataSet Data { get; set; }
    }
}
