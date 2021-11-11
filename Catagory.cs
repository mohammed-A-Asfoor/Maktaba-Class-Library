using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
    public class Catagory:Item
    {
        private string catagoryName;
        private string catagoryDesc;

        public Catagory()
        {

        }
        public Catagory(string id) :base(id)
        {

        }

        public string catagory_name
        {
            get { return catagoryName; }
            set { catagoryName = value; }
        }
        public string catagory_description
        {
            get { return catagoryDesc; }
            set { catagoryDesc = value; }
        }
    }
}
