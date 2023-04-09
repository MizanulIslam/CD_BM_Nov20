using BM_Multi_AC_Roles.Model.UIModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BM_Multi_AC_Roles.Services
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<IdentityUser> userManager;

        public IQueryable<IdentityUser> objUserList;

        public UserServices(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IdentityResult> CreateRole(IdentityUser objUser)
        {
            try
            {
                var result = await userManager.CreateAsync(objUser);


                return (result);

            }
            catch
            {
                throw;
            }
        }

        public async Task<IdentityResult> CreateUser(EditUserUIModel objEditUserUIM)
        {

            try
            {
                var user = await userManager.FindByNameAsync(objEditUserUIM.UserName);

                IdentityResult ir = new IdentityResult();
                if(user == null)
                {
                    IdentityUser newUser = new IdentityUser();
                    //Data
                    newUser.UserName = objEditUserUIM.UserName;
                    newUser.Email = objEditUserUIM.Email;
                    //if (objEditUserUIM.Email != null)
                    //{

                    //    newUser.Email = objEditUserUIM.Email;
                    //}
                    //else
                    //{
                    //    newUser.Email = objEditUserUIM.UserName;
                    //}
                    newUser.PhoneNumber = objEditUserUIM.PhoneNumber;
                    newUser.EmailConfirmed = true;
                    

                   ir = await userManager.CreateAsync(newUser,"Poly.123");

                    return ir;
                }
                IdentityError identityError = new IdentityError();
                identityError.Description = "User Name alrady exist";
                ir.Errors.Append(identityError);


                return ir;

            }
            catch(Exception ex)
            {
                IdentityResult ir = new IdentityResult();
                IdentityError identityError = new IdentityError();
                
                identityError.Description = ex.Message;
                ir.Errors.Append(identityError);
                return ir;
            }
        }

        public async Task<PaginatedList<IdentityUser>> GetPagedList(int? pageNumber, string sortField, string sortOrder)
        {
            int pageSize = 5;


            var List = userManager.Users.OrderByDynamic(sortField,sortOrder.ToUpper());

            
            return await PaginatedList<IdentityUser>.CreateAsync(List.AsNoTracking(), pageNumber ?? 1, pageSize);
        }

        public Task<PaginatedList<IdentityUserRole<string>>> GetPagedUserRoleList(string id, int? pageNumber, string sortField, string sortOrder)
        {
            throw new NotImplementedException();
        }

        public async Task<EditUserUIModel> GetUserAsync(string id)
        {
            try
            {
                // var result = await userManager.FindByIdAsync(id);


                var user = await userManager.FindByIdAsync(id);

                if (user == null)
                {
                  
                }

                // GetClaimsAsync retunrs the list of user Claims
                var userClaims = await userManager.GetClaimsAsync(user);
                // GetRolesAsync returns the list of user Roles
                var userRoles = await userManager.GetRolesAsync(user);

                var model = new EditUserUIModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    Claims = userClaims.Select(c => c.Value).ToList(),
                    Roles = userRoles
                };
                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IList<IdentityUserRole<string>>> GetUserRolesAsync(string id)
        {
            try
            {
                var result = await userManager.FindByIdAsync(id);
                var resultUserRole = await userManager.GetRolesAsync(result);
                var x = resultUserRole.ToList();


                return (IList<IdentityUserRole<string>>)(resultUserRole);

            }
            catch
            {
                throw;
            }
        }

        public async Task<IdentityResult> UpdateRole(EditUserUIModel objEditUserUIM)
        {

            try
            {
                var user = await userManager.FindByNameAsync(objEditUserUIM.UserName);

                IdentityResult ir = new IdentityResult();
                if (user != null)
                {
                    
                    user.UserName = objEditUserUIM.UserName;
                    user.Email = objEditUserUIM.Email;
                    user.PhoneNumber = objEditUserUIM.PhoneNumber;

                    ir = await userManager.UpdateAsync(user);

                    return ir;
                }

                IdentityError identityError = new IdentityError();
                identityError.Description = "User doesn't exist";
                ir.Errors.Append(identityError);


                return ir;

            }
            catch
            {
                throw;
            }
            //try
            //{
            //    var result = await userManager.UpdateAsync(objUser);


            //    return (result);

            //}
            //catch
            //{
            //    throw;
            //}
        }

        public Task<IdentityResult> UpdateUser(IdentityUser objUser)
        {
            throw new NotImplementedException();
        }
    }
}
