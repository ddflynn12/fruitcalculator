using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    public class OrangePromtion : ICalculator<Cart>
    {
        public void Calculate(Cart t)
        {
            var orange = t.Items.First(i => i.Description == "Orange");
            if (orange.Quantity == 0)
                return;

            decimal promotionThreshold = 5;

            var groupsOf5 =(int)(Math.Floor(orange.Quantity / promotionThreshold));

            var promotionAmount = orange.Price * promotionThreshold * groupsOf5 * .5M;

            if (promotionAmount > 0)
                t.Items.Add(new CartItem { Description = "Promotion", Price = -promotionAmount, Quantity = 1 });
        }
    }
}
