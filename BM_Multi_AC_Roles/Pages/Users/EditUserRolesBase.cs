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
    public class EditUserRolesBase : ComponentBase
    {


        [Parameter]
        public string userId { get; set; }

        public IdentityUserRole<string> objUserRole { get; set; }

        public IList<IdentityUserRole<string>> objListUserRole { get; set; }

        [Inject]
        public IUserServices objUserServices { get; set; }

        [Inject]
        public NavigationManager objNavigationManager { get; set; }


        public PaginatedList<IdentityUserRole<string>> paginatedList = new PaginatedList<IdentityUserRole<string>>();


        protected override async Task OnInitializedAsync()
        {
            if (userId != "new")
            {
                // objListUserRole = await objUserServices.GetUserRolesAsync((userId));
                paginatedList = await objUserServices.GetPagedUserRoleList(userId, pageNumber, currentSortField, currentSortOrder);
            }
            else
            {

                objUserRole = new IdentityUserRole<string>();

            }


        }


        string currentSortField = "UserName";
        string currentSortOrder = "Asc";
        int? pageNumber = 1;

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
            paginatedList = await objUserServices.GetPagedUserRoleList(userId, pageNumber, currentSortField, currentSortOrder);
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
            paginatedList = await objUserServices.GetPagedUserRoleList(userId, pageNumber, currentSortField, currentSortOrder);
            //toDoList = paginatedList.Items;
            StateHasChanged();
        }

    }
}
