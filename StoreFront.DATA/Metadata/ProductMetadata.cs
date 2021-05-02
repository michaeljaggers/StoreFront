using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFront.DATA
{
    public class ProductMetadata
    {
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }

        [Required]
        [Display(Name = "Product")]
        [StringLength(40, ErrorMessage = "Maximum length is 40 characters.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        [Display(Name = "Nicotine Stength")]
        public Nullable<int> NicotineID { get; set; }

        [Display(Name = "Flavor")]
        public Nullable<int> FlavorID { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Inventory")]
        public short InStockCt { get; set; }

        [Display(Name = "On Order")]
        public Nullable<short> OnOrderCt { get; set; }

        [Display(Name = "Min. Req. Inventory")]
        public Nullable<short> ReorderCt { get; set; }

        [Display(Name = "Supplier")]
        public Nullable<int> SupplierID { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }
    }

    [MetadataType(typeof(ProductMetadata))]
    public partial class Product { }
}
