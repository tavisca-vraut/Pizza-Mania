using System;
using System.Collections.Generic;

namespace PizzaMania.Core
{
    public class Pizza
    {
        public PizzaName Name { get; }
        public HashSet<PizzaSize> SupportedSize { get; set; }

        public Pizza(PizzaName name)
        {
            Name = name;
            SupportedSize = new HashSet<PizzaSize>();
        }

        public void AddSize(PizzaSize pizzaSize)
        {
            SupportedSize.Add(pizzaSize);
        }   
    }
}
