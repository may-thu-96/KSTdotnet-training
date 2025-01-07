// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using KSTdotnet_training.ConsoleApp;

//AdoDotNetExample adoDotNetExample=new AdoDotNetExample();
////adoDotNetExample.Read();
////adoDotNetExample.Create();
//adoDotNetExample.Delete();

DapperExample2 dapperExample = new DapperExample2();
dapperExample.Read();
//dapperExample.Create("aa","bb","cc");
//dapperExample.Delete(3);
//dapperExample.Delete(7);
//dapperExample.Update(3,"aa", "aa", "aa");
//dapperExample.Update(7, "bb", "bb", "bb");

//EFCoreExample eFCoreExample = new EFCoreExample();
////eFCoreExample.Read();
//eFCoreExample.Delete(3);
//eFCoreExample.Delete(9);
//Console.ReadKey();

//dotnet ef dbcontext scaffold "Server=DESKTOP-AQCT4ER\MSSQLSERVER2016;Database=DotNetTraining;User Id=sa;Password=sasa;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext   -f