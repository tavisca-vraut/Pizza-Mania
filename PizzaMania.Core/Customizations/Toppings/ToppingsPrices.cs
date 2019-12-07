using System.Collections.Generic;

namespace PizzaMania.Core.Customizations.Toppings
{
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
}
