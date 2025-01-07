using KSTdotnet_training.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSTdotnet_training.ConsoleApp
{
    public class AdoDotNetExample2
    {
        private readonly string _connectionString = "Data Source=DESKTOP-AQCT4ER\\MSSQLSERVER2016;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa;TrustServerCertificate=true;";

        private readonly AdoDotNetService _adoDotNetService;

        public AdoDotNetExample2()
        {
            _adoDotNetService = new AdoDotNetService(_connectionString);
        }

        public void Read()
        {
            string query = $@"SELECT [BlogID]
                          ,[BlogTitle]
                          ,[BlogAuthor]
                          ,[BlogContent]
                          ,[DeleteFlag]
                      FROM [dbo].[Tbl_Blog] where DeleteFlag=0";

            DataTable dt = _adoDotNetService.Qurey(query);

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["BlogID"]);
                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);
                Console.WriteLine(dr["DeleteFlag"]);
            }

        }

        public void Create()
        {
            Console.WriteLine("BlogTitle:");
            string title = Console.ReadLine();

            Console.WriteLine("BlogAuthor:");
            string author = Console.ReadLine();

            Console.WriteLine("BlogContent:");
            string content = Console.ReadLine();

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

            int result = _adoDotNetService.Execute(query
                , new SqlParameterModel { Name = "@BlogTitle", Value = title }
                , new SqlParameterModel { Name = "@BlogAuthor", Value = author }
                , new SqlParameterModel { Name = "@BlogContent", Value = content }
                );

            Console.WriteLine(result == 1 ? "Saving Successful" : "Saving Failed");


        }

        public void Edit()
        {
            Console.Write("BlogID:");
            string blogID = Console.ReadLine();


            string query = $@"SELECT [BlogID]
                              ,[BlogTitle]
                              ,[BlogAuthor]
                              ,[BlogContent]
                              ,[DeleteFlag]
                          FROM [dbo].[Tbl_Blog] 
                          where DeleteFlag=0 and BlogID=@BlogID";


            DataTable dt = _adoDotNetService.Qurey(query, new SqlParameterModel
            {
                Name = "@BlogID",
                Value = blogID
            }
            );

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



            string query = $@"UPDATE [dbo].[Tbl_Blog]
                           SET [BlogTitle] = @BlogTitle
                              ,[BlogAuthor] = @BlogAuthor
                              ,[BlogContent] = @BlogContent 
                           Where BlogID=@BlogID";


            int result = _adoDotNetService.Execute(query
                  , new SqlParameterModel("@BlogTitle", title)
                  , new SqlParameterModel("@BlogAuthor", author)
                  , new SqlParameterModel("@BlogContent", content)
                  , new SqlParameterModel("@BlogContent", content)
                  );

            Console.WriteLine(result == 1 ? "Update Successful" : "Update Failed");


        }

        public void Delete()
        {
            Console.Write("BlogID:");
            string blogID = Console.ReadLine();



            string query = $@"DELETE FROM [dbo].[Tbl_Blog]
            where   BlogID=@BlogID";



            int result = _adoDotNetService.Execute(query, new SqlParameterModel("@BlogID", blogID));

            Console.WriteLine(result == 1 ? "Delete Successful." : "Delete Failed");

        }
    }
}
