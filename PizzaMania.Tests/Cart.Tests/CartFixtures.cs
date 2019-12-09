using Xunit;
using FluentAssertions;

namespace PizzaMania.Cart.Tests
{
    public class CartFixtures
    {
        public ShoppingCart.Cart Cart;

        public CartFixtures()
        {
            Cart = new ShoppingCart.Cart();
        }

        [Fact]
        public void Test_for_intialization_of_cart()
        { 
            Cart.Items.Count.Should().Be(0);
        }

        [Fact]
        public void Test_for_addition_of_new_cart_item_to_cart()
        {
            Cart.Add(new ShoppingCart.CartItem(new Core.Pizza(Core.PizzaName.BeefTeriyaki)));
            Cart.Add(new ShoppingCart.CartItem(new Core.Pizza(Core.PizzaName.ChickenKeema)));
            Cart.Add(new ShoppingCart.CartItem(new Core.Pizza(Core.PizzaName.ChickenTikka)));
            Cart.Add(new ShoppingCart.CartItem(new Core.Pizza(Core.PizzaName.HamSalsa)));

            Cart.Items.Count.Should().Be(4);
        }
    }
}
