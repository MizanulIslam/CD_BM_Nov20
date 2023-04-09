using AutoMapper;
using BM_Blazor_Nov20.Areas.Identity;
using BM_Blazor_Nov20.Data;
using BM_Blazor_Nov20.Mapper;
using BM_Blazor_Nov20.Models;
using BM_Models;
using BM_Models.Validator;
using BM_Blazor_Nov20.Services;
using FluentValidation;
//using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BM_Blazor_Nov20
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);

            services.AddDbContext<ClientListDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("BM_CLientListConnection")), ServiceLifetime.Singleton);

            services.AddDbContext<TenantDBContext>((ServiceLifetime.Scoped));
            services.AddHttpContextAccessor();

            services.AddAuthentication("Identity.Applicaion").AddCookie();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            services.AddServerSideBlazor(c => c.DetailedErrors = true);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                  .AddRazorPagesOptions(options =>
                  {

                      options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                      options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
                  });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

            //services.AddHttpClient<IEmployeeServices, EmployeeServices>(client =>
            //{
            //    client.BaseAddress = new Uri("https://localhost:44347/");
            //});
            services.AddTransient<IValidator<Employee>, EmployeeValidator>();

            services.AddScoped<IEmployeeServices, EmployeeServicesBazor>();


            services.AddAutoMapper(typeof(EmployeeProfile));
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();

            services.AddScoped<CompanyServices>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                     
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
