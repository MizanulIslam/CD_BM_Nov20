
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BM_Web.Models;

namespace BM_Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //this.User = User;
           // var cs = User.ConnectionString;
           
            Database.EnsureCreated();
            
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var CS = "Server = (localdb)\\mssqllocaldb; Database =  BM-Web-Tenant-MasterDatabase-Nov2020;";
            optionsBuilder.UseSqlServer(CS);
            
            base.OnConfiguring(optionsBuilder);
        }

       

       
        public ApplicationUser User { get; }
    }




    public partial class CompanyDbContext : DbContext
    {
        private string v;

        public CompanyDbContext() { }
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options) {
          
        }

        public CompanyDbContext(string v)
        {
             Database.EnsureCreated();
        }



        //public BlogDbContext(string connectionString) : base(GetOptions(connectionString)) { }

        public static string ConnectionString
        {
            get;
            set;
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //if (!optionsBuilder.IsConfigured)    
            //{    
        //    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.    
        //    if (!string.IsNullOrEmpty(ConnectionString))
        //    {
        //        var CS = "Server = (localdb)\\mssqllocaldb; Database =  BM-Web-Tenant-"+ ConnectionString;
        //        optionsBuilder.UseSqlServer(CS);
        //    }
        //    // }    
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(ConnectionString))
            {
            var CS = "Server = (localdb)\\mssqllocaldb; Database = BM - Web - Tenant - ";
                CS = CS+ ConnectionString;
            optionsBuilder.UseSqlServer(CS);
            }


            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<Company> Companies
        {
            get;
            set;
        }
    }

   

}
