using BM_Multi_AC_Roles.Model.UIModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BM_Multi_AC_Roles.Services
{
    public interface IUserServices
    {
        Task<PaginatedList<IdentityUser>> GetPagedList(int? pageNumber, string sortField, string sortOrder);
        Task<PaginatedList<IdentityUserRole<string>>> GetPagedUserRoleList(string id,int? pageNumber, string sortField, string sortOrder);
        
        Task<EditUserUIModel> GetUserAsync(string id);
        //Task<IdentityResult> CreateRole(IdentityUser objUser);
        Task<IdentityResult> UpdateUser(IdentityUser objUser);
        Task<IList<IdentityUserRole<string>>> GetUserRolesAsync(string id);
        Task<IdentityResult> CreateUser(EditUserUIModel objEditUserUIM);
    }
}
