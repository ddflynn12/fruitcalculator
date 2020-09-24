using System;
using System.Collections.Generic;
using System.Text;
using Dal.Models;

namespace Dal
{
    public class FruitMarketRepository : Repository<CartItem>
    {
        public FruitMarketRepository()
        {
            Data.Add(new Orange(), true);
            Data.Add(new Apple(), true);
        }
    }
}
