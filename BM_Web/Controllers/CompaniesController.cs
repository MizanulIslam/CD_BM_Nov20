using BM_Web.Data;
using BM_Web.LogicLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BM_Web.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly CompanyLL companyLL;

        public CompaniesController(CompanyLL _companyLL)
        {
            companyLL = _companyLL;
        }
       
        // GET api/<CompaniesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var objCompany = companyLL.Get(id);


            return (objCompany.Name);
        }

        // POST api/<CompaniesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CompaniesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CompaniesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
