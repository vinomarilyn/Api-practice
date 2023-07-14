using Heladeria.Models;
using System.Data;
using System.Data.SqlClient;

namespace Heladeria.DataAccess
{
    public class SaboresRepository
    {
        public List<Sabor> GetAll()
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=HeladeriaDb;Integrated Segurity=True";
            // create a new sqlconnection object
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                //open the database connection
                connection.Open();
                string query = "SELECT * FROM Sabores";
                //create a sqlcommand object to execute the sql qury
                using (SqlCommand command = new SqlCommand(query, connection)) 
                {
                    //create a sql datareades object to read the data from the sql query
                    using (SqlDataReader reader = command.ExecuteReader()) 
                    {
                        //load the data into the datatable
                        dataTable.Load(reader);
                    }
                }
                //close the database connection
                connection.Close();
            }
            // mapeamos un datatable a una lista de sabores
            var sabor = BindDataList<Sabor>(dataTable);
            return sabor;
        }
        public List<T> BindDataList<T>(DataTable dt)
        {
            List<string> columns = new List<string>();
            foreach (DataColumn dc  in dt.Columns) 
            {
                columns.Add(dc.ColumnName);
            }
            var fields = typeof(T).GetFields();
            var properties = typeof(T).GetProperties();
            List<T> lst = new List<T>();
            foreach (DataRow dr in dt.Rows)
            {
                var ob = Activator.CreateInstance<T>();
                foreach (var fieldInfo in fields) 
                {
                    if (columns.Contains(fieldInfo.Name))
                    {
                        fieldInfo.SetValue(ob, dr[fieldInfo.Name]);
                    }
                }
                foreach (var propertyInfo in properties)
                {
                    if (columns.Contains(propertyInfo.Name))
                    {
                        propertyInfo.SetValue(ob, dr[propertyInfo.Name]);
                    }
                }
                lst.Add(ob);
            
            }
            return lst;
        }
    }
}