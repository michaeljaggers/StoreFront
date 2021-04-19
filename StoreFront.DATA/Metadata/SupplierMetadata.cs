using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFront.DATA
{
    public class SupplierMetadata
    {
        [ScaffoldColumn(false)]
        public int SupplierID { get; set; }

        [Required]
        [Display(Name = "Supplier Name")]
        [StringLength(40, ErrorMessage = "Maximum length is 40 characters.")]
        public string Company { get; set; }

        [Display(Name = "Supplier Street Address")]
        [StringLength(60, ErrorMessage = "Maximum length is 60 characters.")]
        public string Address { get; set; }

        [Display(Name = "Supplier City")]
        [StringLength(20, ErrorMessage = "Maximum length is 20 characters.")]
        public string City { get; set; }

        [Display(Name = "Supplier State")]
        [StringLength(15, ErrorMessage = "Maximum length is 15 characters.")]
        public string State { get; set; }

        [Display(Name = "Supplier Zip Code")]
        [StringLength(10, ErrorMessage = "Maximum length is 10 characters.")]
        public string Zip { get; set; }

        [Display(Name = "Supplier Country")]
        [StringLength(15, ErrorMessage = "Maximum length is 15 characters.")]
        public string Country { get; set; }

        [EmailAddress]
        [Display(Name = "Contact Email Address")]
        [StringLength(30, ErrorMessage = "Maximum length is 30 characters.")]
        public string Email { get; set; }

        [Display(Name = "Contact Phone")]
        [StringLength(24, ErrorMessage = "Maximum length is 24 characters.")]
        public string Phone { get; set; }

        [Display(Name = "Contact First Name")]
        [StringLength(30, ErrorMessage = "Maximum length is 30 characters.")]
        public string ContactFirst { get; set; }

        [Display(Name = "Contact Last Name")]
        [StringLength(30, ErrorMessage = "Maximum length is 30 characters.")]
        public string ContactLast { get; set; }
    }

    [MetadataType(typeof(SupplierMetadata))]
    public partial class Supplier { }
}
