using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Models
{
    public class Cart
    {
        public Cart()
        {
            Items = new List<CartItem>();
        }

        public Boolean IncludePromotions { get; set; }
        public List<CartItem> Items { get; set; }
        public decimal Total { get; set; }
    }
}
