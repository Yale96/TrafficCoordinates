using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimulationSystem.ResponseModels
{
    public class ResponseRoute
    {
        public Bounds bounds { get; set; }
        public string copyrights { get; set; }
        public IList<Leg> legs { get; set; }
        public OverviewPolyline overview_polyline { get; set; }
        public string summary { get; set; }
        public IList<object> warnings { get; set; }
        public IList<object> waypoint_order { get; set; }
    }
}