using System;
using System.Collections.Generic;
using System.Text;
using Dal.Models;

namespace Dal
{
    public class PromotionRepository : Repository<ICalculator<Cart>>
    {
        public PromotionRepository()
        {
            Data.Add(new OrangePromtion(), true);
        }
    }
}
