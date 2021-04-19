using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFront.DATA
{
    public class OrderDetailMetadata
    {
        [Required]
        [Display(Name = "Order Number")]
        public int OrderID { get; set; }

        [Required]
        [Display(Name = "Product")]
        public int ProductID { get; set; }

        [Required]
        public short Quantity { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0}%")]
        public float Discount { get; set; }
    }

    [MetadataType(typeof(OrderDetailMetadata))]
    public partial class OrderDetail { }
}
