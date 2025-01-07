using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KSTdotnet_training.DataBase.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAddress> TblAddresses { get; set; }

    public virtual DbSet<TblAttendanceLocation> TblAttendanceLocations { get; set; }

    public virtual DbSet<TblBird> TblBirds { get; set; }

    public virtual DbSet<TblBlog> TblBlogs { get; set; }

    public virtual DbSet<TblDepartment> TblDepartments { get; set; }

    public virtual DbSet<TblEmployee> TblEmployees { get; set; }

    public virtual DbSet<TblGeoFencing> TblGeoFencings { get; set; }

    public virtual DbSet<TblJob> TblJobs { get; set; }

    public virtual DbSet<TblTodo> TblTodos { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=DESKTOP-AQCT4ER\\MSSQLSERVER2016;Database=DotNetTraining;User Id=sa;Password=sasa;TrustServerCertificate=True;");
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Data Source=DESKTOP-AQCT4ER\\MSSQLSERVER2016;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa;TrustServerCertificate=true;";

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAddress>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK_Address");

            entity.ToTable("Tbl_Addresses");

            entity.Property(e => e.AddressId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Street).HasMaxLength(50);
            entity.Property(e => e.ZipCode).HasMaxLength(50);
        });

        modelBuilder.Entity<TblAttendanceLocation>(entity =>
        {
            entity.HasKey(e => e.AttendanceLocationId).HasName("PK_AttendanceLocations");

            entity.ToTable("Tbl_AttendanceLocations");

            entity.Property(e => e.AttendanceLocationId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.UserTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblBird>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Tbl_Birds_1");

            entity.ToTable("Tbl_Birds");

            entity.Property(e => e.BirdEnglishName).HasMaxLength(50);
            entity.Property(e => e.BirdMyanmarName).HasMaxLength(50);
            entity.Property(e => e.ImagePath).HasMaxLength(50);
        });

        modelBuilder.Entity<TblBlog>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("Tbl_Blog");

            entity.Property(e => e.BlogId).HasColumnName("BlogID");
            entity.Property(e => e.BlogAuthor).HasMaxLength(50);
            entity.Property(e => e.BlogTitle).HasMaxLength(50);
        });

        modelBuilder.Entity<TblDepartment>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK_Department");

            entity.ToTable("Tbl_Departments");

            entity.Property(e => e.DepartmentId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Floor).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TblEmployee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK_Employee");

            entity.ToTable("Tbl_Employees");

            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Job).HasMaxLength(500);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<TblGeoFencing>(entity =>
        {
            entity.HasKey(e => e.GeoFencingId).HasName("PK_GeoFencings");

            entity.ToTable("Tbl_GeoFencings");

            entity.Property(e => e.GeoFencingId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.Radius).HasColumnName("radius");
        });

        modelBuilder.Entity<TblJob>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PK_Job");

            entity.ToTable("Tbl_Jobs");

            entity.Property(e => e.JobId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DepartmentId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DepartmentID");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<TblTodo>(entity =>
        {
            entity.HasKey(e => e.TodoId).HasName("PK_ToDo");

            entity.ToTable("Tbl_Todos");

            entity.Property(e => e.TodoId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
