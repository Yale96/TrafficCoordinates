using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace SimulationSystem.Models
{
    [Table("Tracker")]
    public class Tracker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long trackerid { get; set; }
        public decimal lat { get; set; }
        public decimal lng { get; set; }
        public long timestamp { get; set; }
        public virtual ICollection<Route> Routes { get; set; }

        public Tracker()
        {

        }

        public Tracker(decimal lat, decimal lng, DateTime timestamp)
        {
            this.lat = lat;
            this.lng = lng;
            this.timestamp = timestamp.Ticks;
        }

        public Tracker(decimal lat, decimal lng, Int64 timestamp)
        {
            this.lat = lat;
            this.lng = lng;
            this.timestamp = timestamp;
        }
    }
}