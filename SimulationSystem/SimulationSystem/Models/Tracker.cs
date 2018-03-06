using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimulationSystem.Models
{
    public class Tracker
    {
        private long trackerid { get; set; }
        private decimal lat { get; set; }
        private decimal lng { get; set; }
        private DateTime timestamp { get; set; }

        public Tracker(long trackerid, decimal lat, decimal lng, DateTime timestamp)
        {
            this.trackerid = trackerid;
            this.lat = lat;
            this.lng = lng;
            this.timestamp = timestamp;
        }
    }
}