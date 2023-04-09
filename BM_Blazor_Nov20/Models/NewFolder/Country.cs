using System.ComponentModel.DataAnnotations;

namespace BM_Blazor_Nov20.Models
{
    public class Country
    {
        public string CountryID { get; set; }
        public string CountryCode { get; set; }
        [Required]
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