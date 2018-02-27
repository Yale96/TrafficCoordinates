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

        public Marker(long followUpId, double lan, double lon)
        {
            this.FollowUpId = followUpId;
            this.Lat = lan;
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