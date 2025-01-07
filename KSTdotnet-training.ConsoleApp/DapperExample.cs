using Dapper;
using KSTdotnet_training.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSTdotnet_training.ConsoleApp
{
    public class DapperExample
    {
        private readonly string _connectionString = "Data Source=DESKTOP-AQCT4ER\\MSSQLSERVER2016;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa;TrustServerCertificate=true;";

        public void Read()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = $@"SELECT [BlogID]
                          ,[BlogTitle]
                          ,[BlogAuthor]
                          ,[BlogContent]
                          ,[DeleteFlag]
                      FROM [dbo].[Tbl_Blog] where DeleteFlag=0";
                var list = db.Query<BlogDapperDataModel>(query).ToList();
                foreach (var item in list)
                {
                    Console.WriteLine(item.BlogID);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                    Console.WriteLine(item.DeleteFlag);
                }
            }
        }

        public void Create(string title, string author, string content)
        {
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

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, new BlogDapperDataModel
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                });
                Console.WriteLine(result == 1 ? "Saving SuccessFul" : "Saving Failed");
            }
        }

        public void Edit(int blogId)
        {
            string query = $@"SELECT [BlogID]
                              ,[BlogTitle]
                              ,[BlogAuthor]
                              ,[BlogContent]
                              ,[DeleteFlag]
                          FROM [dbo].[Tbl_Blog] 
                          where DeleteFlag=0 and BlogID=@BlogID";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var list = db.QueryFirstOrDefault<BlogDapperDataModel>(query, new { BlogID = blogId });
                if (list is null)
                {
                    Console.WriteLine("No Data Found.");
                }
                else
                {
                    Console.WriteLine(list.BlogID);
                    Console.WriteLine(list.BlogTitle);
                    Console.WriteLine(list.BlogAuthor);
                    Console.WriteLine(list.BlogContent);
                    Console.WriteLine(list.DeleteFlag);
                }

            }
        }

        public void Update(int blogId, string title, string author, string content)
        {
            string query = $@"UPDATE [dbo].[Tbl_Blog]
                           SET [BlogTitle] = @BlogTitle
                              ,[BlogAuthor] = @BlogAuthor
                              ,[BlogContent] = @BlogContent 
                           Where BlogID=@BlogID";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, new BlogDapperDataModel
                {
                    BlogID = blogId,
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                });

                Console.WriteLine(result == 1 ? "Saving SuccessFul" : "Saving Failed");

            }

        }

        public void Delete(int blogId)
        {
            string query = $@"DELETE FROM [dbo].[Tbl_Blog]
            where   BlogID=@BlogID";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, new { BlogID = blogId });

                Console.WriteLine(result == 1 ? "Delete Successful." : "Delete Failed");
            }
        }
    }
}
