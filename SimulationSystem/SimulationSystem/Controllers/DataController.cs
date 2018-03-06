using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using SimulationSystem.Models;
using SimulationSystem.Repositories;

namespace SimulationSystem.Controllers
{
    public class DataController : ApiController
    {
        GoogleMapsRepository mapRepo;
        
        public IEnumerable<Marker> Get()
        {
            mapRepo = new GoogleMapsRepository();
            List<Address> startAndEnd = mapRepo.getRandomStartAndEnd();
            return mapRepo.convertJsonToMarkers(mapRepo.getRawData(startAndEnd[0], startAndEnd[1]));
        }
    }
}