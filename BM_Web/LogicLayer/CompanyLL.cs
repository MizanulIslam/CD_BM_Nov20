using BM_Web.DataLayer;
using BM_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BM_Web.LogicLayer
{
    public class CompanyLL
    {
        CompanyDataLayer companyDataLayer = new CompanyDataLayer();

        public Company Get(int id)
        {
            var objCompany = companyDataLayer.Get(id);

            return objCompany;
        }

        internal IList<Company> Get()
        {
            IList<Company> companies = companyDataLayer.Get();

            return companies;
        }
    }
}