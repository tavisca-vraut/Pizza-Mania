using System;
using System.Linq;

namespace PizzaMania.App
{
    public static class AppConsole
    {
        public static void ShowMainOptions()
        {
            Console.Clear();
            Console.WriteLine("1. Select from Menu.");
            Console.WriteLine("2. View Cart.");
            Console.WriteLine("3. Checkout and place order.");
            Console.WriteLine("q. Quit");
            Console.WriteLine("Choose your option (1, 2, 3, q): ");
        }

        public static void ItemDisplay(ShoppingCart.CartItem cartItem)
        {
            Console.WriteLine($"Pizza: {cartItem.Pizza.Name}, Base Cost: {cartItem.Pizza.GetPrice()}");
            Console.WriteLine($"\tSize: {cartItem.Size}");

            var crust = $"{cartItem.ChoiceOfCrust.Value}".CamelCaseToSpaceSeparated();
            Console.WriteLine($"\tCrust: {crust}");

            if (cartItem.ChoiceOfToppings.VegToppings.Count != 0 || 
                cartItem.ChoiceOfToppings.NonVegToppings.Count != 0)
            {
                Console.WriteLine($"\tToppings Total Cost: (Total Cost: {cartItem.ChoiceOfToppings.GetPrice()})");
            }

            if (cartItem.ChoiceOfToppings.VegToppings.Count != 0)
            {
                Console.WriteLine($"\t\tVeg Toppings:");
                foreach (var topping in cartItem.ChoiceOfToppings.VegToppings)
                {
                    var toppingInString = $"{topping}".CamelCaseToSpaceSeparated();
                    Console.WriteLine($"\t\t\t{toppingInString}");
                }
            }

            if (cartItem.ChoiceOfToppings.NonVegToppings.Count != 0)
            {
                Console.WriteLine($"\t\tNon-Veg Toppings:");
                foreach (var topping in cartItem.ChoiceOfToppings.NonVegToppings)
                {
                    var toppingInString = $"{topping}".CamelCaseToSpaceSeparated();
                    Console.WriteLine($"\t\t\t{toppingInString}");
                }
            }

            var itemTotal = cartItem.GetTotalCost();
            Console.WriteLine($"\tTotal: {itemTotal}" + Environment.NewLine);
        }

        public static void CartItemOptionsDisplay()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("1. Modify Size.");
            Console.WriteLine("2. Modify Crust.");
            Console.WriteLine("3. Add Veg topping.");
            Console.WriteLine("4. Remove Veg topping.");
            Console.WriteLine("5. Add Non-Veg topping.");
            Console.WriteLine("6. Remove Non-Veg topping.");
            Console.WriteLine("Enter number (1-6) to customize the item.");
            Console.WriteLine("Anything else to go back to main menu.");
            Console.WriteLine("Your choice?");
        }

        public static void HowToSelectDisplay(int maxCount)
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Choose a number: (1-{maxCount}). " +
                $"(NOTE: Invalid choice will redirect to main menu)");
        }

        public static void OrderPlacedDisplay(float cost)
        {
            Console.WriteLine(Environment.NewLine);
            if (cost == 0)
            {
                Util.PrintNoItemsInCart();
            }
            else
            {
                Console.WriteLine($"Total cost of all items: {cost}");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Payment received. Order Placed!");
                Console.WriteLine("Please Visit Again.");
            }
        }

        public static void EnumValuesDisplay<T>() where T : Enum
        {
            var values = Util.GetValues<T>().ToList();
            int index = 0;
            foreach (var enumValue in values)
            {
                var value = $"{enumValue}".CamelCaseToSpaceSeparated();
                Console.WriteLine($"\t{1 + index++}. {value}");
            }
            AppConsole.HowToSelectDisplay(values.Count());
        }
    }
}
