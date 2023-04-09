using BM_Blazor_Nov20.Services;
using BM_Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BM_Blazor_Nov20.Pages.Employees
{
    public class EmployeeListBase : ComponentBase
    {
        public string nullString= null;
        [Inject]
        public IEmployeeServices objEmployeeService { get; set; }

        public IEnumerable<Employee> objEmployees { get; set; }

        List<Employee> employeeList;
       
        int? pageNumber = 1;
        string sortField = "EmployeeNumber";
        string sortOrder= "Asc";

        public PaginatedList<Employee> paginatedList = new PaginatedList<Employee>();
        
 // Page and Sort data
        string currentSortField = "EmployeeNumber";
        string currentSortOrder = "Asc";


        protected override  async Task OnInitializedAsync()
        {
            //objEmployees = (await objEmployeeService.GetEmployeesAsync()).ToList();

            paginatedList = await objEmployeeService.GetPagedList(pageNumber, sortField, sortOrder);
            var c = paginatedList.Items;

            //objEmployees = paginatedList.Items;
        }

        //public async Task<PaginatedList<Employee>> Get(int? pageNumber, string sortField, string sortOrder)
        //{
        //    list = await objEmployeeService.GetList(pageNumber, sortField, sortOrder);
        //    return list;
        //}



       
        protected async Task Sort(string sortField)
        {
            if (sortField.Equals(currentSortField))
            {
                currentSortOrder = currentSortOrder.Equals("Asc") ? "Desc" : "Asc";
            }
            else
            {
                currentSortField = sortField;
                currentSortOrder = "Asc";
            }
            paginatedList = await objEmployeeService.GetPagedList(pageNumber, currentSortField, currentSortOrder);
            //employeeList = paginatedList.Items;
        }


        protected string SortIndicator(string sortField)
        {
            if (sortField.Equals(currentSortField))
            {
                return currentSortOrder.Equals("Asc") ? "oi oi-caret-bottom" : "oi oi-caret-top";
            }
            return string.Empty;
        }


        public async void PageIndexChanged(int newPageNumber)
        {
            if (newPageNumber < 1 || newPageNumber > paginatedList.TotalPages)
            {
                return;
            }
            pageNumber = newPageNumber;
            paginatedList = await objEmployeeService.GetPagedList(pageNumber, currentSortField, currentSortOrder);
            //toDoList = paginatedList.Items;
            StateHasChanged();
        }
    }
}
