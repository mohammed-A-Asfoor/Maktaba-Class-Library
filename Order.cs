using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
    public class Order :Item
    {
       
        private string orderData;
        private string totalPrice;
        private string customerID;
        private string addressID;
        public Order()
        {

        }
        public Order(string id) :base(id) 
        {

        }
        public string Order_id
        {
            get { return base.getID(); }
            set { base.setID(value); }
        }
        public string Order_date
        {
            get { return orderData; }
            set { orderData = value; }
        }
        public string Total_price
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }
        public string CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }
        public string Address_id 
        {
            get { return addressID; }
            set { addressID = value; }
        }

    }
}
