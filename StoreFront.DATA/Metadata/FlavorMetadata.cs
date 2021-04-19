using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFront.DATA
{
    public class FlavorMetadata
    {
        [ScaffoldColumn(false)]
        public int FlavorID { get; set; }

        [Required]
        [Display(Name = "Flavor")]
        [StringLength(20, ErrorMessage = "Maximum length is 20 characters.")]
        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }
    }

    [MetadataType(typeof(FlavorMetadata))]
    public partial class Flavor { }
}
