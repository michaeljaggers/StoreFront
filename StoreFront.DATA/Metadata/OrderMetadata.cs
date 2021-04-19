using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFront.DATA
{
    public class OrderMetadata
    {
        [ScaffoldColumn(false)]
        public int OrderID { get; set; }

        [Required]
        [Display(Name = "Customer Number")]
        public int CustomerID { get; set; }

        [Required]
        [Display(Name = "Date Ordered")]
        public System.DateTime OrderDate { get; set; }

        [Display(Name = "Date Shipped")]
        public Nullable<System.DateTime> ShipDate { get; set; }

        [Display(Name = "Shipping Provider")]
        public Nullable<int> ShipperID { get; set; }

        [Display(Name = "Freight Charge")]
        [DisplayFormat(DataFormatString = "{0:c2}")]
        public Nullable<decimal> Freight { get; set; }

        [Display(Name = "Ship-to Street Address")]
        [StringLength(60, ErrorMessage = "Maximum length is 60 characters.")]
        public string ShipAddress { get; set; }

        [Display(Name = "Ship-to City")]
        [StringLength(20, ErrorMessage = "Maximum length is 20 characters.")]
        public string ShipCity { get; set; }

        [Display(Name = "Ship-to State")]
        [StringLength(15, ErrorMessage = "Maximum length is 15 characters.")]
        public string ShipState { get; set; }

        [Display(Name = "Ship-to Zip Code")]
        [StringLength(10, ErrorMessage = "Maximum length is 10 characters.")]
        public string ShipZip { get; set; }

        [Display(Name = "Ship-to Country")]
        [StringLength(15, ErrorMessage = "Maximum length is 15 characters.")]
        public string ShipCountry { get; set; }
    }

    [MetadataType(typeof(OrderMetadata))]
    public partial class Order { }
}
