using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AlbumAssemblies
{
    public class AlbumDB
    {
        string strConnection;

        public AlbumDB()
        {
            getCoonectionString();
        }
        public string getCoonectionString()
        {
            strConnection = @"server=DESKTOP-8PA8D34;database=PE05;uid=sa;pwd=admin";
            return strConnection;
        }

        public List<Album> GetProductList()
        {
            List<Album> list = null;
            string sql = "select * from Albums";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);


            DataTable dtProduct = new DataTable();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Album p = new Album()
                        {
                            AlbumID = Int32.Parse(reader["AlbumID"].ToString()),
                            AlbumName = reader["AlbumName"].ToString(),
                            ReleaseYear = Int32.Parse(reader["ReleaseYear"].ToString()),
                            Quantity = Int32.Parse(reader["Quantity"].ToString()),
                            Status = Int32.Parse(reader["Status"].ToString()),
                        };
                        if (list == null)
                        {
                            list = new List<Album>();
                        }
                        list.Add(p);
                    }
                }
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return list;
        }

        public bool AddNewProduct(Album p)
        {
            bool result;
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "INSERT INTO Albums values(@ID,@Name,@Age,@Address,@Status)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", p.AlbumID);
            cmd.Parameters.AddWithValue("@Name", p.AlbumName);
            cmd.Parameters.AddWithValue("@Age", p.ReleaseYear);
            cmd.Parameters.AddWithValue("@Address", p.Quantity);
            cmd.Parameters.AddWithValue("@Status", p.Status);

            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool UpdateProduct(Album p)
        {
            bool result;
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "UPDATE Albums SET AlbumName=@Name,ReleaseYear=@Age,Quantity=@Address,Status=@Status WHERE AlbumID=@ID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", p.AlbumID);
            cmd.Parameters.AddWithValue("@Name", p.AlbumName);
            cmd.Parameters.AddWithValue("@Age", p.ReleaseYear);
            cmd.Parameters.AddWithValue("@Address", p.Quantity);
            cmd.Parameters.AddWithValue("@Status", p.Status);

            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool RemoveProduct(int ProductID)
        {
            bool result;
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "DELETE Albums  WHERE AlbumID=@ID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", ProductID);

            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public Album FindProduct(int ProductID)
        {
            Album pro = null;
            string sql = "select * from Albums Where AlbumID=@ID";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@ID", ProductID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtProduct = new DataTable();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        pro = new Album()
                        {
                            AlbumID = Int32.Parse(reader["AlbumID"].ToString()),
                            AlbumName = reader["AlbumName"].ToString(),
                            ReleaseYear = Int32.Parse(reader["ReleaseYear"].ToString()),
                            Quantity = Int32.Parse(reader["Quantity"].ToString()),
                            Status = Int32.Parse(reader["Status"].ToString()),
                        };

                    }
                }
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return pro;
        }
    }
}
