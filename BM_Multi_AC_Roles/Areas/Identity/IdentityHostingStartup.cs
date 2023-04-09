using System;
using BM_Multi_AC_Roles.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BM_Multi_AC_Roles.Areas.Identity.IdentityHostingStartup))]
namespace BM_Multi_AC_Roles.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ClientUserDataContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ClientUserDataContextConnection")));
                //services.AddDbContext<ClientUserDataContext>(ServiceLifetime.Scoped,ServiceLifetime.Singleton);

                services.AddIdentity<IdentityUser, IdentityRole>(
                    options => options.SignIn.RequireConfirmedAccount = true)
                .AddDefaultUI()
                .AddEntityFrameworkStores<ClientUserDataContext>()
                .AddDefaultTokenProviders();
               
                //services.AddDefaultIdentity<IdentityUser>(
                //    options => options.SignIn.RequireConfirmedAccount = true)
                //    .AddRoles<IdentityRole>()
                //    .AddEntityFrameworkStores<ClientUserDataContext>();
            });
        }
    }
}