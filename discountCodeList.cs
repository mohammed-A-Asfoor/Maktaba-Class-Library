using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
    public class discountCodeList: Datalist
    {
        public discountCodeList()
        : base("Discount_Code", "codeID")
        { }


        protected override void GenerateList()
        {
            Discount_Code discount_code = new Discount_Code();
            SetDataTableColumns(discount_code);
            getColumnName(discount_code);
            List.Clear();

            while (Reader.Read())
            {
                discount_code = new (Reader.GetValue(0).ToString());
                base.SetValues(discount_code);
                List.Add(discount_code);

                AddDataTableRow(discount_code);
            }
            Reader.Close();
            Con.Close();

        }
    }
}
