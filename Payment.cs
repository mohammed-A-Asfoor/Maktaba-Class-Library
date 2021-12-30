using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
    public class Payment : Item
    {
        
        private string name;
        private string cardNumber;
        private string cvv;
        private string expiry;
        private string orderID;
        

        public Payment()
        {

        }
        public Payment(string id):base(id)
        {

        }

        public string PaymentID
        {
            get { return base.getID(); }
            set { base.setID(value); }
        }
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public string CardNumber
        {
            get { return cardNumber ; }
            set { cardNumber = value; }
        }
        
        public string CVV
        {
            get { return cvv; }
            set { cvv = value; }
        }
        
        
        public string Expiry
        {
            get { return expiry; }
            set { expiry = value; }
        }
        public string Order_id
        {
            get { return orderID; }
            set { orderID = value; }
        }

        
    }
}
