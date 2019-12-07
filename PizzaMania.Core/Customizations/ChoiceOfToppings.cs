using System.Collections.Generic;

namespace PizzaMania.Core.Customizations
{
    public enum VegTopping
    { 
        PaneerCubes, Mushrooms, BlackOlives, SpicyJalepenos
    }

    public enum NonVegTopping
    {
        BarbequeChicken, ChickenSausage, RoastChicken, SpicyChicken, HamSlices, ShreddedBeef
    }

    public static class ToppingsPrices
    {
        static Dictionary<VegTopping, float> VegToppingsPriceMap = new Dictionary<VegTopping, float>()
        {
            { VegTopping.PaneerCubes, 200 },
            { VegTopping.Mushrooms, 125 }
        };

        static Dictionary<NonVegTopping, float> NonVegToppingsPriceMap = new Dictionary<NonVegTopping, float>()
        {
            { NonVegTopping.BarbequeChicken, 200 },
            { NonVegTopping.ShreddedBeef, 400 }
        };

        public static float GetPriceFor(VegTopping vegTopping)
        {
            return VegToppingsPriceMap.GetValueOrDefault(vegTopping, 150);
        }

        public static float GetPriceFor(NonVegTopping nonVegTopping)
        {
            return NonVegToppingsPriceMap.GetValueOrDefault(nonVegTopping, 200);
        }
    }

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

        public void AddToNonVeg(NonVegTopping nonVegTopping)
        {
            if (NonVegToppings.Contains(nonVegTopping) == false)
            {
                NonVegToppings.Add(nonVegTopping);
            }
        }

        public float GetToppingsPrice()
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
