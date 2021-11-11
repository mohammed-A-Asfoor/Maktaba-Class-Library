using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
    public class CatagoryList:Datalist
    {
        public CatagoryList() :base("category", "category")
        {

        }

        protected override void GenerateList()
        {
            Catagory catagory = new Catagory();
            SetDataTableColumns(catagory);
            List.Clear();

            while (Reader.Read())
            {
                catagory = new Catagory(Reader.GetValue(0).ToString());
                base.SetValues(catagory);
                AddDataTableRow(catagory);
            }
        }

    }
}
