using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace WKTDotNetCore.ConsoleApp.AdoDotNetExamples
{
    internal class AdoDotNetExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-7NM9PQ7", //server name
            InitialCatalog = "DotNetTrainingBatch4", //DB Name
            UserID = "sa",
            Password = "sa@123"

        };

        public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            Console.WriteLine("Connection Open");

            string query = "select * from Tbl_Blog";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();
            Console.WriteLine("Connection Close");

            //dataset => datatable
            //datatable => datarow
            //datarow => datacolumn

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Blo Id => " + dr["BlogId"]);
                Console.WriteLine("Blo Title => " + dr["BlogTitle"]);
                Console.WriteLine("Blo Author => " + dr["BlogAuthor"]);
                Console.WriteLine("Blo Content => " + dr["BlogContent"]);
                Console.WriteLine("------------------------------------");
            }
        }
        public void Create(string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle,
            @BlogAuthor,
            @BlogContent)";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            Console.WriteLine(message);

        }
        public void Update(int id, string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"delete from Tbl_Blog where BlogId=@BlogID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);

            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            Console.WriteLine(message);
        }
        public void Edit(int id)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = "select * from Tbl_Blog where BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found.");
                return;
            }
            DataRow dr = dt.Rows[0];
            Console.WriteLine("Blo Id => " + dr["BlogId"]);
            Console.WriteLine("Blo Title => " + dr["BlogTitle"]);
            Console.WriteLine("Blo Author => " + dr["BlogAuthor"]);
            Console.WriteLine("Blo Content => " + dr["BlogContent"]);
            Console.WriteLine("------------------------------------");

        }
    }
}
