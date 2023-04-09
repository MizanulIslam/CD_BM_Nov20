using BM_Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;




namespace BM_Blazor_Nov20.Services
{
    public class EmployeeServices  
    {
        private readonly HttpClient httpClient;

        public EmployeeServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await httpClient.GetFromJsonAsync<Employee[]>("api/employee");
        }

        public async Task<Employee> GetEmployeeAsync(string ID)
        {
            var uri = "api/employee/" + ID;
            return await httpClient.GetFromJsonAsync<Employee>(uri);
        }

        public async Task<HttpResponseMessage> DeleteEmployeeAsync(string ID)
        {
            //var uri = "api/employee/" + ID;
            //var result = await httpClient.DeleteAsync(uri);
            return await httpClient.DeleteAsync($"api/employee/{ID}");
            
        }

        public async Task<HttpResponseMessage> UpdateEmployee(Employee updatedEmployee)
        {
            return await httpClient.PutAsJsonAsync("api/employee", updatedEmployee);
            
        }

        public async Task<HttpResponseMessage> CreateEmployee(Employee createEmployee)
        {
            var result =         await httpClient.PostAsJsonAsync("api/employee", createEmployee);

            return result;
        }

        Task<ActionResult<Employee>> ObjDeleteEmployeeAsync(string id)
        {
            throw new NotImplementedException();
        }

       
      
    }
}
