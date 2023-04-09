using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BM_Multi_AC_Roles.Services;

namespace BM_Multi_AC_Roles.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly RoleManager<IdentityRole> varroleManager;

        public RoleServices(RoleManager<IdentityRole> roleManager)
        {
            varroleManager = roleManager;
        }


        public async Task<PaginatedList<IdentityRole>> GetPagedList(int? pageNumber, string sortField, string sortOrder)
        {
            int pageSize = 15;
          
            try
            {


            var List = varroleManager.Roles.OrderByDynamic(sortField, sortOrder.ToUpper());


           

            var x= varroleManager.Roles.ToList();
                if (List.Count() == 0)
                {
                    IdentityRole newrole = new IdentityRole();
                    newrole.Name = "Admin";
                   
                }

              //  var error = varroleManager.RoleValidators(IdentityErrorDescriber).
            return await PaginatedList<IdentityRole>.CreateAsync(List.AsNoTracking(), pageNumber ?? 1, pageSize);
            }
            catch(Exception ex)
            {
                var m = ex;
                var List = varroleManager.Roles.OrderByDynamic(sortField, sortOrder.ToUpper());
                return await PaginatedList<IdentityRole>.CreateAsync(List.AsNoTracking(), pageNumber ?? 1, pageSize);
            }

        }

     

        public async Task<IdentityRole> GetRoleAsync(string id)
        {
            try
            {
                var result = await varroleManager.FindByIdAsync(id);


                return result;

            }
            catch
            {
                throw;
            }
        }

     

        async Task<IdentityRole> IRoleServices.CreateRole(IdentityRole objRole)
        {
            try
            {
                var result = await varroleManager.CreateAsync(objRole);
                

                    return objRole;
                
            }
            catch {
                throw;
            }

        }

        async Task<IdentityRole> IRoleServices.UpdateRole(IdentityRole objRole)
        {
            try
            {
                var result = await varroleManager.UpdateAsync(objRole);


                return objRole;

            }
            catch
            {
                throw;
            }
        }
    }
}
