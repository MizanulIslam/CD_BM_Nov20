using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BM_Multi_AC_Roles.Services
{
    public interface IRoleServices
    {
        Task<PaginatedList<IdentityRole>> GetPagedList(int? pageNumber, string sortField, string sortOrder);
        Task<IdentityRole> GetRoleAsync(string id);
        Task<IdentityRole> CreateRole(IdentityRole objRole);
        Task<IdentityRole> UpdateRole(IdentityRole objRole);
    }
}
