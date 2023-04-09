using BM_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BM_Blazor_Nov20.Data.DatabaseLayer
{
    public class CompanyDL
    {
        TenantDBContext TenantDB = new TenantDBContext();
      
        internal async Task<Company[]> GetCompanyAsync()
        {

            Company[] companies =  await TenantDB.Companies.ToArrayAsync();

            return (companies);
        }

        internal async Task<bool> CreateCompanyAsync(Company company)
        {
           
            //var companyTest = await TenantDB.Companies.FirstAsync(x => x.CompanyId == company.CompanyId);
            if (company != null)
            {
                var create = await TenantDB.Companies.AddAsync(company);

                if (create.IsKeySet)
                {
                    await TenantDB.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }



            return false;
        }
    }
}
