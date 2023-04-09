using BM_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BM_Api_Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TenantDBContext dBContext;

        public EmployeeRepository(TenantDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
            TenantDBContext Context = new TenantDBContext();
        public async Task<IEnumerable<Employee>> GetEmployees()

        {
            return await Context.Employees.ToListAsync();
        }


        public async Task<Employee> GetEmployee(string ID)
        {
            //return await dBContext.Employees.FirstOrDefaultAsync(e => (e.FirstName.ToLower() == name.ToLower());

            //By Name
            //return await dBContext.Employees.FirstOrDefaultAsync(e => ((e.FirstName.ToLower() + (e.LastName.ToLower())).Contains(name.ToLower())));


            return await dBContext.Employees.FirstOrDefaultAsync(e => e.EmployeeID == ID);
        }


        public async Task<Employee> GetEmployee(int employeeNo)
        {
            //return await dBContext.Employees.FirstOrDefaultAsync(e => (e.FirstName.ToLower() == name.ToLower());

            //By Name
            //return await dBContext.Employees.FirstOrDefaultAsync(e => ((e.FirstName.ToLower() + (e.LastName.ToLower())).Contains(name.ToLower())));


            return await dBContext.Employees.FirstOrDefaultAsync(e => e.EmployeeNumber == employeeNo);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {

            var result = await dBContext.Employees.AddAsync(employee);
            await dBContext.SaveChangesAsync();
            return result.Entity;
           
        }

        public async Task<Employee> DeleteEmployee(string employeeId)
        {
            var result = await dBContext.Employees
                 .FirstOrDefaultAsync(e => e.EmployeeID == employeeId);
           // var resultDelete;
            if(result!= null)
            {
               var resultDelete= dBContext.Employees.Remove(result);
                var saveResult= await dBContext.SaveChangesAsync();
                if (saveResult > 0)
                {
                    return resultDelete.Entity;
                }

            }
            return result;
        }


        public async  Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await dBContext.Employees.FirstOrDefaultAsync(e => e.EmployeeID == employee.EmployeeID);
            if (result != null)
            {
                result.TitleOfCourtesy= employee.TitleOfCourtesy;
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.ContactNumber = employee.ContactNumber;
                result.EmailID = employee.EmailID;
                result.Joblevel = employee.Joblevel;
                result.JobTitle= employee.JobTitle;
                result.Region= employee.Region;
                result.ReportsTo= employee.ReportsTo;
                
                result.BirthDate = employee.BirthDate;
                result.HomePhone = employee.HomePhone;
                result.Address = employee.Address;
                result.Notes= employee.Notes;
                result.CreatedBy = employee.CreatedBy;
                result.PhotoPath= employee.PhotoPath;
                
                if (result.DateCreated.Year <= 1900)
                {

                result.DateCreated = DateTime.UtcNow;
                }

                result.DateLastModified = DateTime.UtcNow;
                
                result.City = employee.City;
                result.Country = employee.Country;
                result.PostalCode= employee.PostalCode;

                await dBContext.SaveChangesAsync();

                return result;

            }
           return result;
        }
    }
}
