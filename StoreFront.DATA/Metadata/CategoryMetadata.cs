using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFront.DATA
{
    public class CategoryMetadata
    {
        [ScaffoldColumn(false)]
        public int CategoryID { get; set; }

        [Required]
        [Display(Name = "Category")]
        [StringLength(30, ErrorMessage = "Maximum length is 30 characters.")]
        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }
    }

    [MetadataType(typeof(CategoryMetadata))]
    public partial class Category { }
}
