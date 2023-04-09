using BM_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace BM_Multi_AC_Roles.Data
{
    public class ClientUserDataContext : IdentityDbContext<IdentityUser>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IConfiguration Configuration { get; }
        public static string ConnectionString { get; private set; }



        public ClientUserDataContext(string connectionString) : base(GetOptions(connectionString))
        {
            //var FirstConnectionString = this.Configuration.GetConnectionString("FirstHalfConnection");
            //var lastConnectionString = this.Configuration.GetConnectionString("LastHalfConnection");

            //ConnectionString = FirstConnectionString + connectionString + lastConnectionString;

            //Database.EnsureCreated();
            //ConnectionString = connectionString;


            Database.Migrate();
        }

        private static DbContextOptions GetOptions( string cs)
        {

            ConnectionString = cs;
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), ConnectionString).Options;
        }


        public ClientUserDataContext(DbContextOptions<ClientUserDataContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
            //Database.EnsureCreated();
            base.OnConfiguring(optionsBuilder);


            //var path = _httpContextAccessor.HttpContext.Request.Path.Value;
            // var name = path.Split('/')[1];
            //optionsBuilder.UseSqlServer($"Data Source={name}.db");
            //ConnectionString = name;

            //var FirstConnectionString = this.Configuration.GetConnectionString("FirstHalfConnection");
            //var lastConnectionString = this.Configuration.GetConnectionString("LastHalfConnection");
            //if (!string.IsNullOrEmpty(ConnectionString))
            //{
            //    //var CS = "";

            //    //CS = FirstConnectionString + ConnectionString + lastConnectionString;
            //    optionsBuilder.UseSqlServer(ConnectionString);
            //    Database.EnsureCreated();
            //base.OnConfiguring(optionsBuilder);
            //}
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            string ADMIN_ID = Guid.NewGuid().ToString();
            string ROLE_ID =  Guid.NewGuid().ToString();

            //seed admin role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            //create user
            var appUser = new IdentityUser()
            {
                Id = ADMIN_ID,
                Email = "admin@admin.com",
                EmailConfirmed = true,
           
                UserName = "admin"
           };

            //set user password
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "dmin*123");

            //seed user
            builder.Entity<IdentityUser>().HasData(appUser);

            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });


            base.OnModelCreating(builder);
           // this.SeedUsers(builder);
           // this.SeedRoles(builder);
            //this.SeedUserRoles(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            IdentityUser user = new IdentityUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "Admin",
                Email = "admin@admin",
                LockoutEnabled = false,

            };

            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            passwordHasher.HashPassword(user, "Admin*123");

            builder.Entity<IdentityUser>().HasData(user);
        }
      
        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
               new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
               );
        }
    }
}

