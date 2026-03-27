using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    internal class CADCategory
    {

        private string constring;

        public CADCategory()
        {
            constring = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        }

        public bool read(ENCategory en)
        {
            bool ok = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    connection.Open();

                    string query = "SELECT id, name FROM Categories WHERE id = @id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", en.Id);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        en.Id = Convert.ToInt32(reader["id"]);
                        en.Name = reader["name"].ToString();
                        ok = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Category operation has failed. Error: {0}", ex.Message);
                ok = false;
            }

            return ok;
        }

        public List<ENCategory> readAll()
        {
            List<ENCategory> categories = new List<ENCategory>();

            try
            {
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    connection.Open();

                    string query = "SELECT id, name FROM Categories";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ENCategory category = new ENCategory();
                        category.Id = Convert.ToInt32(reader["id"]);
                        category.Name = reader["name"].ToString();
                        categories.Add(category);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Category operation has failed. Error: {0}", ex.Message);
            }

            return categories;
        }
    }
}
