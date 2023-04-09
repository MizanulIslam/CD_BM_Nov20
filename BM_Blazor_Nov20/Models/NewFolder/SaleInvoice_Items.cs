using System.ComponentModel.DataAnnotations;

namespace BM_Blazor_Nov20.Models
{
    public class SaleInvoice_Items
    {
        [Key]
        public string SaleInvoiceItemID { get; set; }
        public string SalesInvoiceID { get; set; }
        public string ItemID { get; set; }

        public string Description { get; set; }

        public string ItemCode { get; set; }

        public string HSNCode { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Discount { get; set; }
        public string TaxID { get; set; }
        public decimal Tax { get; set; }
        public decimal Amount { get; set; }
        public decimal TaxAmount { get; set; }

        public decimal DiscountAmount { get; set; }

        public virtual TaxType TaxType { get; set; }

        public string ExtraColumn1 { get; set; }
        public string ExtraColumn2 { get; set; }

        public string ExtraColumn3 { get; set; }
        public string ExtraColumn4 { get; set; }
        public string ExtraColumn5 { get; set; }
        public string ExtraColumn6 { get; set; }


        public virtual SaleInvoice SaleInvoice { get; set; }
        public virtual Items Items { get; set; }
    }
}