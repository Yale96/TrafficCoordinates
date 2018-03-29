using Newtonsoft.Json;
using SimulationSystem.ResponseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SimulationSystem.Models
{
    [Table("Route")]
    public class Route
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public virtual ICollection<Marker> Markers { get; set; }
        [ForeignKey("Tracker")]
        public long Trackerid { get; set; }
        [JsonIgnore]
        public virtual Tracker Tracker { get; set; }
        public OverviewPolyline Polyline { get; set; }
        [ForeignKey("Start")]
        public long StartID { get; set; }
        public virtual Address Start { get; set; }
        [ForeignKey("End")]
        public long EndID { get; set; }
        public virtual Address End { get; set; }
        public Route()
        {

        }

        public Route(Address start, Address end, OverviewPolyline pol)
        {
            this.Start = start;
            this.End = end;
            this.Polyline = pol;
        }

    }
}