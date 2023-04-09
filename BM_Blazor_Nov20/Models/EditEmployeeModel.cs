using BM_Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BM_Blazor_Nov20.Models
{
    public class EditEmployeeModel
    {
        public string EmployeeID { get; set; }

        public int EmployeeNumber { get; set; }

        public string TitleOfCourtesy { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EmailID { get; set; }
        public string ConfirmEmail  { get; set; }

        
        public string ContactNumber { get; set; }


        public string JobTitle { get; set; }
        public string Joblevel { get; set; }

        public DateTime HireDate { get; set; }
        public string Region { get; set; }
        public string ReportsTo { get; set; }
       
        public string HomePhone { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        
        public string Address { get; set; }
        

        public string Notes { get; set; }

        public string PhotoPath { get; set; }


        public string CreatedBy { get; set; }

    }


    public class EditEmployeeModelValidator : AbstractValidator<EditEmployeeModel>
    {
        public EditEmployeeModelValidator()
        {
            try
            {
                RuleFor(expression: x => x.FirstName).NotEmpty().WithMessage("first name is required");
                RuleFor(expression: x => x.EmployeeNumber).NotEmpty().WithMessage("employee number is required");
                RuleFor(expression: x => x.EmailID).NotEmpty().WithMessage("email-id is required");
                RuleFor(expression: x => x.EmailID).EmailAddress().WithMessage("email-id  should be valid");
                    
            }
            catch (Exception ex)
            {
                var er = ex.Message;
            }

        }
      


    }
}
