using System.Collections.Generic;
using PizzaMania.Core.Customizations.Toppings;

namespace PizzaMania.Core.Customizations.Toppings
{
    public class ChoiceOfToppings
    {
        public List<VegTopping> VegToppings { get; private set; }
        public List<NonVegTopping> NonVegToppings { get; private set; }

        public ChoiceOfToppings()
        {
            VegToppings = new List<VegTopping>();
            NonVegToppings = new List<NonVegTopping>();
        }

        public void AddToVeg(VegTopping vegTopping)
        {
            if (VegToppings.Contains(vegTopping) == false)
            {
                VegToppings.Add(vegTopping);
            }
        }

        public void RemoveFromVeg(VegTopping vegTopping)
        {
            VegToppings.Remove(vegTopping);
        }

        public void AddToNonVeg(NonVegTopping nonVegTopping)
        {
            if (NonVegToppings.Contains(nonVegTopping) == false)
            {
                NonVegToppings.Add(nonVegTopping);
            }
        }

        public void RemoveFromNonVeg(NonVegTopping nonVegTopping)
        {
            NonVegToppings.Remove(nonVegTopping);
        }

        public float GetPrice()
        {
            var price = 0f;

            foreach (var vegTopping in VegToppings)
            {
                price += ToppingsPrices.GetPriceFor(vegTopping);
            }

            foreach (var nonVegTopping in NonVegToppings)
            {
                price += ToppingsPrices.GetPriceFor(nonVegTopping);
            }

            return price;
        }
    }
}
