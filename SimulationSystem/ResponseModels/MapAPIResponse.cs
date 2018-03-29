using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimulationSystem.ResponseModels
{
    public class MapAPIResponse
    {
        public IList<GeocodedWaypoint> geocoded_waypoints { get; set; }
        public IList<ResponseRoute> routes { get; set; }
        public string status { get; set; }
    }
}