using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace SimulationSystem.Models
{
    [Table("Marker")]
    public class Marker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        [ForeignKey("Route")]
        public long Routeid { get; set; }
        [JsonIgnore]
        public virtual Route Route { get; set; }

        public Marker()
        {

        }

        public Marker(double lat, double lon)
        {
            this.Lat = lat;
            this.Lon = lon;
        }

        public override string ToString()
        {
            return this.Lat.ToString() + "," + this.Lon.ToString() + "|";
        }

    }
}