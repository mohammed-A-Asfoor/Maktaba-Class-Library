using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
    public class Cart:Item
    {
        private string lasdEditied;
        private string customerID;

        public Cart()
        {

        }
        public Cart(string id):base(id)
        {

        }

        public string CartID
        {
            get { return base.getID(); }
            set { base.setID(value); }
        }
        public string LastEdited
        {
            get { return lasdEditied; }
            set { lasdEditied = value; }
        }
        public string CustomerID
        {
            get { return customerID ; }
            set { customerID = value; }
        }
       
    }
}
