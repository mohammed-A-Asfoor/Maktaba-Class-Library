using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
    public class BookItemList : Datalist
    {
        public BookItemList()
       : base("Book_Item", "Book_Itme_id")
        { }


        protected override void GenerateList()
        {
            BookItem bookItem = new BookItem();
            SetDataTableColumns(bookItem);
            List.Clear();

            while (Reader.Read())
            {
                try
                {
                    bookItem = new BookItem(Reader.GetValue(0).ToString());
                    base.SetValues(bookItem);
                    List.Add(bookItem);
                    AddDataTableRow(bookItem);
                }catch(Exception ex)
                {
                    bookItem.setVaild(false);
                    bookItem.setErrorMessage(ex.Message);
                }
                
            }
            Reader.Close();
            Con.Close();

        }
    }
}
