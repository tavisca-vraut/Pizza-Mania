using System;
using System.Collections.Generic;
using System.Linq;
using PizzaMania.Core;

namespace PizzaMania.App
{
    public static class Menu
    {
        public static ShopMenu Instance;

        public static void SetMenu()
        {
            Instance = new ShopMenu();

            var pizza = new Pizza(PizzaName.BarbequeChicken);
            pizza.AddSize(PizzaSize.Large);
            pizza.AddSize(PizzaSize.Medium);
            pizza.AddSize(PizzaSize.Regular);
            Instance.AddPizza(pizza);

            pizza = new Pizza(PizzaName.BeefTeriyaki);
            pizza.AddSize(PizzaSize.Large);
            Instance.AddPizza(pizza);

            pizza = new Pizza(PizzaName.ChickenSausage);
            pizza.AddSize(PizzaSize.Medium);
            pizza.AddSize(PizzaSize.Regular);
            Instance.AddPizza(pizza);

            pizza = new Pizza(PizzaName.ChickenPepperoni);
            pizza.AddSize(PizzaSize.Large);
            pizza.AddSize(PizzaSize.Medium);
            Instance.AddPizza(pizza);

            pizza = new Pizza(PizzaName.ChickenTikka);
            pizza.AddSize(PizzaSize.Large);
            pizza.AddSize(PizzaSize.Medium);
            pizza.AddSize(PizzaSize.Regular);
            Instance.AddPizza(pizza);

            pizza = new Pizza(PizzaName.PaneerTikka);
            pizza.AddSize(PizzaSize.Medium);
            pizza.AddSize(PizzaSize.Regular);
            Instance.AddPizza(pizza);

            pizza = new Pizza(PizzaName.AalooSpecial);
            pizza.AddSize(PizzaSize.Medium);
            pizza.AddSize(PizzaSize.Regular);
            Instance.AddPizza(pizza);

            pizza = new Pizza(PizzaName.FalanaFalanaSabzi);
            pizza.AddSize(PizzaSize.Large);
            pizza.AddSize(PizzaSize.Medium);
            Instance.AddPizza(pizza);

            pizza = new Pizza(PizzaName.Margherita);
            pizza.AddSize(PizzaSize.Medium);
            pizza.AddSize(PizzaSize.Regular);
            Instance.AddPizza(pizza);

            pizza = new Pizza(PizzaName.ChickenKeema);
            pizza.AddSize(PizzaSize.Large);
            pizza.AddSize(PizzaSize.Medium);
            Instance.AddPizza(pizza);
        }

        public static void Display()
        {
            Console.Clear();

            var choice = "";

            while (choice != "0")
            {
                Instance.Display();

                Console.WriteLine(Environment.NewLine + $"Choose a pizza from the above list (1 - " +
                    $"{Instance.GetItemsList().Count}):");
                Console.WriteLine("Press 0 to return to main menu...");
                Console.WriteLine("Your choice is ?");

                try
                {
                    int value = int.Parse(Console.ReadLine());
                    ChoosePizza(Instance.GetItemsList()[value - 1]);
                    return;
                }
                catch (Exception) { }

                Console.Clear();
                Console.WriteLine("Invalid Choice. Try Again...");
                Console.WriteLine(Environment.NewLine);
            }
        }

        public static void ChoosePizza(Pizza pizza)
        {
            var cartItem = new ShoppingCart.CartItem(pizza)
            {
                Size = ChooseSize(pizza.SupportedSize)
            };

            Cart.Instance.Add(cartItem);
        }

        public static PizzaSize ChooseSize(HashSet<PizzaSize> supportedSizes)
        {
            if (supportedSizes.Count == 1)
            {
                return supportedSizes.ToArray()[0];
            }

            Console.Clear();
            Console.WriteLine($"Select a size (1 - {supportedSizes.Count}): " +
                $"(NOTE:- Invalid choice will select the first size by default.)");

            var index = 0;
            var sizes = supportedSizes.ToArray();

            foreach (var size in sizes)
            {
                Util.TabulatedDisplayWithNumber(1 + index++, $"{size}");
            }
            Console.WriteLine("Your chooice?");
            var choice = Console.ReadLine();

            if (int.TryParse(choice, out int value) == true)
            {
                if (value >= 1 && value <= supportedSizes.Count)
                {
                    return sizes[value - 1];
                }
            }

            return sizes[0];
        }
    }
}
