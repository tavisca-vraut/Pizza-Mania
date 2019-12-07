using Xunit;
using FluentAssertions;

using PizzaMania.Core.Customizations.Crust;

namespace PizzaMania.Tests.Customizations.Tests
{
    public class ChoiceOfCrustFixtures
    {
        ChoiceOfCrust ChoiceOfCrust { get; set; }
        public ChoiceOfCrustFixtures()
        {
            ChoiceOfCrust = new ChoiceOfCrust();
        }

        [Fact]
        public void Test_for_initialization_of_choice_of_crust()
        {
            this.ChoiceOfCrust.Value.Should().Be(Crust.Default);
        }

        [Fact]
        public void Test_for_getting_price_of_choice_of_crust()
        {
            var actualPrice = ChoiceOfCrust.GetPrice();
            var expectedPrice = CrustPrices.GetPriceFor(ChoiceOfCrust.Value);

            actualPrice.Should().Be(expectedPrice);
        }
    }
}
