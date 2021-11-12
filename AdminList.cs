using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
   public  class AdminList : Datalist
    {
        public AdminList() :base("Admin", "Admin_ID")
        {

        }

        protected override void GenerateList()
        {
            Admin admin = new Admin();
            SetDataTableColumns(admin);
            List.Clear();

            while (Reader.Read())
            {
                admin = new Admin(Reader.GetValue(0).ToString());
                base.SetValues(admin);
                List.Add(admin);
                AddDataTableRow(admin);
            }
            Reader.Close();
            Con.Close();

        }
    }
}
