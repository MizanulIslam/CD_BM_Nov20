using BM_Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BM_Blazor_Nov20.Services
{
    public interface IEmployeeServices
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeAsync(string id);
        Task<Employee> DeleteEmployeeAsync(string id);
        Task<Employee> UpdateEmployee(Employee updatedEmployee);

        Task<Employee> CreateEmployee(Employee createEmployee);
        Task<ActionResult<Employee>> ObjDeleteEmployeeAsync(string id);

        Task<PaginatedList<Employee>> GetPagedList(int? pageNumber, string sortField, string sortOrder);


    }
}
