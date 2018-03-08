using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimulationSystem.Models
{
    public class Marker
    {
        private long FollowUpId;
        private decimal Lat;
        private decimal Lon;

        public Marker(long followUpId, decimal lat, decimal lon)
        {
            this.FollowUpId = followUpId;
            this.Lat = lat;
            this.Lon = lon;
        }

        public long getFollowUpId()
        {
            return this.FollowUpId;
        }

        public decimal getLat()
        {
            return this.Lat;
        }
        public decimal getLon()
        {
            return this.Lon;
        }
    }
}