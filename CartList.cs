using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
    public class CartList : Datalist
    {
        public CartList() :base("Cart", "CartID")
        {

        }

        protected override void GenerateList()
        {
            Cart cart = new Cart();
            SetDataTableColumns(cart);
            List.Clear();

            while (Reader.Read())
            {
                cart = new Cart(Reader.GetValue(0).ToString());
                List.Add(cart);
                base.SetValues(cart);
                AddDataTableRow(cart);

            }
            Reader.Close();
            Con.Close();
        }
    }
}
