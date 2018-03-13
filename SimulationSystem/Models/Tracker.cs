using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace SimulationSystem.Models
{
    [DataContract]
    public class Tracker
    {
        [DataMember]
        private string trackerid { get; set; }
        [DataMember]
        private decimal lat { get; set; }
        [DataMember]
        private decimal lng { get; set; }
        [DataMember]
        private long timestamp { get; set; }

        public Tracker(string trackerid, decimal lat, decimal lng, DateTime timestamp)
        {
            this.trackerid = trackerid;
            this.lat = lat;
            this.lng = lng;
            this.timestamp = timestamp.Ticks;
        }
    }
}