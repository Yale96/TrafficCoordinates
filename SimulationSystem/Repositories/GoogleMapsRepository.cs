using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimulationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Text.RegularExpressions;
using SimulationSystem.DAL;
using SimulationSystem.ResponseModels;

namespace SimulationSystem.Repositories
{
    public class GoogleMapsRepository
    {
        private WebClient Client;
        public GoogleMapsRepository()
        {
            Client = new WebClient();
        }

        public MapAPIResponse mapResponse(Address start, Address end)
        {
            string s = start.ToString();
            string e = end.ToString();
            string url = "https://maps.googleapis.com/maps/api/directions/json?origin=" + s + "&destination=" + e + "&key=AIzaSyALfpNH8dhaRgK3WvWnCx_pmA5hWPyOYJs";
            return JsonConvert.DeserializeObject<MapAPIResponse>(Client.DownloadString(url));
        }

        public List<Marker> mapMarkers(MapAPIResponse response)
        {
            List<Marker> mapmarkers = new List<Marker>();
            foreach (ResponseRoute r in response.routes)
            {
                foreach (Leg l in r.legs)
                {
                    mapmarkers.Add(new Marker(l.start_location.lat,l.start_location.lng));
                    foreach (Step s in l.steps)
                    {
                        mapmarkers.Add(new Marker(s.start_location.lat,s.start_location.lng));
                        mapmarkers.Add(new Marker(s.end_location.lat,s.end_location.lng));
                    }
                    mapmarkers.Add(new Marker(l.end_location.lat, l.end_location.lng));
                }
                
            }
            return mapmarkers;
        }

        public RoadAPIResponse roadResponse(Marker m1, Marker m2)
        {
            string markerString = m1+ "" + m2;

            //foreach (Marker m in markers)
            //{
            //        markerString += m.ToString();
            //}
            markerString = markerString.Remove(markerString.Length - 1);

            string url = "https://roads.googleapis.com/v1/nearestRoads?points="+ markerString + "&key=AIzaSyCIx_pQb19a4YJMg1mPq6xEW3Qy5MRnGEE";
            return JsonConvert.DeserializeObject<RoadAPIResponse>(Client.DownloadString(url));
        }

        public void getRouteAddres(Tracker tracker, out Address start, out Address end)
        {
            using (var ctx = new SimulationContext())
            {
                List<Address> allAddresses = ctx.Addresses.ToList();
                Random rndStart = new Random();
                Random rndEnd = new Random();
                if (tracker.Routes.Count != 0)
                {
                    start = tracker.Routes.Last().End;
                }
                else
                {
                    start = allAddresses[rndStart.Next(allAddresses.Count)];
                }
                end = allAddresses[rndEnd.Next(allAddresses.Count)];
                while (end == start)
                {
                    end = allAddresses[rndEnd.Next(allAddresses.Count)];
                }
            }
        }

        public double calculateDistance(Marker mOne, Marker mTwo)
        {
            double rlat1 = Math.PI * (double)mOne.Lat / 180;
            double rlat2 = Math.PI * (double)mTwo.Lat / 180;
            double theta = (double)mOne.Lon - (double)mTwo.Lon;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;
            dist = dist * 1.609344;

            return dist;
        }

        public Models.Route generateRoute(Tracker tracker)
        {
            using (var ctx = new SimulationContext())
            {
                Address start;
                Address end;
                getRouteAddres(tracker, out start, out end);
                List<Marker> markers = mapMarkers(mapResponse(start, end));
                List<Marker> roadMarkers = new List<Marker>();
                for (int i = 0; i < markers.Count - 1; i++)
                {
                    foreach (SnappedPoint s in roadResponse(markers[i],markers[i+1]).snappedPoints)
                    {
                        roadMarkers.Add(new Marker(s.location.latitude, s.location.longitude));
                    }
                }

                Route route = new Route(start, end, roadMarkers);
                ctx.SaveChanges();
                return route;
            }
        }
    }
}