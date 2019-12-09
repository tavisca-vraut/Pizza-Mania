using Xunit;
using FluentAssertions;

using PizzaMania.Core.Customizations.Toppings;

namespace PizzaMania.Customizations.Tests
{
    public class ChoiceOfToppingsFixtures
    {
        public ChoiceOfToppings ChoiceOfToppings{ get; set; }

        public ChoiceOfToppingsFixtures()
        {
            ChoiceOfToppings = new ChoiceOfToppings();
        }

        [Fact]
        public void Test_for_initialization_of_toppings()
        {
            ChoiceOfToppings.NonVegToppings.Count.Should().Be(0);
            ChoiceOfToppings.VegToppings.Count.Should().Be(0);
        }

        [Fact]
        public void Test_for_additions_to_veg_toppings()
        {
            ChoiceOfToppings.Add(VegTopping.PaneerCubes);

            ChoiceOfToppings.VegToppings.Count.Should().Be(1);
            ChoiceOfToppings.VegToppings.Should().Contain(VegTopping.PaneerCubes);
        }

        [Fact]
        public void Test_for_additions_to_non_veg_toppings()
        {
            ChoiceOfToppings.Add(NonVegTopping.ShreddedBeef);

            ChoiceOfToppings.NonVegToppings.Count.Should().Be(1);
            ChoiceOfToppings.NonVegToppings.Should().Contain(NonVegTopping.ShreddedBeef);
        }

        [Fact]
        public void Test_for_avoiding_additions_of_duplicate_toppings()
        {
            ChoiceOfToppings.Add(VegTopping.PaneerCubes);
            ChoiceOfToppings.Add(NonVegTopping.ShreddedBeef);

            ChoiceOfToppings.Add(VegTopping.PaneerCubes);
            ChoiceOfToppings.Add(NonVegTopping.ShreddedBeef);

            ChoiceOfToppings.VegToppings.Count.Should().Be(1);
            ChoiceOfToppings.VegToppings.Should().Contain(VegTopping.PaneerCubes);

            ChoiceOfToppings.NonVegToppings.Count.Should().Be(1);
            ChoiceOfToppings.NonVegToppings.Should().Contain(NonVegTopping.ShreddedBeef);
        }

        [Fact]
        public void Test_for_toppings_prices()
        {
            ChoiceOfToppings.Add(VegTopping.PaneerCubes);  // 200
            ChoiceOfToppings.Add(VegTopping.SpicyJalepenos);  // 150
            ChoiceOfToppings.Add(VegTopping.BlackOlives);  // 150
            // total = 500

            ChoiceOfToppings.Add(NonVegTopping.HamSlices);  // 200
            ChoiceOfToppings.Add(NonVegTopping.ShreddedBeef);  // 400
            // total = 600


            var actualPrice = ChoiceOfToppings.GetPrice();
            var expectedPrice = 1100f;

            actualPrice.Should().Be(expectedPrice);
        }
    }
}
