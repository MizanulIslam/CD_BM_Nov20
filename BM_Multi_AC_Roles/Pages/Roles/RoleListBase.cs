using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BM_Multi_AC_Roles.Services;
using Microsoft.AspNetCore.Identity;

namespace BM_Multi_AC_Roles.Pages.Roles
{
    public class RoleListBase : ComponentBase

    {
        [Inject]
        public IRoleServices objRoleServices { get; set; }




        public PaginatedList<IdentityRole> paginatedList = new PaginatedList<IdentityRole>();

        string currentSortField = "Name";
        string currentSortOrder = "Asc";
        int? pageNumber = 1;


        protected override async Task OnInitializedAsync()
        {

            paginatedList = await objRoleServices.GetPagedList(pageNumber, currentSortField, currentSortOrder);

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
            paginatedList = await objRoleServices.GetPagedList(pageNumber, currentSortField, currentSortOrder);
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
            paginatedList = await objRoleServices.GetPagedList(pageNumber, currentSortField, currentSortOrder);
            //toDoList = paginatedList.Items;
            StateHasChanged();
        }

    }
}
