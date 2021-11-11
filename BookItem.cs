using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
    public class BookItem : Item
    {
        private string quantity;
        private string publisher;
        private string condition;
        private string adding_date;
        private string book_price;
        private string isban;
        private string admin_ID;

        public BookItem()
        {

        }
        public BookItem( string id):base(id)
        {

        }
        public string Book_Itme_id
        {
            get { return base.getID(); }
            set { base.setID(value); }
        }
        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }
        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }
        public string Adding_date
        {
            get { return adding_date; }
            set { adding_date = value; }
        }
        public string Book_price
        {
            get { return book_price; }
            set { book_price = value; }
        }
        public string ISBAN
        {
            get { return isban; }
            set { isban = value; }
        }
        public string Admin_ID
        {
            get { return admin_ID; }
            set { admin_ID = value; }
        }
    }
}
