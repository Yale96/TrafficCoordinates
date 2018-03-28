using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimulationSystem.ResponseModels
{
    public class RoadAPIResponse
    {
        public IList<SnappedPoint> snappedPoints { get; set; }
    }
}