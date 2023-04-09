using BM_Web.Data;
using BM_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BM_Web.DataLayer
{
    public class CompanyDataLayer
    {
        private CompanyDbContext context = new CompanyDbContext();

       
        public Company Get(int id)
        {
            var objCompany = context.Companies.Where(x => x.CompanyId == id.ToString()).FirstOrDefault();

            return objCompany;
        }

        internal IList<Company> Get()
        {
            IList<Company> objCompany = context.Companies.ToList();

            return objCompany;
        }
    }
}
