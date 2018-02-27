using Newtonsoft.Json;
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
            catch(Exception e)
            {

            }
            return "";
        }

        public List<Marker> convertJsonToMarkers(string json)
        {
            List<Marker> markers = new List<Marker>();
            dynamic jsonData = JsonConvert.DeserializeObject<dynamic>(json);
            string[] firstSplittedString = Regex.Split(json, "\"steps\" : ");
            string[] secondSplittedString = Regex.Split(firstSplittedString[1], ",\n               \"traffic");
            
            return null;
        }

        public Address getRandomStart()
        {
            ExcelRepository exRepo = new ExcelRepository();
            List<Address> allAddresses = exRepo.readExcel();
            Random start = new Random();
            int first = start.Next(allAddresses.Count);
            Address[] a = exRepo.readExcel().ToArray();
            Address firstAddress = a[first];
            return firstAddress;
        }

        public Address getRandomEnd()
        {
            ExcelRepository exRepo = new ExcelRepository();
            List<Address> allAddresses = exRepo.readExcel();
            Random start = new Random();
            int first = start.Next(allAddresses.Count);
            Address[] a = exRepo.readExcel().ToArray();
            Address firstAddress = a[first];
            return firstAddress;
        }

        public List<Address> getRandomStartAndEnd()
        {
            List<Address> returnList = new List<Address>();
            Address start = getRandomStart();
            Address end = getRandomEnd();
            while(start == end)
            {
                start = getRandomStart();
                end = getRandomEnd();

                if(start.getZipcode() != end.getZipcode())
                {
                    break;
                }
            }
            returnList.Add(start);
            returnList.Add(end);
            return returnList;
        }
    }
}