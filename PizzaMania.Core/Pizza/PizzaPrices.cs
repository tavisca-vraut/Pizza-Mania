using System.Collections.Generic;

namespace PizzaMania.Core
{
    public static class PizzaPrices
    {
        static Dictionary<PizzaName, float> PizzaPriceMap = new Dictionary<PizzaName, float>()
        {
            { PizzaName.ChickenKeema, 200 },
            { PizzaName.ChickenSausage, 125 }
        };

        public static float GetPriceFor(PizzaName pizzaName)
        {
            return PizzaPriceMap.GetValueOrDefault(pizzaName, 150);
        }
    }
}
