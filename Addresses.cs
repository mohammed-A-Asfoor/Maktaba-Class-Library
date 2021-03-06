using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
    public class Addresses:Item
    {
        private string street;
        private string block;
        private string house;
        private string city;
        private string country;
        private string customerID;

        public Addresses()
        {

        }
        public Addresses(string id):base(id)
        {

        }

        public string Address_id
        {
            get { return base.getID(); }
            set { base.setID(value); }
        }
        [Required]
        public string Street
        {
            get { return street; }
            set { street = value; }
        }
        [Required]
        public string House
        {
            get { return house ; }
            set { house = value; }
        }
        [Required]
        public string Block
        {
            get { return block; }
            set { block = value; }
        }
        [Required]
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        [Required]
        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        public string CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        public override string ToString()
        {
            return base.getID() + " // House:" + house + " // Stree:" + street + " // Country:" + country;
        }
    }
}
