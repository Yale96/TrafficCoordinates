using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SimulationSystem.Models;
using SimulationSystem.Repositories;
using SimulationSystem.DAL;

namespace SimulationSystem.Controllers
{
    [RoutePrefix("api/data")]
    public class DataController : ApiController
    {
        GoogleMapsRepository mapRepo;
               
        [HttpPost]
        public void Post()
        {
            using (var ctx = new SimulationContext())
            {
                //Must be made random in future
                Route routeOne = ctx.Routes.Where(r => r.id == 1).SingleOrDefault();
                //Must be made random in future
                Tracker trackerOne = ctx.Trackers.Where(t => t.trackerid == 1).SingleOrDefault();
                trackerOne.Routes.Add(routeOne);
                List<Marker> markers = (List<Marker>)routeOne.Markers;
                for (int i = 0; i < routeOne.Markers.Count; i++)
                {
                   
                    ctx.Trackers.Add(trackerOne);
                }
            }
        }

        [Route("generateroute")]
        [HttpPost]
        public void addRoute()
        {
            using (var ctx = new SimulationContext())
            {
                List<Tracker> trackers = new List<Tracker>();
                mapRepo = new GoogleMapsRepository();
                //List<Address> startAndEnd = mapRepo.getRandomStartAndEnd();
                Address start;
                Address end;
                mapRepo.getRouteAddres(out start, out end);


                List<Marker> markers = mapRepo.convertJsonToMarkers(mapRepo.getRawData(start, end));
                Route route = new Route(start, end, markers);
                ctx.Routes.Add(route);
                
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
    }
}