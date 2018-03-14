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
        
        [HttpPost]
        public IEnumerable<Tracker> Post()
        {
            SimulationSystem.DAL.MySql sql = new DAL.MySql();
            List<Tracker> trackers = new List<Tracker>();
            mapRepo = new GoogleMapsRepository();
            List<Address> startAndEnd = mapRepo.getRandomStartAndEnd();
            List<Marker> markers = mapRepo.convertJsonToMarkers(mapRepo.getRawData(startAndEnd[0], startAndEnd[1]));
            for(int i = 0; i < markers.Count; i++)
            {
                Tracker tracker = new Tracker("BE001", markers[i].getLat(), markers[i].getLon(), DateTime.Now);
                trackers.Add(tracker);
                sql.insertTracker(tracker);

            }
            return trackers;
        }

        [HttpGet]
        public IEnumerable<Tracker> Get()
        {
            SimulationSystem.DAL.MySql sql = new DAL.MySql();
            List<Tracker> trackers = new List<Tracker>();
            int counter = sql.getCounter();
            Tracker tracker = sql.getTracker(counter);
            trackers.Add(tracker);
            counter++;
            if(counter < 16)
            {
                sql.updateCounter(counter);
            }
            else
            {
                sql.updateCounter(1);
            }
            return trackers;
        }
    }
}