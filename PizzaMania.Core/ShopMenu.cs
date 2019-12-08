using System.Collections.Generic;

namespace PizzaMania.Core
{
    public class ShopMenu
    {
        private List<Pizza> Pizzas { get; set; }

        public ShopMenu()
        {
            Pizzas = new List<Pizza>();
        }

        public void AddPizza(Pizza pizza)
        {
            if (Pizzas.Contains(pizza) == false)
            {
                Pizzas.Add(pizza);
            }
        }

        public IReadOnlyList<Pizza> GetItemsList()
        {
            return Pizzas;
        }
    }
}
