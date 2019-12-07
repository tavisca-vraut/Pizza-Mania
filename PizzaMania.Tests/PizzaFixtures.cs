using Xunit;
using FluentAssertions;

using PizzaMania.Core;

namespace PizzaMania.Tests
{
    public class PizzaFixtures
    {
        public PizzaName PizzaName { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public Pizza Pizza { get; set; }

        public PizzaFixtures()
        {
            PizzaName = PizzaName.BarbequeChicken;
            Pizza = new Pizza(PizzaName);
        }

        [Fact]
        public void Pizza_test_for_name_initialization()
        {
            Pizza.Name.Should().Be(PizzaName);
        }

        [Fact]
        public void Pizza_test_for_pizza_size()
        {
            Pizza.AddSize(PizzaSize.Regular);
            Pizza.SupportedSize.Should().Contain(PizzaSize.Regular);
        }

        [Fact]
        public void Pizza_comparision()
        {
            var newPizza = new Pizza(PizzaName.BarbequeChicken);

            (newPizza == this.Pizza).Should().Be(true);
            (newPizza != this.Pizza).Should().Be(false);
            (newPizza.Equals(this.Pizza)).Should().Be(true);
        }

    }
}
