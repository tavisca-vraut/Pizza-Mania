using System.Collections.Generic;
using Xunit;
using FluentAssertions;

using PizzaMania.Core;
using System;

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

        [Fact]
        public void Test_for_retrieving_all_pizzas_on_menu()
        {
            Menu.AddPizza(new Pizza(PizzaName.ChickenKeema));
            Menu.AddPizza(new Pizza(PizzaName.HamSalsa));
            Menu.AddPizza(new Pizza(PizzaName.ChickenPepperoni));
            Menu.AddPizza(new Pizza(PizzaName.ChickenKeema));

            var expectedResult = new List<Pizza>
            {
                new Pizza(PizzaName.ChickenKeema),
                new Pizza(PizzaName.HamSalsa),
                new Pizza(PizzaName.ChickenPepperoni),
            } as IReadOnlyList<Pizza>;

            var actualResult = Menu.GetItemsList();

            actualResult.Should().BeEquivalentTo(expectedResult);
        }
    }
}
