using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFront.DATA
{
    public class ShipperMetadata
    {
        [ScaffoldColumn(false)]
        public int ShipperID { get; set; }

        [Required]
        [Display(Name= "Company")]
        [StringLength(40, ErrorMessage = "Maximum length is 40 characters.")]
        public string Name { get; set; }

        [Display(Name = "Contact First Name")]
        [StringLength(30, ErrorMessage = "Maximum length is 30 characters.")]
        public string ContactFirst { get; set; }

        [Display(Name = "Contact Last Name")]
        [StringLength(30, ErrorMessage = "Maximum length is 30 characters.")]
        public string ContactLast { get; set; }

        [EmailAddress]
        [Display(Name = "Contact Email Address")]
        [StringLength(30, ErrorMessage = "Maximum length is 30 characters.")]
        public string Email { get; set; }

        [Display(Name = "Contact Phone")]
        [StringLength(24, ErrorMessage = "Maximum length is 24 characters.")]
        public string Phone { get; set; }
    }

    [MetadataType(typeof(ShipperMetadata))]
    public partial class Shipper { }
}
