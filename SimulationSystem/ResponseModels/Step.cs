using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimulationSystem.ResponseModels
{
    public class Step
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public EndLocation end_location { get; set; }
        public string html_instructions { get; set; }
        public Polyline polyline { get; set; }
        public StartLocation start_location { get; set; }
        public string travel_mode { get; set; }
        public string maneuver { get; set; }
    }
}