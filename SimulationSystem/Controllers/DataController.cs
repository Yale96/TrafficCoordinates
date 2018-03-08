using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SimulationSystem.Models;
using SimulationSystem.Repositories;

namespace SimulationSystem.Controllers
{
    public class DataController : ApiController
    {
        GoogleMapsRepository mapRepo;
        
        [HttpGet]
        public IEnumerable<Tracker> Get()
        {
            List<Tracker> trackers = new List<Tracker>();
            //mapRepo = new GoogleMapsRepository();
            //List<Address> startAndEnd = mapRepo.getRandomStartAndEnd();
            //List<Marker> markers = mapRepo.convertJsonToMarkers(mapRepo.getRawData(startAndEnd[0], startAndEnd[1]));
            //Tracker tracker = new Tracker("BE001", markers[0].getLat(), markers[0].getLon(), DateTime.Now);
            Tracker tracker = new Tracker("BE001", (decimal)53.22455, (decimal)4.5635677, DateTime.Now);
            Tracker tracker2 = new Tracker("BE002", (decimal)53.22356, (decimal)4.564444, DateTime.Now);
            trackers.Add(tracker);
            trackers.Add(tracker2);
            return trackers;
        }
    }
}