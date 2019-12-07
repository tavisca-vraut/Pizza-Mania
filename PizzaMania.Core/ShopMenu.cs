using System;
using System.Collections.Generic;

namespace PizzaMania.Core
{
    public class ShopMenu
    {
        public List<Pizza> Pizzas { get; private set; }

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
    }
}
