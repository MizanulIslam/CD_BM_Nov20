using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BM_Models
{
    public class TaxType
    {
        [Key]
        public string TaxID { get; set; }


        public string CountryID { get; set; }
        public string CountryName { get; set; }

        public string TaxName { get; set; }
        public decimal Tax { get; set; }

        public virtual ICollection<SubTax> SubTax { get; set; }

        public virtual Country Country { get; set; }

        public string ExtraColumn1 { get; set; }
        public string ExtraColumn2 { get; set; }

        public string ExtraColumn3 { get; set; }
        public string ExtraColumn4 { get; set; }
        public string ExtraColumn5 { get; set; }
        public string ExtraColumn6 { get; set; }


    }
}