
using System;
using System.Collections.Generic;
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
            Book book = new Book();
            SetDataTableColumns(book);
            List.Clear();

            while (Reader.Read())
            {
                book = new Book(Reader.GetValue(0).ToString());
                base.SetValues(book);
                List.Add(book);
                AddDataTableRow(book);
            }
            Reader.Close();
            Con.Close();

        }
    }
}
