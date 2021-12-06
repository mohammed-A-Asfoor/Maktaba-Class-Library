using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Maktaba_Class_Library
{
    public class CustomerList : Datalist
    {
        public CustomerList()
         : base("customer", "CustomerID")
        { }


        protected override void GenerateList()
        {
            customer customer = new customer();
            SetDataTableColumns(customer);
            getColumnName(customer);
            List.Clear();

            while (Reader.Read())
            {
                customer = new customer(Reader.GetValue(0).ToString());
                base.SetValues(customer);
                List.Add(customer);
                
                AddDataTableRow(customer);
            }
            Reader.Close();
            Con.Close();

        }
    }
}
