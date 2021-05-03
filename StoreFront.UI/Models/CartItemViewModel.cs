using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using StoreFront.DATA;

namespace StoreFront.UI.Models
{
    public class CartItemViewModel
    {
        [Range(1,byte.MaxValue,ErrorMessage = "Please enter a quantity between 1 and 255.")]
        public int Qty { get; set; }

        public Product Product { get; set; }

        public CartItemViewModel(int qty, Product product)
        {
            Qty = qty;
            Product = product;
        }
    }
}