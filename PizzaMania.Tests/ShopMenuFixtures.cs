using Xunit;
using FluentAssertions;

using PizzaMania.Core;

namespace PizzaMania.Tests
{
    public class ShopMenuFixtures
    {
        public ShopMenu Menu { get; set; }
        public ShopMenuFixtures()
        {
            this.Menu = new ShopMenu();
        }

        [Fact]
        public void Test_for_shop_menu_initialization()
        {
            Menu.Pizzas.Count.Should().Be(0);
        }

        [Fact]
        public void Test_for_addition_of_pizza_in_list()
        {
            Menu.AddPizza(new Pizza(PizzaName.ChickenKeema));

            Menu.Pizzas.Count.Should().Be(1);
        }

        [Fact]
        public void Existing_pizza_should_not_be_added()
        {
            Menu.AddPizza(new Pizza(PizzaName.ChickenKeema));
            Menu.AddPizza(new Pizza(PizzaName.ChickenKeema));

            Menu.Pizzas.Count.Should().Be(1);
        }

        [Fact]
        public void Different_pizza_should_be_added()
        {
            Menu.AddPizza(new Pizza(PizzaName.ChickenKeema));
            Menu.AddPizza(new Pizza(PizzaName.HamSalsa));
            Menu.AddPizza(new Pizza(PizzaName.ChickenPepperoni));
            Menu.AddPizza(new Pizza(PizzaName.ChickenKeema));

            Menu.Pizzas.Count.Should().Be(3);
        }
    }
}
