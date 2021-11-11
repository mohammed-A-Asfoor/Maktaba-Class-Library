using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
    public class AddressesList : Datalist
    {
        public AddressesList() :base("Addresses", "Address_id")
        {

        }

        protected override void GenerateList()
        {
            Addresses addresses = new Addresses();
            SetDataTableColumns(addresses);
            List.Clear();

            while (Reader.Read())
            {
                addresses = new Addresses(Reader.GetValue(0).ToString());
                base.SetValues(addresses);
                AddDataTableRow(addresses);

            }
            Reader.Close();
            Con.Close();
        }
    }
}
