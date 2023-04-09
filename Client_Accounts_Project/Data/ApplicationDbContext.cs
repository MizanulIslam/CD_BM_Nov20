using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client_Accounts_Project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public IConfiguration Configuration { get; }
        public static string ConnectionString
        {
            get;
            set;
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
          
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            var FirstConnectionString = this.Configuration.GetConnectionString("FirstHalfConnection");
            var lastConnectionString = this.Configuration.GetConnectionString("LastHalfConnection");
            if (!string.IsNullOrEmpty(ConnectionString))
            {
                var CS = "";

                CS = FirstConnectionString + ConnectionString + lastConnectionString;
                optionsBuilder.UseSqlServer(CS);
            }


            base.OnConfiguring(optionsBuilder);
        }
    }
}
