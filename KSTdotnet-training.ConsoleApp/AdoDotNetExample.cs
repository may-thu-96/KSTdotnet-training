using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSTdotnet_training.ConsoleApp
{
    public class AdoDotNetExample
    {
        private readonly string _connectionString = "Data Source=DESKTOP-AQCT4ER\\MSSQLSERVER2016;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa;TrustServerCertificate=true;";

        public void Read()
        {
            Console.WriteLine("Connection String :" + _connectionString);
            SqlConnection connection = new SqlConnection(_connectionString);

            Console.WriteLine("Connection opening...");
            connection.Open();

            Console.WriteLine("Connection opened...");

            string query = $@"SELECT [BlogID]
                          ,[BlogTitle]
                          ,[BlogAuthor]
                          ,[BlogContent]
                          ,[DeleteFlag]
                      FROM [dbo].[Tbl_Blog] where DeleteFlag=0";

            SqlCommand cmd = new SqlCommand(query, connection);
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["BlogID"]);
                Console.WriteLine(reader["BlogTitle"]);
                Console.WriteLine(reader["BlogAuthor"]);
                Console.WriteLine(reader["BlogContent"]);
                // Console.WriteLine(dr["DeleteFlag"]);

            }

            Console.WriteLine("Connection closing...");

            connection.Close();

            Console.WriteLine("Connection closed...");
            //foreach (DataRow dr in dt.Rows)
            //{
            //    Console.WriteLine(dr["BlogID"]);
            //    Console.WriteLine(dr["BlogTitle"]);
            //    Console.WriteLine(dr["BlogAuthor"]);
            //    Console.WriteLine(dr["BlogContent"]);
            //    Console.WriteLine(dr["DeleteFlag"]); 
            //}
            Console.ReadKey();
        }

        public void Create()
        {
            Console.WriteLine("BlogTitle:");
            string title = Console.ReadLine();

            Console.WriteLine("BlogAuthor:");
            string author = Console.ReadLine();

            Console.WriteLine("BlogContent:");
            string content = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            //       string query = $@"INSERT INTO [dbo].[Tbl_Blog]
            //      ([BlogTitle]
            //      ,[BlogAuthor]
            //      ,[BlogContent]
            //      ,[DeleteFlag])
            //VALUES
            //      ('{title}'
            //      ,{author}
            //      ,{content}
            //      ,0)";

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent
           ,0)";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            int result = cmd.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine(result == 1 ? "Saving Successful" : "Saving Failed");

            Console.ReadKey();
        }

        public void Edit()
        {
            Console.Write("BlogID:");
            string blogID = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = $@"SELECT [BlogID]
                              ,[BlogTitle]
                              ,[BlogAuthor]
                              ,[BlogContent]
                              ,[DeleteFlag]
                          FROM [dbo].[Tbl_Blog] 
                          where DeleteFlag=0 and BlogID=@BlogID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogID", blogID);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No Data Found.");

            }
            else
            {
                DataRow dr = dt.Rows[0];
                Console.WriteLine(dr["BlogID"]);
                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);
            }
             
            connection.Close();

        }

        public void Update()
        {
            Console.WriteLine("BlogID:");
            string blogID = Console.ReadLine();

            Console.WriteLine("BlogTitle:");
            string title = Console.ReadLine();

            Console.WriteLine("BlogAuthor:");
            string author = Console.ReadLine();

            Console.WriteLine("BlogContent:");
            string content = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = $@"UPDATE [dbo].[Tbl_Blog]
                           SET [BlogTitle] = @BlogTitle
                              ,[BlogAuthor] = @BlogAuthor
                              ,[BlogContent] = @BlogContent 
                           Where BlogID=@BlogID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogID", blogID);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine(result == 1 ? "Update Successful" : "Update Failed");

            Console.ReadKey();

        }

        public void Delete()
        {
            Console.Write("BlogID:");
            string blogID = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = $@"DELETE FROM [dbo].[Tbl_Blog]
            WHER   BlogID=@BlogID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogID", blogID);

            int result = cmd.ExecuteNonQuery();

            Console.WriteLine(result==1 ? "Delete Successful." : "Delete Failed");

            connection.Close();

            Console.ReadLine();
        }
    }
}
