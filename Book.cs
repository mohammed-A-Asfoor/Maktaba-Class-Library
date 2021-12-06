using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
	public class Book :Item
	{

		private string book_Auther;
		private string book_DOR;
		private string publisher;
		private string book_title;
		private string catagoryID;

		public Book()
		{

		}

		public Book(string id) : base(id)
		{

		}

		public string ISBAN
        {
            get { return base.getID(); }
			set { base.setID(value); }
        }
		public string Book_Auther
        {
            get { return book_Auther; }
            set { book_Auther = value; }
        }
		public string Book_Title
        {
            get { return book_title; }
			set { book_title = value; }
        }
		public string Publisher
		{
			get { return publisher; }
			set { publisher = value; }
		}
		public string Date_Of_Release
        {
			get { return book_DOR; }
			set { book_DOR = value; }
        }
		public string category_id
		{
            get { return catagoryID; }
            set { catagoryID = value; }
        }
		public override string ToString()
		{
			return getID();
		}

	}//end Book
}
