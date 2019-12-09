using System;
using System.Collections.Generic;
using System.Text;

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
            Console.WriteLine("4. Clear the Console.");
            Console.WriteLine("q. Quit");
            Console.WriteLine("Choose your option (1, 2, 3, 4, q): ");
        }

        public static void ItemDisplay(ShoppingCart.CartItem cartItem)
        {
            Console.WriteLine($"Pizza: {cartItem.Pizza.Name}, Base Cost: {cartItem.Pizza.GetPrice()}");
            Console.WriteLine($"    Size: {cartItem.Size}");

            var crust = $"{cartItem.ChoiceOfCrust.Value}".CamelCaseToSpaceSeparated();
            Console.WriteLine($"    Crust: {crust}");

            Console.WriteLine($"    Toppings Total Cost: (Total Cost: {cartItem.ChoiceOfToppings.GetPrice()})");
            Console.WriteLine($"        Veg Toppings:");
            foreach (var topping in cartItem.ChoiceOfToppings.VegToppings)
            {
                var toppingInString = $"{topping}".CamelCaseToSpaceSeparated();
                Console.WriteLine($"            {toppingInString}");
            }
            Console.WriteLine($"        Non-Veg Toppings:");
            foreach (var topping in cartItem.ChoiceOfToppings.NonVegToppings)
            {
                var toppingInString = $"{topping}".CamelCaseToSpaceSeparated();
                Console.WriteLine($"            {toppingInString}");
            }

            var itemTotal = cartItem.GetTotalCost();
            Console.WriteLine($"    Total: {itemTotal}" + Environment.NewLine);
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
    }
}
