using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
    public class PaymentList : Datalist
    {
        public PaymentList() :base("Payment", "PaymentID")
        {

        }

        protected override void GenerateList()
        {
            Payment payment = new Payment();
            SetDataTableColumns(payment);
            List.Clear();

            while (Reader.Read())
            {
                payment = new Payment(Reader.GetValue(0).ToString());
                List.Add(payment);
                base.SetValues(payment);
                AddDataTableRow(payment);

            }
            Reader.Close();
            Con.Close();
        }
    }
}
