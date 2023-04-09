using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BM_Blazor_Nov20.Models
{
    public class Company
    {

        public String CompanyId
        {
            get;
            set;
        }

        [Required]
        public String Name
        {
            get;
            set;
        }

        public String BusinessID { get; set; }


        public String BillingAddress { get; set; }

        public String City { get; set; }
        public String Country { get; set; }

        public int InvoiceCount { get; set; }
        public int OrderCount { get; set; }

        public decimal TotalInvoiceAmount { get; set; }

        public decimal PaidInvoiceAmount { get; set; }

        public decimal BalanceAmount { get; set; }



        public decimal TotalTax { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateLastModified { get; set; }

        public string CreatedBy { get; set; }

        public String EmailID { get; set; }

        public String ContactNumber { get; set; }
        public String ContactPerson { get; set; }
        public String ContactTitle { get; set; }

        public string ExtraColumn1 { get; set; }
        public string ExtraColumn2 { get; set; }

        public string ExtraColumn3 { get; set; }
        public string ExtraColumn4 { get; set; }
        public string ExtraColumn5 { get; set; }
        public string ExtraColumn6 { get; set; }

    }
}
