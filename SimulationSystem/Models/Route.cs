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
        public long id { get; set; }
        public Address Start { get; set; }
        public Address End { get; set; }
        [ForeignKey("FollowUpId")]
        public virtual ICollection<Marker> Markers { get; set; }
        public Route()
        {

        }

        public Route(Address start, Address end, ICollection<Marker> markers)
        {
            this.Start = start;
            this.End = end;
            this.Markers = markers;
        }

    }
}