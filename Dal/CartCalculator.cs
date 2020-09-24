using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dal
{
    public class CartCalculator : ICalculator<Cart>
    {
        private readonly IEnumerable<ICalculator<Cart>> _promotions;

        public CartCalculator(IEnumerable<ICalculator<Cart>> promotions)
        {
            _promotions = promotions;        
        }
        public void Calculate(Cart cart)
        {
            cart.Items.RemoveAll(i => i.Description == "Promotion");
            _promotions.ToList().ForEach(p => p.Calculate(cart));
            cart.Total = cart.Items.Sum(i => i.Price * i.Quantity);
        }
    }
}
