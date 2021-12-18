using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
    public class ItemInCartList :DataListJoin
    {
        public ItemInCartList() :base("ItemsInCart", "CartID", "Book_Itme_id")
        {
            
        }

        protected override void GenerateList()
        {
            ItemInCart itemInCart = new ItemInCart();
            SetDataTableColumns(itemInCart);
            List.Clear();

            while (Reader.Read())
            {
                itemInCart = new ItemInCart(Reader.GetValue(0).ToString(), Reader.GetValue(1).ToString());
                base.SetValues(itemInCart);
                List.Add(itemInCart);
                AddDataTableRow(itemInCart);
            }
            Reader.Close();
            Con.Close();
        }
    }
}
