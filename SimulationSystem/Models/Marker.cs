﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimulationSystem.Models
{
    [Table("Marker")]
    public class Marker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long FollowUpId { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }

        public Marker()
        {

        }

        public Marker(long followUpId, decimal lat, decimal lon)
        {
            this.FollowUpId = followUpId;
            this.Lat = lat;
            this.Lon = lon;
        }


    }
}