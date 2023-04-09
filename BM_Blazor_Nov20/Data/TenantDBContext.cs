using BM_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BM_Blazor_Nov20.Data
{
    public class TenantDBContext : DbContext
    {
        public static string ConnectionString
        {
            get;
            set;
        }

        public TenantDBContext() { Database.EnsureCreated();
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


            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<Company> Companies       { get;      set; }

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


       

    }
}
