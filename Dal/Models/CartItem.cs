using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Models
{
    public class CartItem
    {
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

    }
}
