using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SimulationSystem.Models;
using SimulationSystem.Repositories;
using SimulationSystem.DAL;
using SimulationSystem.ResponseModels;

namespace SimulationSystem.Controllers
{
    [RoutePrefix("api/data")]
    public class DataController : ApiController
    {
        GoogleMapsRepository mapRepo = new GoogleMapsRepository();
               
        [HttpPost]
        public void Post()
        {
            using (var ctx = new SimulationContext())
            {
                Tracker tracker = ctx.Trackers.Where(t => t.trackerid == 1).SingleOrDefault();
                tracker.Routes.Add(mapRepo.generateRoute(tracker));
                ctx.SaveChanges();
            }
        }

        [Route("createtracker")]
        [HttpPost]
        public void CreateTracker()
        {
            using (var ctx = new SimulationContext())
            {
                Tracker t = new Tracker(0,0,DateTime.Now);
                ctx.Trackers.Add(t);
                ctx.SaveChanges();
            }
        }

        [Route("test")]
        [HttpPost]
        public void Test()
        {
            using (var ctx = new SimulationContext())
            {
                ctx.Addresses.Add(new Address("Test", "Test", "Test", "Test"));
                ctx.SaveChanges();
            }
        }

        [Route("testroadapi")]
        [HttpPost]
        public void TestRoadApi()
        {
            using (var ctx = new SimulationContext())
            {
                Tracker tracker = ctx.Trackers.Where(t => t.trackerid == 1).SingleOrDefault();
                Route r = mapRepo.generateRoute(tracker);

                foreach (SnappedPoint s in mapRepo.roadResponse(r.Markers).snappedPoints)
                {

                    ctx.Markers.Add(new Marker((decimal)s.location.latitude, (decimal)s.location.longitude));
                    ctx.SaveChanges();

                }
            }
        }
    }
}