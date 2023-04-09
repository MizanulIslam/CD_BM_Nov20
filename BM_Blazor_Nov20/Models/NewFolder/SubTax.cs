using System.ComponentModel.DataAnnotations;

namespace BM_Blazor_Nov20.Models
{
    public class SubTax
    {
        [Key]
        public string TaxID { get; set; }
        public decimal SubTaxName { get; set; }
        public decimal Tax { get; set; }

        public string ExtraColumn1 { get; set; }
        public string ExtraColumn2 { get; set; }

        public string ExtraColumn3 { get; set; }
        public string ExtraColumn4 { get; set; }
        public string ExtraColumn5 { get; set; }
        public string ExtraColumn6 { get; set; }
    }
}