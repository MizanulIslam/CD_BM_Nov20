using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BM_Multi_AC_Roles.Services;
using BM_Multi_AC_Roles.Model.UIModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;


namespace BM_Multi_AC_Roles.Pages.Users
{
    public class EditUserBase : ComponentBase
    {


        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public string SaveButtonText { get; set; } = "Save";


        [Parameter]
        public string DeleteButtonText { get; set; } = "Delete";


        [Parameter]
        public string DetailsButtonText { get; set; } = "Details";


        public IdentityUser objUser { get; set; }

        [Inject]
        public IUserServices objUserServices { get; set; }

        [Inject]
        public NavigationManager objNavigationManager { get; set; }
        public string MessageString { get; private set; }

        public EditUserUIModel objEditUserUIM { get; set; }

       
        

        protected override async Task OnInitializedAsync()
        {
            if (Id != "new")
            {
                objEditUserUIM = await objUserServices.GetUserAsync((Id));
            }
            else
            {

                objEditUserUIM = new EditUserUIModel();

            }

          
        }


        protected void Details_Click()
        {


            objNavigationManager.NavigateTo($"userdetails/{objUser.Id}");



        }
        protected void Delete_Click()
        {


            objNavigationManager.NavigateTo($"userDelete/{objUser.Id}");



        }
        protected async Task HandleValidSubmit()
        {
            if (objEditUserUIM == null)
            {
                StatuMessageHasChanged("Error: No Data");
                //MessageString = "Error: No Data";

            }
            else if (Id == "new")
            {
               
                var result = await objUserServices.CreateUser(objEditUserUIM);
                //MessageString = "Created";
                
                if (result.Succeeded)
                {

                StatuMessageHasChanged("Created");
                }
                else
                {

                    foreach (var error in result.Errors)
                    {
                        string es = error.Description.ToString();
                        StatuMessageHasChanged($"Error : {es}");
                    }
                }
            }
            else
            {
                var result = await objUserServices.UpdateUser(objUser);
                if (result.Succeeded)
                {

                StatuMessageHasChanged("Updated");
                }
                else
                {
                    
                        foreach(var error in result.Errors)
                    {
                        string es = error.Description.ToString();
                        StatuMessageHasChanged($"Error : {es}");
                    }
                }
           

            }
        }

        public void StatuMessageHasChanged(string model)
        {
            MessageString = model;
            StateHasChanged();
        }


    }
}
