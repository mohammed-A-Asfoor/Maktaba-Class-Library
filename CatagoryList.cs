using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
    public class CatagoryList:Datalist
    {
        public CatagoryList()
            :base("category", "category_id")
        { }

        protected override void GenerateList()
        {
            //creating Catagory object
            Catagory catagory = new Catagory();
            //setting the column names for DataTable
            SetDataTableColumns(catagory);
            //clearing the list array
            List.Clear();
            //while there is information
            while (Reader.Read())
            {//getting the id from the table 
                catagory = new Catagory(Reader.GetValue(0).ToString());
                //setting the values
                base.SetValues(catagory);
                //adding the object to the lsit
                List.Add(catagory);
                //adding the values from the book object to the DataTable
                AddDataTableRow(catagory);
            }
            Reader.Close();
            Con.Close();

        }

    }
}
