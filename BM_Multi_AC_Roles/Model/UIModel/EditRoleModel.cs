using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace BM_Multi_AC_Roles.Model.UIModel
{
    public class EditRoleModel : IdentityRole
    {

        

    }
    public class EditRoleModelValidator : AbstractValidator<EditRoleModel>
    {
        public EditRoleModelValidator()
        {
            try
            {
                RuleFor(expression: x => x.Name).NotEmpty().WithMessage("name is required");
                RuleFor(expression: x => x.Name).MinimumLength(3).WithMessage("name should be aleast 3 letters");
                RuleFor(expression: x => x.Name).MaximumLength(3).WithMessage("name should be aleast 50 letters");
              

            }
            catch (Exception ex)
            {
                var er = ex.Message;
            }

        }



    }
}
