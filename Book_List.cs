using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
   public class Book_List:ItemJoin
    {

        private string quantity;
        public Book_List()
        {

        }
        public Book_List(string id, string idJion):base(id,idJion)
        {

        }

        public string Order_id
        {
            get { return base.getID(); }
            set { base.setID(value); }
        }
        public string Book_Itme_id
        {
            get { return base.getIdJoin(); }
            set { base.setIdJoin(value); }
        }
        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }



    }
}
