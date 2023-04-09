using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BM_Models;
using Microsoft.EntityFrameworkCore;

namespace BM_Api_Data
{
    public class TenantDBContext : DbContext
    {
        public static string ConnectionString
        {
            get;
            set;
        }

        public TenantDBContext()
        {
            Database.EnsureCreated();
        }
        public TenantDBContext(DbContextOptions<TenantDBContext> options) : base(options)
        {


        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(ConnectionString))
            {
                var CS = "Server = (localdb)\\mssqllocaldb; Database = BM - Blazor - Tenant - ";
                CS = CS + ConnectionString + ";Trusted_Connection=True;MultipleActiveResultSets=true";
                optionsBuilder.UseSqlServer(CS);
            }
            else
            {
                var CS = "Server = (localdb)\\mssqllocaldb; Database = BM - Blazor - Tenant - ";
                CS = CS + "test-123456789"+ ";Trusted_Connection=True;MultipleActiveResultSets=true";
                optionsBuilder.UseSqlServer(CS);
            }


            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<Company> Companies { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Items> Order_Items { get; set; }
        public DbSet<SubTax> SubTaxes { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<TaxType> TaxTypes { get; set; }
        public DbSet<SaleInvoice> SaleInvoices { get; set; }
        public DbSet<SaleInvoice_Items> SaleInvoice_Items { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Departments Table
         
            // Seed Employee Table
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = Guid.NewGuid().ToString(),
                FirstName = "John",
                LastName = "Hastings",
                EmailID = "David@pragimtech.com",
                BirthDate = new DateTime(1980, 10, 5),
                //Gender = Gender.Male,
               
                PhotoPath = "images/john.png"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = Guid.NewGuid().ToString(),
                FirstName = "Sam",
                LastName = "Galloway",
                EmailID = "Sam@pragimtech.com",
                BirthDate = new DateTime(1981, 12, 22),
                //Gender = Gender.Male,
                PhotoPath = "images/sam.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = Guid.NewGuid().ToString(),
                FirstName = "Mary",
                LastName = "Smith",
                EmailID = "mary@pragimtech.com",
                BirthDate = new DateTime(1979, 11, 11),
                //Gender = Gender.Female,
                PhotoPath = "images/mary.png"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = Guid.NewGuid().ToString(),
                FirstName = "Sara",
                LastName = "Longway",
                EmailID = "sara@pragimtech.com",
                BirthDate = new DateTime(1982, 9, 23),
                //Gender = Gender.Female,
                PhotoPath = "images/sara.png"
            });
        }

    }
}
