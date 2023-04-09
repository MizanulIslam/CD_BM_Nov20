using BM_Blazor_Nov20.Services;
using BM_Blazor_Nov20.Models;
using BM_Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using BM_Models.Validator;
using FluentValidation;

namespace BM_Blazor_Nov20.Pages.Employees
{
    public class EditEmployeeBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        [Parameter] public string ButtonText { get; set; } = "Save";

        public Employee objEmployee { get; set; } = new Employee();



        [Inject]
        public NavigationManager objNavigationManager { get; set; }
        [Inject]
        public IEmployeeServices objEmployeeService { get; set; }


        public List<Employee> objEmployeeList = new List<Employee>();

        public string EmployeHeadID { get; set; }
        [Inject]
        public IMapper Mapper { get; set; }
        [Inject]
        public AuthenticationStateProvider objAuthenticationStateProvider { get; set; }


        public  bool showalert = false;

        public EditEmployeeModel objEditEmployeeModel { get; set; } = new EditEmployeeModel();

        public string MessageString= "";

        protected async override Task OnInitializedAsync()
        {


            if (Id !="new")
            {
                objEmployee = await objEmployeeService.GetEmployeeAsync((Id));
            }
            else
            {

                objEmployee = new Employee
                {
                    EmployeeNumber = 0,
                    HireDate= DateTime.UtcNow,
                    BirthDate = DateTime.UtcNow,
                    PhotoPath = "images/nophoto.jpg"
                };
            }
            objEmployeeList = (await objEmployeeService.GetEmployeesAsync()).ToList();
            if(objEmployee.EmployeeNumber==0)
            {
               var highest = objEmployeeList.OrderByDescending(x => x.EmployeeNumber).FirstOrDefault();
                if (highest == null)
                {
                    objEmployee.EmployeeNumber =1;
                }
                else
                {

                objEmployee.EmployeeNumber = highest.EmployeeNumber+1;
                }
            }

            //objEmployee = await objEmployeeService.GetEmployeeAsync(Id);

            // objEmployeeList = (List<Employee>) await objEmployeeService.GetEmployeesAsync();
            //objEmployeeList = (await objEmployeeService.GetEmployeesAsync()).ToList();

            EmployeHeadID = objEmployee.ReportsTo;
            Mapper.Map(objEmployee, objEditEmployeeModel);
        }

        protected void ShowAlert()
        {
            if (showalert == false)
            {

                showalert = true;
            }
            else
                showalert = false;

        }

        protected async Task Delete_Click()
        {


            //var result = await objEmployeeService.DeleteEmployeeAsync(Id);
            var result = await objEmployeeService.ObjDeleteEmployeeAsync(Id);
            
            //if(result.IsSuccessStatusCode||result.)
            //{

            //    objNavigationManager.NavigateTo("Employees");
            //}
            //if (result.StatusCode == System.Net.HttpStatusCode.OK || result.StatusCode == System.Net.HttpStatusCode.NotFound)
            //{
            //    MessageString = await result.Content.ReadAsStringAsync();
            //    objNavigationManager.NavigateTo("Employees");
            //}
            //if ((result.StatusCode == System.Net.HttpStatusCode.Conflict))
            //{
            //    MessageString = "Retry after Sometomes, Server Conflit";
            //    objNavigationManager.NavigateTo($"EmployeeDetails/{Id},");
            //}
            objNavigationManager.NavigateTo("Employees");



        }

        protected  void Details_Click()
        {


            objNavigationManager.NavigateTo($"EmployeeDetails/{Id}");



        }



        protected async Task HandleValidSubmit()
        {
            Mapper.Map(objEditEmployeeModel, objEmployee);

            var resultAuthenticationState = await objAuthenticationStateProvider.GetAuthenticationStateAsync();

            var user = resultAuthenticationState.User.Identity.Name;

            objEmployee.ReportsTo = EmployeHeadID;

            MessageString = "";
            EditEmployeeModelValidator editemployeeValidator = new EditEmployeeModelValidator();
            EmployeeValidator employeeValidator = new EmployeeValidator();
            var result = new Employee();

            var valEResult = editemployeeValidator.Validate(objEditEmployeeModel);
            var valResult = employeeValidator.Validate(objEmployee);

            if (valResult.IsValid)
            {

                try
                {
                    if (objEmployee == null)
                    {
                        MessageString = "No Data";

                    }

                    else if (objEmployee.EmployeeID == "" || objEmployee.EmployeeID == null)
                    {
                        objEmployee.CreatedBy = user;
                        objEmployee.DateCreated = DateTime.UtcNow;
                        objEmployee.EmployeeID = Guid.NewGuid().ToString();
                        result = await objEmployeeService.CreateEmployee(objEmployee);
                        MessageString = "Added";
                        showalert = true;
                        objNavigationManager.NavigateTo($"EditEmployee/{result.EmployeeID}",true);
                    }
                    else
                    {
                        result = await objEmployeeService.UpdateEmployee(objEmployee);
                        MessageString = "Updated";
                       // objNavigationManager.NavigateTo($"EditEmployee/{result.EmployeeID}",true);
                    }
                }
                catch (Exception ex)
                {
                    MessageString = ex.Message;
                }

            }
            else
            {

                
                foreach (var er in valResult.Errors)
                {
                    MessageString += "  " + er.ErrorMessage + " \n";
                }
            }

            showalert = true;

            //MessageString += result;
            //if (result != null)
            //{
            //    objNavigationManager.NavigateTo("/");
            //}
            //MessageString = result.StatusCode.ToString();
            // MessageString += "SC"+result.StatusCode + "RP"+result.ReasonPhrase +"R" + result.Content;

            
            //var result = await objEmployeeService.UpdateEmployee(objEmployee);

            //if (result.StatusCode == System.Net.HttpStatusCode.OK || result.StatusCode == System.Net.HttpStatusCode.NotFound)
            //{
            //MessageString = result.StatusCode.ToString();
            //    MessageString = result.ReasonPhrase;
            //   objNavigationManager.NavigateTo("Employees");
            //}
            //if ((result.StatusCode == System.Net.HttpStatusCode.Conflict))
            //{
            //    MessageString = "Retry after Sometomes, Server Conflit";
            //    objNavigationManager.NavigateTo($"EmployeeDetails/{Id},");
            //}

            //if (result != null)
            //{
            //    objNavigationManager.NavigateTo("/");
            //}

        }
    }
}
