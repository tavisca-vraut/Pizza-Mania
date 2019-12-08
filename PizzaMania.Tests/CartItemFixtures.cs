using Xunit;
using FluentAssertions;

using PizzaMania.Cart;
using PizzaMania.Core;
using PizzaMania.Core.Customizations.Toppings;

namespace PizzaMania.Tests
{
    public class CartItemFixtures
    {
        public Pizza Pizza;
        public CartItem CartItem;

        public CartItemFixtures()
        {
            Pizza = new Pizza(PizzaName.ChickenSausage);
            CartItem = new CartItem(Pizza);
        }

        [Fact]
        public void Test_for_initialization_of_cart_item()
        {
            CartItem.ChoiceOfToppings.VegToppings.Count.Should().Be(0);
            CartItem.ChoiceOfToppings.NonVegToppings.Count.Should().Be(0);
        }

        [Fact]
        public void Test_for_total_cost_of_cart_item_without_toppings()
        {
            var actualPrice = CartItem.GetTotalCost();
            var expectedPrice = 225f;
            // Pizza price 125
            // Default Crust Price = 100

            actualPrice.Should().Be(expectedPrice);
        }

        [Fact]
        public void Test_for_total_cost_of_cart_item_with_toppings()
        {
            CartItem.AddTopping(VegTopping.PaneerCubes);
            CartItem.AddTopping(NonVegTopping.HamSlices);

            var actualPrice = CartItem.GetTotalCost();
            var expectedPrice = 625f;
            // Pizza price = 125
            // Default Crust Price = 100
            // Paneer Cubes = 200
            // Ham Slices = 200

            actualPrice.Should().Be(expectedPrice);
        }
    }
}
