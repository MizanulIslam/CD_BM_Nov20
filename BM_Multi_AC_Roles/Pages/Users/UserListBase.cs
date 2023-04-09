using BM_Multi_AC_Roles.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BM_Multi_AC_Roles.Pages.Users
{
    public class UserListBase :ComponentBase
    {


        [Inject]
        public IUserServices objUserServices { get; set; }

        [Inject]
        AuthenticationStateProvider authenticationStateProvider { get; set; }

        public string username ="no username asigned";


        public PaginatedList<IdentityUser> paginatedList = new PaginatedList<IdentityUser>();

        string currentSortField = "UserName";
        string currentSortOrder = "Asc";
        int? pageNumber = 1;


        protected override async Task OnInitializedAsync()
        {
            var user = authenticationStateProvider.GetAuthenticationStateAsync();
            username = user.Result.User.Identity.Name;
            paginatedList = await objUserServices.GetPagedList(pageNumber, currentSortField, currentSortOrder);

        }

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
            paginatedList = await objUserServices.GetPagedList(pageNumber, currentSortField, currentSortOrder);
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
            paginatedList = await objUserServices.GetPagedList(pageNumber, currentSortField, currentSortOrder);
            //toDoList = paginatedList.Items;
            StateHasChanged();
        }

    }
}
