using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
    public class Book_ListList :DataListJoin
    {
        public Book_ListList() :base("BookList", "Order_id", "Book_Itme_id")
        {
            
        }

        protected override void GenerateList()
        {
            Book_List Book_List = new Book_List();
            SetDataTableColumns(Book_List);
            List.Clear();

            while (Reader.Read())
            {
                Book_List = new Book_List(Reader.GetValue(0).ToString(), Reader.GetValue(1).ToString());
                base.SetValues(Book_List);
                List.Add(Book_List);
                AddDataTableRow(Book_List);
            }
            Reader.Close();
            Con.Close();
        }
    }
}
