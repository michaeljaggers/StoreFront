using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFront.DATA
{
    public class NicotineMetadata
    {
        [Display(Name = "Nicotine ID")]
        public int NicotineID { get; set; }

        [Required]
        [Display(Name = "Nicotine Strength")]
        [DisplayFormat(DataFormatString = "{0}mg.")]
        public int StrengthMg { get; set; }
    }

    [MetadataType(typeof(NicotineMetadata))]
    public partial class Nicotine { }
}
