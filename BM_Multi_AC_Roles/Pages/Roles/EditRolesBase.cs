using BM_Multi_AC_Roles.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BM_Multi_AC_Roles.Pages.Roles
{
    public class EditRolesBase : ComponentBase
    {
        private bool showalert;

        [Parameter]
        public string Id { get; set; }

        [Parameter] 
        public string SaveButtonText { get; set; } = "Save";


        [Parameter]
        public string DeleteButtonText { get; set; } = "Delete";


        [Parameter]
        public string DetailsButtonText { get; set; } = "Details";
        

        public IdentityRole objRole { get; set; }

        [Inject]
        public IRoleServices objRoleServices { get; set; }

        [Inject]
        public NavigationManager objNavigationManager { get; set; }
        public string MessageString { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            if (Id != "new")
            {
                objRole = await objRoleServices.GetRoleAsync((Id));
            }
            else
            {

                objRole = new IdentityRole();

            }


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


        protected void Details_Click()
        {


            objNavigationManager.NavigateTo($"roledetails/{objRole.Id}");



        }
        protected void Delete_Click()
        {


            objNavigationManager.NavigateTo($"roleDelete/{objRole.Id}");



        }
        protected async Task HandleValidSubmit()
        {
            if (objRole == null)
            {
                StatuMessageHasChanged("Error: No Data");
                //MessageString = "Error: No Data";

            }
            else if (Id == "new")
            {
                var result = await objRoleServices.CreateRole(objRole);
                //MessageString = "Created";
                StatuMessageHasChanged("Created");
            }
            else
            {
                var result = await objRoleServices.UpdateRole(objRole);
                StatuMessageHasChanged("Updated");
                //MessageString = "Updated";

            }
        }

        public  void StatuMessageHasChanged(string model)
        {
            MessageString = model;
            StateHasChanged();
        }
    }
}
