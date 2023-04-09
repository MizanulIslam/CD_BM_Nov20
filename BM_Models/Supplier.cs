using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BM_Models
{
    public class Supplier
    {
        [Key]
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public String EmailID { get; set; }

        public String ContactNumber { get; set; }
   

        public String BusinessID { get; set; }


        public String BillingAddress { get; set; }

        public String City { get; set; }
        public String Country { get; set; }

        public int PurchaseInvoiceCount { get; set; }
        public int PurchaseOrderCount { get; set; }

        public decimal TotalPurchaseInvoiceAmount { get; set; }

        public decimal PaidPurchaseInvoiceAmount { get; set; }

        public decimal BalanceAmount { get; set; }



        public decimal TotalTax { get; set; }

        //[DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        //[DataType(DataType.Date)]
        public DateTime DateLastModified { get; set; }

        public string CreatedBy { get; set; }


        public string ExtraColumn1 { get; set; }
        public string ExtraColumn2 { get; set; }

        public string ExtraColumn3 { get; set; }
        public string ExtraColumn4 { get; set; }
        public string ExtraColumn5 { get; set; }
        public string ExtraColumn6 { get; set; }

    }
}
