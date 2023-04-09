using BM_Blazor_Nov20.Services;
using BM_Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BM_Blazor_Nov20.Pages.Employees
{
    public class EmployeeDetailsBase : ComponentBase
    {
        [Inject]
        public NavigationManager objNavigationManager { get; set; }
        [Inject]
        public IEmployeeServices objEmployeeService { get; set; }

        [Parameter]
        public string id { get; set; }

        protected BlazorComponents.ConfirmDialogBox DeleteConfirmation { get; set; }

        public Employee objEmployee = new Employee();
        private string Message;

        protected override async Task OnInitializedAsync()
        {

            objEmployee = await Task.Run(() => objEmployeeService.GetEmployeeAsync(id));

        }

        protected void Delete_Click()
        {
            DeleteConfirmation.Show();

        }

        protected async Task ConfirmDelete_Click(bool deleteConfirm)
        {
            if (deleteConfirm)
            {
                var result = await objEmployeeService.ObjDeleteEmployeeAsync(id);
                objNavigationManager.NavigateTo("Employees");
            }
        }
        //    protected async Task  Delete_Click()
        //{
        //    DeleteConfirmation.Show();
         
            //var result = await objEmployeeService.DeleteEmployeeAsync(id);
           // var result = await objEmployeeService.ObjDeleteEmployeeAsync(id);
            //if(result.IsSuccessStatusCode||result.)
            //{

            //    objNavigationManager.NavigateTo("Employees");
            //}
            //if (result.StatusCode == System.Net.HttpStatusCode.OK || result.StatusCode == System.Net.HttpStatusCode.NotFound)
            //{
            //    objNavigationManager.NavigateTo("Employees");
            //}
            //if((result.StatusCode == System.Net.HttpStatusCode.Conflict))
            //{
            //    Message = "Retry after Sometomes, Server Conflit";
            //    objNavigationManager.NavigateTo($"EmployeeDetails/{id},");
            //}
            //objNavigationManager.NavigateTo("Employees");
     //   }

        protected void Edit_Click()
        {
            //var url = "EditCompany/" + Id;
            objNavigationManager.NavigateTo($"EditEmployee/{id}");
        }
        protected void Cancel_Click()
        {
            //var url = "EditCompany/" + Id;
            objNavigationManager.NavigateTo($"Employees");
        }

    }
}
