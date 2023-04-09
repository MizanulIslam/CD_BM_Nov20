using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BM_Multi_AC_Roles.Model.UIModel
{
    public class EditUserUIModel
    {

        public EditUserUIModel()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }

        public string Id { get; set; }

      
        public string UserName { get; set; }

       
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        

        public List<string> Claims { get; set; }

        public IList<string> Roles { get; set; }
    }

    public class EditUserUIModelValidator : AbstractValidator<EditUserUIModel>
    {
        public EditUserUIModelValidator()
        {
            try
            {
                RuleFor(expression: x => x.UserName).NotEmpty().WithMessage("user name is required");
                RuleFor(expression: x => x.UserName).MinimumLength(3).WithMessage("user name should be aleast 3 letters");
                RuleFor(expression: x => x.UserName).MaximumLength(50).WithMessage("user name should be aleast 50 letters");
                RuleFor(expression: x => x.Email).EmailAddress().WithMessage("email should be valid");

            }
            catch (Exception ex)
            {
                var er = ex.Message;
            }

        }



    }
}
