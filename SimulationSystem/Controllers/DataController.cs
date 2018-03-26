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
    public class DataController : ApiController
    {
        GoogleMapsRepository mapRepo;
        
        //[HttpPost]
        //public IEnumerable<Tracker> Post()
        //{
        //    using (var ctx = new SimulationContext())
        //    {
        //        List<Tracker> trackers = new List<Tracker>();
        //        mapRepo = new GoogleMapsRepository();
        //        List<Address> startAndEnd = mapRepo.getRandomStartAndEnd();
        //        List<Marker> markers = mapRepo.convertJsonToMarkers(mapRepo.getRawData(startAndEnd[0], startAndEnd[1]));
        //        for (int i = 0; i < markers.Count; i++)
        //        {
        //            Tracker tracker = new Tracker(markers[i].Lat, markers[i].Lon, DateTime.Now);
        //            trackers.Add(tracker);
        //            ctx.Trackers.Add(tracker);
        //            ctx.SaveChanges();

        //        }
        //        return trackers;
        //    }
        //}

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