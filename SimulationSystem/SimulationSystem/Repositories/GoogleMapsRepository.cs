﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimulationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Text.RegularExpressions;

namespace SimulationSystem.Repositories
{
    public class GoogleMapsRepository
    {
        private WebClient Client;
        ExcelRepository exRepo;
        public GoogleMapsRepository()
        {
            Client = new WebClient();
            exRepo = new ExcelRepository();
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
            catch(Exception e)
            {

            }
            return "";
        }

        public List<Marker> convertJsonToMarkers(string json)
        {
            List<Marker> markers = new List<Marker>();
            int markerID = 0;

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

                    double lat;
                    double lng;
                    Double.TryParse(coordinates.Children().ElementAt(0).Children().ElementAt(0).ToString(), out lat);
                    Double.TryParse(coordinates.Children().ElementAt(1).Children().ElementAt(0).ToString(), out lng);

                    Marker m = new Marker(markerID, lat, lng);
                    markers.Add(m);
                    markerID++;
                }
            }
            return markers;
        }

        public List<Address> getRandomStartAndEnd()
        {
            exRepo = new ExcelRepository();
            List<Address> allAddresses = exRepo.readExcel();
            List<Address> returnAddresses = new List<Address>();
            Random start = new Random();
            int a = 0;
            int b = 0;
            while(a == b)
            {
                a = start.Next(allAddresses.Count);
                b = start.Next(allAddresses.Count);
            }
            returnAddresses.Add(allAddresses[a]);
            returnAddresses.Add(allAddresses[b]);

            return returnAddresses;
        }

        public double calculateDistance(Marker mOne, Marker mTwo)
        {
            var a = mTwo.getLat() - mOne.getLat();
            var b = mTwo.getLon() - mOne.getLon();

            return Math.Sqrt(a * a + b * b);
        }
    }
}