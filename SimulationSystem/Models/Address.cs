using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimulationSystem.Models
{
    [Table("AddressTable")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public Address()
        {

        }

        public Address(string street, string number, string zip, string city)
        {
            this.Street = street;
            this.Number = number;
            this.Zip = zip;
            this.City = city;
        }

        public override string ToString()
        {
            return Street + "+" + Number + "+" + Zip + "+" + City;
        }
    }
}