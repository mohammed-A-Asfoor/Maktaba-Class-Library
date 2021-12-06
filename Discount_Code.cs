using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
   public class Discount_Code :Item
    {
        private string status;
        private string amount;
        private string admin_id;
        public Discount_Code(string id) :base(id)
        {

        }
        public Discount_Code()
        {

        }

        public string codeID
        {
            get { return base.getID(); }
            set { base.setID(value); }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public string Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public string Admin_ID
        {
            get { return admin_id; }
            set { admin_id = value; }
        }

    }
}
