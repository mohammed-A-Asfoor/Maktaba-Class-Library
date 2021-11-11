using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
    public class OrderList: Datalist
    {
        public OrderList() :base("Orders", "Order_id")
        {}

        protected override void GenerateList()
        {
            Order order = new Order();
            base.SetDataTableColumns(order);
            List.Clear();

            while (Reader.Read())
            {
                order = new Order(Reader.GetValue(0).ToString());
                base.SetValues(order);
                List.Add(order);
                AddDataTableRow(order);
            }
            Reader.Close();
            Con.Close();
        }

    }
}
