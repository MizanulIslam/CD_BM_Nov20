using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BM_Multi_AC_Roles.Data;
using Microsoft.EntityFrameworkCore;
using BM_Multi_AC_Roles.Services;
using Microsoft.AspNetCore.Identity;

namespace BM_Multi_AC_Roles.Pages
{
    public class MainPageBase : ComponentBase
    {
        [Parameter]
        public string value { get; set; }

        [Parameter]
        public string id { get; set; }
        public string test { get; set; }

        [Inject]
        ClientUserDataContext contextDb { get; set; }

        [Inject]
        ApplicationDbContext appContextDb { get; set; }

        public MainPageBase(ApplicationDbContext applicationDbContext)
        {
            appContextDb = applicationDbContext;
        }

        public MainPageBase()
        {

        }
        GetConString objConString = new GetConString();
     

        protected override void OnParametersSet()
        {
            //the param will be set now

            test = value;

            var cid = ClientLoad();


            var cs = objConString.getConnectionString(cid);

            contextDb = new ClientUserDataContext($"{cs}");

            var sr = SeedDataInitialAsync();

            //appContextDb.Clients


            // var cs = objConString.getConnectionString(id);

            //contextDb = new ClientUserDataContext($"{cs}");


        }

       // [Inject]
        //private IDbContextFactory<ApplicationDbContext> ContextFactory { get; set; }

//      public MainPageBase(IDbContextFactory<ApplicationDbContext> contextFactory) => ContextFactory = contextFactory;

        protected string ClientLoad()
        {
            //using (var context = ContextFactory.CreateDbContext())
            //{
            //    string cid = null;
            //    var client = context.Clients.Where(x => x.UserName == test).FirstOrDefault();
            //    if (client.ExtraColumn1 == "EmailConfirmed")
            //    {
            //        cid = client.ConnectionString;

            //    }
            //    return cid;
            //}

            string cid = null;
            var client = appContextDb.Clients.Where(x => x.UserName == test).FirstOrDefault();
            if (client.ExtraColumn1 == "EmailConfirmed")
            {
                cid = client.ConnectionString;

            }
            return cid;




        }

        [Inject]
        public IUserServices objUserServices { get; set; }
            public IdentityUser objUser { get; set; }
        public IdentityRole objRole { get; set; }
        [Inject]
        public UserManager<IdentityUser> uManager { get; set; }
        [Inject]
        public RoleManager<IdentityRole> rManager { get; set; }


        protected async Task<string> SeedDataInitialAsync()
        {
            var client = appContextDb.Clients.Where(x => x.UserName == test).FirstOrDefault();

            var done = "empty";
            if (string.IsNullOrEmpty(client.ExtraColumn3) || (!(client.ExtraColumn3.Contains("seeded")) ))
            { 
                
                //USER Seed
                //objUser.UserName = "adminuser";

                var user = await uManager.FindByNameAsync("adminuser");
                if (user == null)
                {
                    objUser = new IdentityUser
                    {
                        UserName = "adminuser",
                        EmailConfirmed = true,

                    };


                    var resultUser = await uManager.CreateAsync(objUser, "Admin*123");
                    if (resultUser.Succeeded)
                    {
                        done = "userSeeded";
                    }



                }
                //password seed

                //var user1 = await uManager.FindByNameAsync("adminUser");
                //if (user1 != null)
                //{

                //    var resultUser = uManager.AddPasswordAsync(user1, "Admin*123");

                //    if (resultUser.Result.Succeeded)
                //    {
                //        done = "userSeeded";
                //    }


                //}

                //Role Seed

                var role = await rManager.FindByNameAsync("admin");
                if (role == null)
                {
                    objRole = new IdentityRole
                    {
                        Name = "admin",
                    };


                    var resultRole = await rManager.CreateAsync(objRole);

                    if (resultRole.Succeeded)
                    {
                        done += " roleSeeded";
                    }
                }

                var userRole = await uManager.GetRolesAsync(objUser);
                if ((userRole ==null )|| (!userRole.Contains("admin")))
                {
                    var uResult = await uManager.AddToRoleAsync(objUser, "admin");

                    if (uResult.Succeeded)
                    {
                        done += " userRoleSeeded";
                    }
                }

                
            }
            //else if (!client.ExtraColumn3.Contains("seeded"))
            //    {

            //    objUser.UserName = "adminuser";

            //    var user = await uManager.FindByNameAsync("adminuser");
            //    if (user == null)
            //    {
            //        await uManager.CreateAsync(objUser);
            //        var user1 = await uManager.FindByNameAsync("adminUser");
            //        if (user1 != null)
            //        {

            //            var resultUser = uManager.AddPasswordAsync(user1, "Admin*123");

            //            if (resultUser.Result.Succeeded)
            //            {
            //                done = "userSeeded";
            //            }


            //        }
            //    }

            //    //Role Seed
            //    objRole.Name = "admin";

            //    var resultRole = await rManager.CreateAsync(objRole);

            //    if (resultRole.Succeeded)
            //    {
            //        done += " roleSeeded";
            //    }



            //}


            if(done.Contains("userSeeded") && done.Contains("roleSeeded") && done.Contains("userRoleSeeded"))
            {
                client.ExtraColumn3 = "seeded";
                appContextDb.Update(client);
                appContextDb.SaveChanges();
                
            }

           
            
            return "";
        }
    }
}
