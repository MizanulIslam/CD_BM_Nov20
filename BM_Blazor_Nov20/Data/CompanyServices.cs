using BM_Blazor_Nov20.Data.LogicLayer;
using BM_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BM_Blazor_Nov20.Data
{
    public class CompanyServices
    {
        private static readonly string[] Summaries = new[]
       {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly UserManager<Models.ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly TenantDBContext _tenantDb;

        public CompanyServices(UserManager<Models.ApplicationUser> usermanager, IHttpContextAccessor httpContextAccessor, TenantDBContext tenantDB)
        {
            _userManager = usermanager;
            _httpContextAccessor = httpContextAccessor;
            _tenantDb = tenantDB;

        }

        public async Task<Company[]> GetCompanyAsync()

        {

            //var user = await userManager.GetUserAsync(User);

            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user = await _userManager.FindByNameAsync(userName);
            TenantDBContext.ConnectionString= user.ConnectionString;
            TenantDBContext tenantDB = new TenantDBContext();

            //ApplicationUser user = System.Web.HttpContext.C1urrent.GetOwinContext().GetUserManager<UserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            CompanyLL companyLL = new CompanyLL();

            //Company[] companies = await tenantDB.Companies.ToArrayAsync();
            Company[] companies = await companyLL.GetCompanyAsync();




            return companies;
        }

        public  bool CreateCompanyAsync(Company company)

        {

            //var user = await userManager.GetUserAsync(User);

            //var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            //var user = await _userManager.FindByNameAsync(userName);
            //TenantDBContext.ConnectionString = user.ConnectionString;
            //TenantDBContext tenantDB = new TenantDBContext();

            //ApplicationUser user = System.Web.HttpContext.C1urrent.GetOwinContext().GetUserManager<UserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            //TenantDBContext tenantDB = new TenantDBContext();
            CompanyLL companyLL = new CompanyLL();

            //Company[] companies = await tenantDB.Companies.ToArrayAsync();
            if(company.CompanyId==null)
            {

            company.CompanyId = Guid.NewGuid().ToString();
            }


            // await GetConnectionStringAsync();

            //var create = await companyLL.CreateCompanyAsync(company);

            TenantDBContext tenantDB = new TenantDBContext();
            var create =  tenantDB.Companies.Add(company);
            var result =  tenantDB.SaveChanges();
            if(result.Equals(0))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool DeleteCompany(string id)
        {
            //TenantDBContext tenantDB = new TenantDBContext();
            var company = _tenantDb.Companies.Find(id);
            if(company.CompanyId ==id)
            {
                var deleted = _tenantDb.Companies.Remove(company);
                if (deleted.State == EntityState.Deleted)
                {
                    var result = _tenantDb.SaveChanges();
                    if (result != 0)
                    {
                        return true;
                    }

                }
               
            }
            return false;
        }

        public Company GetCompany(string id)
        {
            TenantDBContext tenantDB = new TenantDBContext();
            var company = _tenantDb.Companies.Find(id);
            
            return company;
        }
        public bool UpdateCompany(Company objCompany)
        {
            //TenantDBContext tenantDB = new TenantDBContext();
            //var company = _tenantDB.Companies.Find(objCompany.CompanyId);
            if(objCompany!=null )
            {
                var update = _tenantDb.Companies.Update(objCompany);
                if(update.State == EntityState.Modified)
                {
                    var save = _tenantDb.SaveChanges();
                    if(save != 0)
                    {
                        return true;
                    }
                }

            }

            return false;
        }
        
        protected async Task GetConnectionStringAsync()
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user = await _userManager.FindByNameAsync(userName);
            TenantDBContext.ConnectionString = user.ConnectionString;
            
        }
    }
}
