

using System.ComponentModel.DataAnnotations;

namespace BM_Models
{
    public class Country
    {
        [Key]
        public string CountryID { get; set; }
        public string CountryCode { get; set; }
        
        public string CountryName { get; set; }

        public string Currency { get; set; }

        public string CurrencySymbol { get; set; }

        public string ExtraColumn1 { get; set; }
        public string ExtraColumn2 { get; set; }

        public string ExtraColumn3 { get; set; }
        public string ExtraColumn4 { get; set; }
        public string ExtraColumn5 { get; set; }
        public string ExtraColumn6 { get; set; }


    }
}