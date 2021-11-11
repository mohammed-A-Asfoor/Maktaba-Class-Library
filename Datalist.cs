using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
    public class Datalist
    {

        private string table;
        private SqlConnection con;
        private SqlCommand command;
        private SqlDataReader reader;
        private List<Item> list;
        private string idFeild;
        private DataTable datatable;
        public Datalist(string table, string idField)
        {
            list = new List<Item>();
            this.table = table;
            this.idFeild = idField;
            con =
                new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Maktaba;Integrated Security=True");
            command = con.CreateCommand();
            datatable = new DataTable();
        }
        public string Table
        {
            get { return table; }
            set { table = value; }
        }
        public DataTable DataTable
        {
            get { return datatable; }
            set { datatable = value; }
        }

        protected string IdFeild
        {
            get { return idFeild; }
            set { this.idFeild = value; }
        }
        protected SqlCommand Command
        {
            get { return command; }
            set { this.command = value; }
        }
        protected SqlConnection Con
        {
            get { return this.con; }
            set { con = value; }
        }

        protected SqlDataReader Reader
        {
            get { return reader; }
            set { reader = value; }
        }

        public List<Item> List
        {
            get { return list; }
            set { list = value; }
        }
        public void SetDataTableColumns(Item item)
        {

            datatable.Clear();
            datatable.Columns.Clear();
            Type type = item.GetType();

            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                datatable.Columns.Add(property.Name);
            }

        }
        public void AddDataTableRow(Item item)
        {
            int count = 0;
            Type type = item.GetType();
            PropertyInfo[] properties = type.GetProperties();
            string[] values = new string[properties.Count()];

            foreach (PropertyInfo property in properties)
            {
                values[count] = property.GetValue(item).ToString();
                count++;
            }
            datatable.Rows.Add(values);
        }

        public virtual void Populate()
        {
            con.Open();
            command.CommandText = "SELECT * FROM " + table;
            reader = command.ExecuteReader();
            GenerateList();
        }
        //can be used to find a book using one search critera
        public virtual void Filter(string field, string value)
        {
            con.Open();
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@field", field);
            command.Parameters.AddWithValue("@value", "'"+value+"'");
             command.CommandText = "SELECT * FROM " + table + " WHERE " + field + " = '" + value+"'";
            //command.CommandText = "SELECT * FROM " + table + " WHERE  @field = @value " ;
            reader = command.ExecuteReader();
            GenerateList();

        }



        protected virtual void GenerateList()
        {

        }


        protected void SetValues(Item item)
        {
            Type type = item.GetType();

            PropertyInfo[] properties = type.GetProperties();

            int fieldCount = 0;
            foreach (PropertyInfo property in properties)
            {
                property.SetValue(item, reader.GetValue(fieldCount).ToString());
                fieldCount++;
            }
        }


        public void Populate(Item item)
        {
            con.Open();
            command.Parameters.Clear();
             command.Parameters.AddWithValue("@id", item.getID());
            //command.Parameters.Add("@id", SqlDbType.VarChar).Value=item.getID();
            /*SqlParameter param = new SqlParameter();
            param.ParameterName = "@id";
            param.Value = item.getID();
            command.Parameters.Add(param);*/
            command.CommandText = ("SELECT * FROM " + table + " WHERE " + idFeild + " = @id");
          
            reader = command.ExecuteReader();
            reader.Read();
            SetValues(item);
            reader.Close();
            con.Close();
        }

        public void Update(Item item)
        {
            con.Open();
            command.Parameters.Clear();
            Type type = item.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(item) != null) //if the property value is not null
                {
                    //if the current property is not the ID Field
                    if (!property.Name.Equals(idFeild, StringComparison.InvariantCultureIgnoreCase))
                    {
                        //use parameter for the user value - prevent SQL injection
                        command.Parameters.AddWithValue("@id", item.getID());
                        command.Parameters.AddWithValue("@value", property.GetValue(item));

                        //generate SQL Update string for the current property name and value
                        command.CommandText = "UPDATE " + table +
                            " SET " + property.Name + " = @value WHERE " + idFeild + " =  @id";
                        command.ExecuteNonQuery(); //execute command; update the database
                        command.Parameters.Clear(); //clear parameter for next iteration of loop
                    }
                }
            }
            con.Close();
        }

        /*builds an Add string from the Item Properties collection 
        and uses it to add a new Item to the database */
        public void Add(Item item)
        {
            con.Open();
            command.CommandText = "SELECT * FROM " + table;
            reader = command.ExecuteReader(CommandBehavior.KeyInfo);
            DataTable schemaTable = reader.GetSchemaTable();
            reader.Close();

            command.Parameters.Clear();
            Type type = item.GetType();
            PropertyInfo[] properties = type.GetProperties();
            int count = 0;
            //create the first part of the Add SQL string
            string addString = "INSERT INTO " + table + "(";

            //add each item property name to the string
            foreach (PropertyInfo property in properties)
            {
                if (!schemaTable.Rows[count]["IsAutoIncrement"].ToString().Equals("True"))
                {
                    addString += property.Name;
                    count++;
                    //add a comma until end of Properties collection is reached
                    if (count < properties.Count())
                    { addString += ", "; }
                }
                else
                {
                    count++;
                }
            }


            //start second part of Add string
            addString += ") VALUES(";
            count = 0;
            int paramCounter = 1;
            //add each item property value to the string
            foreach (PropertyInfo property in properties)
            {
                if (!schemaTable.Rows[count]["IsAutoIncrement"].ToString().Equals("True"))
                {
                    if (property.GetValue(item) != null)
                    {
                        command.Parameters.AddWithValue("@" + paramCounter, property.GetValue(item));
                        addString += "@" + paramCounter; //insert parameter in string
                        paramCounter++;
                    }
                    else
                    { addString += "NULL"; }
                    count++;
                    //add a comma until end of Properties collection is reached
                    if (count < properties.Count())
                    { addString += ", "; }
                }
                else
                {
                    count++;
                }
            }
            //add bracket at end of Add string
            addString += ")";

            command.CommandText = addString;
            try
            { command.ExecuteNonQuery(); }
            catch (SqlException ex)
            {
                item.setVaild(false);
                item.setErrorMessage(ex.Message);
            }
            con.Close();
        }

        public void Delete(Item item)
        {
            con.Open();
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@id", item.getID());
            command.CommandText = "DELETE FROM " + table +
                " WHERE " + idFeild + " = @id";
            try { command.ExecuteNonQuery(); }
            catch (SqlException ex)
            {
                item.setVaild(false);
                item.setErrorMessage(ex.Message);
            }
            con.Close();
        }

        //used to check if the forgin key is realted to another table before deleting
        public bool CheckChildRecord(string column, string value)
        {
            bool exsist = false;
            //open Connection
            con.Open();
            int number;
            //Add PArameters
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@column", column);
            command.Parameters.AddWithValue("@value", value);
            //creating SQL statment
            command.CommandText = "SELECT COUNT(*) FROM " + table + " WHERE   @column = @value";


            // puting the value in a valrabile
            number = (int)command.ExecuteScalar();
            //chech if number = 0 or not 
            if (number == 0)
            {
                exsist = false;

            }
            else
            {
                exsist = true;
            }
            //return thr condition
            return exsist;
        }
        // good for finding the total earning for all orders or total expanses.
        public Double TotalValue(string columnName)
        {
            double value = 0;
            con.Open();
            command.CommandText = "SELECT SUM(" + columnName + ") FROM " + table;

            if (command.ExecuteScalar() != DBNull.Value)
            {
                value = Convert.ToDouble(command.ExecuteScalar());
            }
            con.Close();
            return value;
        }
        //good for finding the total earning based on one criteria
        public Double TotalValue(string columnName, string columnName1, string value1)
        {
            double value = 0;
            con.Open();
            command.CommandText = "SELECT SUM(" + columnName + ") FROM " + table +
                " WHERE " + columnName1 + " = '" + value1 + "'";
            if (command.ExecuteScalar() != DBNull.Value)
            {
                value = Convert.ToDouble(command.ExecuteScalar());
            }
            con.Close();
            return value;
        }
        //getting the total number of record for a certin table. for example: total number of customrs/orders
        public int totalCount(string columnName)
        {
            int total = 0;
            con.Open();
            command.CommandText = "SELECT COUNT(" + columnName + ") FROM " + table;
            total = Convert.ToInt32(command.ExecuteScalar());
            if (command.ExecuteScalar() != DBNull.Value)
            {
                total = Convert.ToInt32(command.ExecuteScalar());
            }
            con.Close();
            return total;
        }

        //getting the total record form a table base on a certin criteria. for example: number of books form a ceritn puublisher
        public int totalCount(string columnName, string columnName1, string value1)
        {
            int total = 0;
            con.Open();
            command.CommandText = "SELECT COUNT(" + columnName + ") FROM " + table +
                " WHERE " + columnName1 + " = '" + value1 + "'";
            total = Convert.ToInt32(command.ExecuteScalar());
            if (command.ExecuteScalar() != DBNull.Value)
            {
                total = Convert.ToInt32(command.ExecuteScalar());
            }

            con.Close();
            return total;
        }
        // getting the total record form a table base on 2 certin criteria. for example: number of books form a ceritn auther and a  puublisher
        public int totalCount(string columnName, string columnName1, string value1, string columnName2, string value2)
        {
            int total = 0;
            con.Open();
            command.CommandText = "SELECT COUNT(" + columnName + ") FROM " + table +
                " WHERE " + columnName1 + " = '" + value1 + "' AND " + columnName2 + " ='" + value2 + "'";
            total = Convert.ToInt32(command.ExecuteScalar());
            if (command.ExecuteScalar() != DBNull.Value)
            {
                total = Convert.ToInt32(command.ExecuteScalar());
            }
            con.Close();
            return total;
        }
        //getting data in a period of time. for exapmle: orders between two dates.
        public int totalCountDate(string columnName, string columnName1, string value1, string columnName2, string value2)
        {
            int total = 0;
            con.Open();
            command.CommandText = "SELECT COUNT(" + columnName + ") FROM " + table +
               " WHERE " + columnName1 + " >= '" + value1 + "' AND " + columnName2 + " <= '" + value2 + "'";
            total = Convert.ToInt32(command.ExecuteScalar());
            if (command.ExecuteScalar() != DBNull.Value)
            {
                total = Convert.ToInt32(command.ExecuteScalar());
            }
            con.Close();
            return total;
        }

        //getting data in a period of time. for exapmle: orders between two dates for a certin customer
        public int totalCount(string columnName, string columnName1, string value1, string columnName2, string value2, string columnName3, string value3)
        {
            int total = 0;
            con.Open();
            command.CommandText = "SELECT COUNT(" + columnName + ") FROM " + table +
               " WHERE " + columnName1 + " >= '" + value1 + "' AND " + columnName2 + " <= '" + value2 + "' AND " + columnName3 + "='" + value3 + "'";
            total = Convert.ToInt32(command.ExecuteScalar());
            if (command.ExecuteScalar() != DBNull.Value)
            {
                total = Convert.ToInt32(command.ExecuteScalar());
            }
            con.Close();
            return total;
        }

    }
}
