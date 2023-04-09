using BM_Web.LogicLayer;
using BM_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BM_Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace BM_Web.Controllers
{
    public class CompanyController : Controller
    {
        private IHttpContextAccessor _httpContextAccessor;
        private ApplicationDbContext appDB;
        private UserManager<ApplicationUser> _userManger;
        private string _currentUserName;
        private object _currentUserGuid;
        private object _currentUserCS;
        CompanyDbContext companyDb;
        
        private  CompanyLL companyLL = new CompanyLL();

        public CompanyController(ApplicationDbContext AppDB,
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            appDB = AppDB;
            _userManger = userManager;
            _currentUserName = _httpContextAccessor?.HttpContext?.User.Identity.Name;
            _currentUserCS = _currentUserName == null ? "" : 
                userManager.FindByNameAsync(_currentUserName)?.Result?.ConnectionString;


            CompanyDbContext.ConnectionString = _currentUserCS.ToString();
            companyDb = new CompanyDbContext("123456");

        }

        

        public IActionResult Index()
        {
             IList<Company> companies = companyLL.Get();


            return View(companies);
        }

        

    }
}
