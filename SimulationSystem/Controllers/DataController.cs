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
                Tracker tracker = ctx.Trackers.Where(t => t.ID == 1).SingleOrDefault();
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
                Tracker t = new Tracker(0, 0, DateTime.Now);
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

        [Route("gettracker")]
        [HttpGet]
        public Tracker Get()
        {
            using (var ctx = new SimulationContext())
            {
                ctx.Configuration.AutoDetectChangesEnabled = false;
                ctx.Configuration.ProxyCreationEnabled = false;
                ctx.Configuration.LazyLoadingEnabled = false;
                Tracker track = ctx.Trackers.Include("Routes").Where(t => t.ID == 1).SingleOrDefault();
                foreach (Route r in track.Routes)
                {
                    r.Markers = ctx.Markers.Where(m => m.Routeid == r.ID).ToList();
                    r.Start = ctx.Addresses.Where(a => a.AdressID == r.StartID).SingleOrDefault();
                    r.End = ctx.Addresses.Where(a => a.AdressID == r.EndID).SingleOrDefault();

                }
                return track;
            }
        }
    }
}
