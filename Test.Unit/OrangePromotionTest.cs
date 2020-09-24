using Dal;
using Dal.Models;
using System;
using System.Linq;
using Xunit;

namespace Test.Unit
{
    public class OrangePromotionTest
    {
        [Fact]
        public void Calculate_Promotion_Applied()
        {
            // Arrange
            var target = new OrangePromtion();
            var cart = new Cart();
            var orange = new Orange { Quantity = 5 };
            cart.Items.Add(orange);

            // Act
            target.Calculate(cart);

            // Assert
            Assert.Single<CartItem>(cart.Items, i => i.Description == "Promotion");
            Assert.Equal(-25M, cart.Items.First(i => i.Description == "Promotion").Price);
        }
    }
}
