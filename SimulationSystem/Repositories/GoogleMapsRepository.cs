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

        public string getRawData(Address start, Address end)
        {
            try
            {
                string s = start.ToString();
                string e = end.ToString();
                string url = "https://maps.googleapis.com/maps/api/directions/json?origin=" + s + "&destination=" + e + "&key=AIzaSyALfpNH8dhaRgK3WvWnCx_pmA5hWPyOYJs";
                string content = Client.DownloadString(url);
                return content;
            }
            catch (Exception e)
            {
                
            }
            return "";
        }

        public RoadAPIResponse roadResponse(ICollection<Marker> markers)
        {
            string markerString = "";

            foreach (Marker m in markers)
            {
                    markerString += m.ToString();
            }
            markerString = markerString.Remove(markerString.Length - 1);

            string url = "https://roads.googleapis.com/v1/nearestRoads?points="+ markerString + "&key=AIzaSyCIx_pQb19a4YJMg1mPq6xEW3Qy5MRnGEE";
            return JsonConvert.DeserializeObject<RoadAPIResponse>(Client.DownloadString(url));
        }

        public List<Marker> convertJsonToMarkers(string json)
        {
            List<Marker> markers = new List<Marker>();

            string[] firstSplittedString = Regex.Split(json, "\"steps\" : ");
            string[] secondSplittedString = Regex.Split(firstSplittedString[1], ",\n               \"traffic");
            JArray JSONObjects = JArray.Parse(secondSplittedString[0]);
            JEnumerable<JToken> tokens = JSONObjects.Children();
            List<int> indexes = new List<int>();
            indexes.Add(5);

            for (int i = 0; i < tokens.Count(); i++)
            {
                if (i == (tokens.Count() - 1))
                {
                    indexes.Add(2);
                }

                foreach (int index in indexes)
                {
                    var JObject = tokens.ElementAt(i);
                    JEnumerable<JToken> coordinates;
                    if (index == 5 && JObject.Children().Count() == 8)
                    {
                        coordinates = JObject.Children().ElementAt(6).Children();
                    }
                    else
                    {
                        coordinates = JObject.Children().ElementAt(index).Children();
                    }

                    decimal lat;
                    decimal lng;
                    Decimal.TryParse(coordinates.Children().ElementAt(0).Children().ElementAt(0).ToString(), out lat);
                    Decimal.TryParse(coordinates.Children().ElementAt(1).Children().ElementAt(0).ToString(), out lng);

                    Marker m = new Marker(lat, lng);
                    markers.Add(m);
                }
            }
            return markers;
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

        public Route generateRoute(Tracker tracker)
        {
            Address start;
            Address end;
            getRouteAddres(tracker, out start, out end);
            List<Marker> markers = convertJsonToMarkers(getRawData(start, end));
            Route route = new Route(start, end, markers);
            return route;
        }
    }
}