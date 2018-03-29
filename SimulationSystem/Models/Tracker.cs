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
        public long ID { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public long Timestamp { get; set; }
        public virtual ICollection<Route> Routes { get; set; }

        public Tracker()
        {

        }

        public Tracker(double lat, double lng, DateTime timestamp)
        {
            this.Lat = lat;
            this.Lng = lng;
            this.Timestamp = timestamp.Ticks;
        }

        public Tracker(double lat, double lng, Int64 timestamp)
        {
            this.Lat = lat;
            this.Lng = lng;
            this.Timestamp = timestamp;
        }
    }
}