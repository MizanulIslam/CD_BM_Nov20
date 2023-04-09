using System;
using System.ComponentModel.DataAnnotations;

namespace BM_Models
{
    public class Employee
    {
        [Key]
        public string  EmployeeID { get; set; }
       
        public int EmployeeNumber { get; set; }
        
        public string LastName { get; set; }
      

        public string FirstName { get; set; }
        public string JobTitle { get; set; }
        public string Joblevel { get; set; }
        public string TitleOfCourtesy { get; set; }

        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }

      
        
        public string EmailID { get; set; }

        public string ContactNumber { get; set; }

        public string Notes { get; set; }

        public string  ReportsTo { get; set; }
        public string PhotoPath { get; set; }


        public DateTime DateCreated { get; set; }

        public DateTime DateLastModified { get; set; }

        public string CreatedBy { get; set; }


        public string ExtraColumn1 { get; set; }
        public string ExtraColumn2 { get; set; }

        public string ExtraColumn3 { get; set; }
        public string ExtraColumn4 { get; set; }
        public string ExtraColumn5 { get; set; }
        public string ExtraColumn6 { get; set; }

        public virtual Employee EmployeeHead { get; set; }

    }
    //public enum Gender
    //{
    //    Male,
    //    Female,
    //    Other
    //}

}