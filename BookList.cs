
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
    public class BookList :Datalist
    {
        public BookList()
       : base("Book", "ISBAN")
        { }


        protected override void GenerateList()
        {
            //creating book object
            Book book = new Book();
        
            //setting the column names for DataTable
            SetDataTableColumns(book);
            //clearing the list array
            List.Clear();
            //while there is information
            while (Reader.Read())
            {
                //getting the id from the table 
                book = new Book(Reader.GetValue(0).ToString());
                //setting the values
                base.SetValues(book);
                //adding the object to the lsit
                List.Add(book);
                try
                {
                    //adding the values from the book object to the DataTable
                    AddDataTableRow(book);
                }
                catch (Exception)
                {

                }
                
            }
            Reader.Close();
            Con.Close();

        }
    }
}
