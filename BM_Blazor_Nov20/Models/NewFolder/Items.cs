using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BM_Blazor_Nov20.Models
{
    public class Items
    { 
    
        [Key]
        public string  ItemID { get; set; }
        [Required]
        public string ItemName { get; set; }

        public string ItemNumber { get; set; }

        public string ItemCode { get; set; }

        public string ItemHSNCode { get; set; }

        public string SupplierID { get; set; }
        
        public string QuantityPerUnit { get; set; }
        public decimal  UnitPrice { get; set; }
        public decimal UnitsInStock { get; set; }
        public decimal UnitsOnOrder { get; set; }
        public decimal  ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateLastModified { get; set; }

        public string CreatedBy { get; set; }

        public string ExtraColumn1 { get; set; }
        public string ExtraColumn2 { get; set; }

        public string ExtraColumn3 { get; set; }
        public string ExtraColumn4 { get; set; }
        public string ExtraColumn5 { get; set; }
        public string ExtraColumn6 { get; set; }
        public virtual ICollection<Order_Items> Order_Items { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
