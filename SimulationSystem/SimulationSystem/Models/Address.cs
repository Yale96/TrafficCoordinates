using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimulationSystem.Models
{
    public class Address
    {
        private string Street;
        private string Number;
        private string Zip;
        private string City;

        public Address(string street, string number, string zip, string city)
        {
            this.Street = street;
            this.Number = number;
            this.Zip = zip;
            this.City = city;
        }

        public string getStreet()
        {
            return this.Street;
        }

        public string getNumber()
        {
            return this.Number;
        }

        public string getZipcode()
        {
            return this.Zip;
        }

        public string getCity()
        {
            return this.City;
        }
        public override string ToString()
        {
            return Street + "+" + Number + "+" + Zip + "+" + City;
        }
    }
}