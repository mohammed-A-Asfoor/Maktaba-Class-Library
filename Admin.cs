using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
    class Admin :Item
    {
        private string adminID;
        private string adminName;
        private string adminPassword;
        private string adminEmail;

        public Admin()
        {

        }
        public Admin( string id) :base(id)
        {

        }

        public string Admin_ID
        {
            get { return base.getID(); }
            set { base.setID(value); }
        }
        public string Admin_Name
        {
            get { return adminName; }
            set { adminName = value; }
        }
        public string Admin_Password
        {
            get { return adminPassword; }
            set { adminPassword = value; }
        }
        public string Admin_Email
        {
            get { return adminEmail; }
            set { adminEmail = value; }
        }
    }
}
