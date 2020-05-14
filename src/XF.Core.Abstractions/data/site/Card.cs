using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Core.Data
{
    public class Card
    {
        public string Id { get; set; } // Edge.Identifier.Id
        /// <summary>
        /// Essentially the url of the waypoint/page/vertex
        /// </summary>
        public string WaypointPath { get; set; }
        public List<Promo> Promos { get; set; } // from the 'To' Waypoint by default, or can be overridden

    }
}
