using BM_Blazor_Nov20.Data;
using BM_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BM_Blazor_Nov20.Services
{
    public class EmployeeServicesBazor : IEmployeeServices
    {

        TenantDBContext Context = new TenantDBContext();

        private readonly TenantDBContext dBContext;

        public EmployeeServicesBazor(TenantDBContext dBContext)
        {
            this.dBContext = dBContext;
        }




        public async Task<Employee> CreateEmployee(Employee createEmployee)


        {




            var result = await dBContext.Employees.AddAsync(createEmployee);
             var sResult =  await dBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ActionResult<Employee>> ObjDeleteEmployeeAsync(string id)
        {
            var result = await dBContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeID == id);
            // var resultDelete;
            if (result != null)
            {
                var resultDelete = dBContext.Employees.Remove(result);
                var saveResult = await dBContext.SaveChangesAsync();
                if (saveResult > 0)
                {
                    return resultDelete.Entity;
                }

            }
            return result;
        }

        public async Task<Employee> GetEmployeeAsync(string id)
        {
            // await dBContext.Employees.FirstOrDefaultAsync(e => e.EmployeeID == id);


            var QResult = await dBContext.Employees
                    .Select(p => new Employee()
                    {
                        EmployeeID = p.EmployeeID,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        EmployeeNumber = (int)p.EmployeeNumber,
                        EmailID = p.EmailID,
                        ContactNumber=p.ContactNumber,
                        Region = p.Region, //Branch
                        Address = p.Address,
                        HireDate =p.HireDate,
                        BirthDate=p.BirthDate,

                    })
                    .Where(e => e.EmployeeID == id).FirstOrDefaultAsync<Employee>();

            return QResult;
        }


        public async Task<PaginatedList<Employee>> GetPagedList(int? pageNumber, string sortField, string sortOrder)
        {

            int pageSize = 2;

          
            var EmployeeList = dBContext.Employees.OrderByDynamic(sortField, sortOrder.ToUpper());
            return await PaginatedList<Employee>.CreateAsync(EmployeeList.AsNoTracking(), pageNumber ?? 1, pageSize);
        }



        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {

            //var test = await dBContext.Employees
            //.Select(p => new { p.EmployeeID ,p.FirstName,p.LastName,p.EmployeeNumber,p.EmailID,p.Region })
            //.ToListAsync();
            try
            {

                var re = await dBContext.Employees
                    .Select(p => new Employee()
                    {
                        EmployeeID = p.EmployeeID,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        EmployeeNumber = (int)p.EmployeeNumber,
                        EmailID = p.EmailID,
                        Region = p.Region,

                    }).ToListAsync();

                return re;
            }
            catch (Exception ex)
            {
                var r = ex.ToString();
                return null;
            }
            
        }

        public  async Task<Employee> UpdateEmployee(Employee employee)
        {
            //var response = new HttpResponseMessage();
            //string responseText = "";

            var result = await dBContext.Employees.FirstOrDefaultAsync(e => e.EmployeeID == employee.EmployeeID);
            if (result != null)
            {
                result.TitleOfCourtesy = employee.TitleOfCourtesy;
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.ContactNumber = employee.ContactNumber;
                result.EmailID = employee.EmailID;
                result.Joblevel = employee.Joblevel;
                result.JobTitle = employee.JobTitle;
                result.Region = employee.Region;
                result.ReportsTo = employee.ReportsTo;

                result.BirthDate = employee.BirthDate;
                result.HomePhone = employee.HomePhone;
                result.Address = employee.Address;
                result.Notes = employee.Notes;
                result.CreatedBy = employee.CreatedBy;
                result.PhotoPath = employee.PhotoPath;

                if (result.DateCreated.Year <= 1900)
                {

                    result.DateCreated = DateTime.UtcNow;
                }

                result.DateLastModified = DateTime.UtcNow;

                result.City = employee.City;
                result.Country = employee.Country;
                result.PostalCode = employee.PostalCode;

                var saveResponse = await dBContext.SaveChangesAsync();


                return result;

            }
            return result;
        }

        public Task<Employee> DeleteEmployeeAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
