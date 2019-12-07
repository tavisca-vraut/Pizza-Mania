using System.Collections.Generic;

namespace PizzaMania.Core.Customizations.Crust
{
    public static class CrustPrices
    {
        static Dictionary<Crust, float> PriceMap = new Dictionary<Crust, float>()
        {
            { Crust.CheeseBlast, 125 },
            { Crust.ChickenCheeseBlast, 150 },
            { Crust.Default, 100 }
        };

        public static float GetPriceFor(Crust crust)
        {
            return PriceMap.GetValueOrDefault(crust, 200);
        }
    }
}
