﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimulationSystem.ResponseModels
{
    public class Leg
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public string end_address { get; set; }
        public EndLocation end_location { get; set; }
        public string start_address { get; set; }
        public StartLocation start_location { get; set; }
        public IList<Step> steps { get; set; }
        public IList<object> traffic_speed_entry { get; set; }
        public IList<object> via_waypoint { get; set; }
    }
}