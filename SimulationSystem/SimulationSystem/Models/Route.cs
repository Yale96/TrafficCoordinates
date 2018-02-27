using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimulationSystem.Models
{
    public class Route
    {
        private Address Start { get; set; }
        private Address End { get; set; }
        private List<Marker> Markers { get; set; }

        public Route(Address start, Address end)
        {
            this.Start = start;
            this.End = end;  
        }
        public List<Marker> getMarkers()
        {
            return this.Markers;
        }

        public void generateRoute()
        {

        }
    }
}