using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace SimulationSystem.Models
{
    [DataContract]
    public class Tracker
    {
        [DataMember]
        public string trackerid { get; set; }
        [DataMember]
        public decimal lat { get; set; }
        [DataMember]
        public decimal lng { get; set; }
        [DataMember]
        public long timestamp { get; set; }

        public Tracker(string trackerid, decimal lat, decimal lng, DateTime timestamp)
        {
            this.trackerid = trackerid;
            this.lat = lat;
            this.lng = lng;
            this.timestamp = timestamp.Ticks;
        }

        public Tracker(string trackerid, decimal lat, decimal lng, Int64 timestamp)
        {
            this.trackerid = trackerid;
            this.lat = lat;
            this.lng = lng;
            this.timestamp = timestamp;
        }
    }
}