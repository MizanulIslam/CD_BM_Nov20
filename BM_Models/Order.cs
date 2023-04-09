using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BM_Models
{
    public class Order
    {
        [Key]
        public string OrderID { get; set; }
        public string OrderNumber { get; set; }
        public string CustomerID { get; set; }
        
        public string CustomerName { get; set; }
        public string EmployeeID { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime OrderDate { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate
        {
            get; set;
        }
        public string BillingAddress { get; set; }

        public string ShippingAddress { get; set; }
        public string Condition { get; set; }
        public decimal TotalAmountBeforeTax { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalAmount { get; set; }
        public string Remarks { get; set; }

        public string ExtraColumn1 { get; set; }
        public string ExtraColumn2 { get; set; }

        public string ExtraColumn3 { get; set; }
        public string ExtraColumn4 { get; set; }
        public string ExtraColumn5 { get; set; }
        public string ExtraColumn6 { get; set; }


        public virtual Company Company { get; set; }

        public virtual Employee Employee { get; set; }


        public virtual ICollection<Order_Items> Order_Items { get; set; }


    }
}
