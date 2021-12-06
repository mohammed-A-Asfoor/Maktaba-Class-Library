using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Maktaba_Class_Library
{
    public class DataListJoin :Datalist
    {
        private string idFieldJoin;

        public DataListJoin(string table, string idField, string idFieldJoin)
            : base(table, idField)
        {
            this.idFieldJoin = idFieldJoin;
        }

        public void Populate(ItemJoin item)
        {
            Con.Open();
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("@id", item.getID());
            Command.Parameters.AddWithValue("@idJoin", item.getIdJoin());
            Command.CommandText = "SELECT * FROM " + Table + " WHERE " + IdFeild + " = @id" +
                " AND " + idFieldJoin + " = @idJoin";
            Reader = Command.ExecuteReader();
            Reader.Read();
            SetValues(item);
            Reader.Close();
            Con.Close();
        }

        public void Update(ItemJoin item)
        {
            Con.Open();
            Command.Parameters.Clear();
            Type type = item.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(item) != null) //if the property value is not null
                {
                    //if the current property is not the ID Field
                    if (!property.Name.Equals(IdFeild, StringComparison.InvariantCultureIgnoreCase))
                    {
                        //use parameter for the user value - prevent SQL injection
                        Command.Parameters.AddWithValue("@id", item.getID());
                        Command.Parameters.AddWithValue("@idJoin", item.getIdJoin());
                        Command.Parameters.AddWithValue("@value", property.GetValue(item));

                        //generate SQL Update string for the current property name and value
                        Command.CommandText = "UPDATE " + Table +
                           " SET " + property.Name + " = @value WHERE " + IdFeild + " =  @id" +
                           " AND " + idFieldJoin + " = @idJoin";
                        Command.ExecuteNonQuery(); //execute command; update the database
                        Command.Parameters.Clear(); //clear parameter for next iteration of loop
                    }
                }
            }
            Con.Close();
        }

        public void Delete(ItemJoin item)
        {
            Con.Open();
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("@id", item.getID());
            Command.Parameters.AddWithValue("@idJoin", item.getIdJoin());
            Command.CommandText = "DELETE FROM " + Table + "WHERE " + IdFeild + " = @id" +
                " AND " + idFieldJoin + " = @idjoin";

            try { Command.ExecuteNonQuery(); }
            catch (SqlException ex)
            {
                item.setVaild(false);
                item.setErrorMessage(ex.Message);

            }
            Con.Close();
        }
        public void Deletespecial(ItemJoin item)
        {
            Con.Open();
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("@id", item.getID());
            Command.Parameters.AddWithValue("@idJoin", item.getIdJoin());
            Command.CommandText = "DELETE FROM " + Table + "WHERE " + IdFeild + " = @id";

            try { Command.ExecuteNonQuery(); }
            catch (SqlException ex)
            {
                item.setVaild(false);
                item.setErrorMessage(ex.Message);

            }
            Con.Close();
        }
    }
}
