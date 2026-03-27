using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace library
{
    public class CADProduct
    {
        private string constring;

        public CADProduct()
        {
            constring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public bool Create(ENProduct en)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    string query = "INSERT INTO Products (name, code, amount, price, category, creationDate) VALUES (@name, @code, @amount, @price, @category, @creationDate)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", en.Name);
                    cmd.Parameters.AddWithValue("@code", en.Code);
                    cmd.Parameters.AddWithValue("@amount", en.Amount);
                    cmd.Parameters.AddWithValue("@price", en.Price);
                    cmd.Parameters.AddWithValue("@category", en.Category);
                    cmd.Parameters.AddWithValue("@creationDate", en.CreationDate);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool Update(ENProduct en)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    string query = "UPDATE Products SET name=@name, amount=@amount, price=@price, category=@category, creationDate=@creationDate WHERE code=@code";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", en.Name);
                    cmd.Parameters.AddWithValue("@code", en.Code);
                    cmd.Parameters.AddWithValue("@amount", en.Amount);
                    cmd.Parameters.AddWithValue("@price", en.Price);
                    cmd.Parameters.AddWithValue("@category", en.Category);
                    cmd.Parameters.AddWithValue("@creationDate", en.CreationDate);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool Delete(ENProduct en)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    string query = "DELETE FROM Products WHERE code=@code";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@code", en.Code);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool Read(ENProduct en)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    string query = "SELECT * FROM Products WHERE code=@code";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@code", en.Code);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        en.Name = reader["name"].ToString();
                        en.Amount = (int)reader["amount"];
                        en.Price = (float)(double)reader["price"];
                        en.Category = (int)reader["category"];
                        en.CreationDate = (DateTime)reader["creationDate"];
                        return true;
                    }
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool ReadFirst(ENProduct en)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    string query = "SELECT TOP 1 * FROM Products ORDER BY code ASC";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        en.Code = reader["code"].ToString();
                        en.Name = reader["name"].ToString();
                        en.Amount = (int)reader["amount"];
                        en.Price = (float)(double)reader["price"];
                        en.Category = (int)reader["category"];
                        en.CreationDate = (DateTime)reader["creationDate"];
                        return true;
                    }
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool ReadNext(ENProduct en)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    string query = "SELECT TOP 1 * FROM Products WHERE code > @code ORDER BY code ASC";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@code", en.Code);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        en.Code = reader["code"].ToString();
                        en.Name = reader["name"].ToString();
                        en.Amount = (int)reader["amount"];
                        en.Price = (float)(double)reader["price"];
                        en.Category = (int)reader["category"];
                        en.CreationDate = (DateTime)reader["creationDate"];
                        return true;
                    }
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public bool ReadPrev(ENProduct en)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    string query = "SELECT TOP 1 * FROM Products WHERE code < @code ORDER BY code DESC";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@code", en.Code);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        en.Code = reader["code"].ToString();
                        en.Name = reader["name"].ToString();
                        en.Amount = (int)reader["amount"];
                        en.Price = (float)(double)reader["price"];
                        en.Category = (int)reader["category"];
                        en.CreationDate = (DateTime)reader["creationDate"];
                        return true;
                    }
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }
    }
}