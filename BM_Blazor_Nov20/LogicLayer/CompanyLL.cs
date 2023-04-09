using BM_Blazor_Nov20.Data.DatabaseLayer;
using BM_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BM_Blazor_Nov20.Data.LogicLayer
{
    public class CompanyLL
    {
        CompanyDL companyDL = new CompanyDL();
        internal async Task<Company[]> GetCompanyAsync()
        {

            Company[] companies = await companyDL.GetCompanyAsync() ;

                return (companies);
        }

        internal async Task<bool> CreateCompanyAsync(Company company)
        {
            var create = await companyDL.CreateCompanyAsync(company);




            return create;
        }
    }
}
