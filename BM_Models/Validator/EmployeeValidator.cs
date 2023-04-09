using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace BM_Models.Validator
{
    public  class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            try
            {
 RuleFor(expression: x => x.FirstName)                
               
                .NotEmpty().WithMessage("'First Name' is Required")
                .MinimumLength(2)
                .Matches(expression: "^[a-zA-Z ]*$");




            RuleFor(expression: x => x.EmployeeNumber)
               .NotNull()
               ;

            RuleFor(expression: x => x.EmailID).NotEmpty()
                .EmailAddress();
            }
            catch(Exception ex)
            {
                var er = ex.Message;
            }
           

            
        }
    }
}
