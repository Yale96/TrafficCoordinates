using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimulationSystem.ResponseModels
{
    public class GeocodedWaypoint
    {
        public string geocoder_status { get; set; }
        public string place_id { get; set; }
        public IList<string> types { get; set; }
    }
}