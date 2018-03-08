using SimulationSystem.Models;
using SimulationSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

namespace SimulationSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ExcelRepository excelRepository = new ExcelRepository();
            GoogleMapsRepository mapRepo = new GoogleMapsRepository();
            
            List<Address> a = excelRepository.readExcel();
            
            mapRepo.getRandomStartAndEnd();
            string data = mapRepo.getRawData(a[0], a[1]);
            List<Marker> markers = mapRepo.convertJsonToMarkers(mapRepo.getRawData(a[0], a[1]));
            mapRepo.convertJsonToMarkers(data);
            double m = mapRepo.calculateDistance(markers[0], markers[1]);
            return View();
        }
    }
}
