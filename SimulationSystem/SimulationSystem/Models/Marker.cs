using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimulationSystem.Models
{
    public class Marker
    {
        private long FollowUpId;
        private double Lat;
        private double Lon;

        public Marker(long followUpId, double lat, double lon)
        {
            this.FollowUpId = followUpId;
            this.Lat = lat;
            this.Lon = lon;
        }

        public long getFollowUpId()
        {
            return this.FollowUpId;
        }

        public double getLat()
        {
            return this.Lat;
        }
        public double getLon()
        {
            return this.Lon;
        }
    }
}