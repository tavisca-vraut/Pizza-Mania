using Xunit;
using FluentAssertions;

namespace PizzaMania.Cart.Tests
{
    public class CartFixtures
    {
        public CartFixtures()
        {
        }

        [Fact]
        public void Test_for_intialization_of_cart()
        {
            var cart = new ShoppingCart.Cart();

        }
    }
}
