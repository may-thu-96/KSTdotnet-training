using KSTdotnet_training.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSTdotnet_training.ConsoleApp
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=DESKTOP-AQCT4ER\\MSSQLSERVER2016;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa;TrustServerCertificate=true;";

            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<BlogDataModel> Blog { get; set; }

    }
}
