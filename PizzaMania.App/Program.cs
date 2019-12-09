using System;
using System.Linq;

using PizzaMania.Core.Customizations.Toppings;
using PizzaMania.Core.Customizations.Crust;
using System.Collections.Generic;

namespace PizzaMania.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.SetMenu();
            Cart.Instance = new ShoppingCart.Cart();

            var choice = "4";

            while (choice.ToLower() != "q")
            {
                switch (choice)
                {
                    case "1":
                        Menu.View();
                        break;
                    case "2":
                        ViewCart();
                        break;
                    case "3":
                        Checkout();
                        break;
                    case "4":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice. Please try again...");
                        break;
                }

                if (choice == "3") break;

                AppConsole.ShowMainOptions();
                choice = Console.ReadLine();
            }
        }

        static void ViewCart()
        {
            float total = 0f;
            int index = 0;

            Console.Clear();
            foreach (var item in Cart.Instance.Items)
            {
                Console.Write($"{1 + index++}. ");
                AppConsole.ItemDisplay(item);
                total += item.GetTotalCost();
            }

            if (Cart.Instance.Items.Count == 0)
            {
                Console.WriteLine("There were no items in your cart. ");
            }
            else
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine($"Choose number from 1-{Cart.Instance.Items.Count} to modify that pizza. " +
                    $"(Note: Invalid choice will take you to main menu.)");

                var choice = Console.ReadLine();

                if (int.TryParse(choice, out int value) == true)
                {
                    if (value >= 1 && value <= Cart.Instance.Items.Count)
                    {
                        CustomizeCartItem(Cart.Instance.Items[value - 1]);
                    }
                }
            }
        }

        static void CustomizeCartItem(ShoppingCart.CartItem cartItem)
        {
            Console.Clear();
            AppConsole.ItemDisplay(cartItem);
            AppConsole.CartItemOptionsDisplay();

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    cartItem.Size = Menu.ChooseSize(cartItem.Pizza.SupportedSize);
                    break;
                case "2":
                    ModifyCrust(cartItem);
                    break;
                case "3":
                    AddTopping<VegTopping>(cartItem);
                    break;
                case "4":
                    RemoveTopping(cartItem, cartItem.ChoiceOfToppings.VegToppings);
                    break;
                case "5":
                    AddTopping<NonVegTopping>(cartItem);
                    break;
                case "6":
                    RemoveTopping(cartItem, cartItem.ChoiceOfToppings.NonVegToppings);
                    break;
                default:
                    break;
            }
        }

        static void AddTopping<T>(ShoppingCart.CartItem cartItem)
        {
            Console.Clear();
            var toppings = Util.GetValues<T>().ToList();

            Console.WriteLine("Choose a topping:");
            int index = 0;
            foreach (var enumValue in toppings)
            {
                Console.WriteLine($"    {1 + index++}. {enumValue}");
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Choose a number: (1-{toppings.Count()}). " +
                $"(NOTE: Invalid choice will redirect to main menu)");

            if (int.TryParse(Console.ReadLine(), out int choice) == true)
            {
                if (choice >= 1 && choice <= toppings.Count())
                {
                    cartItem.ChoiceOfToppings.Add(toppings[choice - 1]);
                }
            }
        }

        static void RemoveTopping<T>(ShoppingCart.CartItem cartItem, List<T> toppings)
        {
            Console.Clear();

            Console.WriteLine("Choose a topping to remove:");
            int index = 0;
            foreach (var enumValue in toppings)
            {
                Console.WriteLine($"    {1 + index++}. {enumValue}");
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Choose a number: (1-{toppings.Count()}). " +
                $"(NOTE: Invalid choice will redirect to main menu)");

            if (int.TryParse(Console.ReadLine(), out int choice) == true)
            {
                if (choice >= 1 && choice <= toppings.Count())
                {
                    cartItem.ChoiceOfToppings.Remove(toppings[choice - 1]);
                }
            }
        }

        static void ModifyCrust(ShoppingCart.CartItem cartItem)
        {
            Console.Clear();
            var crusts = Util.GetValues<Crust>().ToList();

            Console.WriteLine("Choose a crust:");
            int index = 0;
            foreach (var enumValue in crusts)
            {
                Console.WriteLine($"    {1 + index++}. {enumValue}");
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Choose a number: (1-{crusts.Count()}). (NOTE: Invalid choice will redirect to main menu)");

            if (int.TryParse(Console.ReadLine(), out int choice) == true)
            {
                if (choice >= 1 && choice <= crusts.Count())
                {
                    cartItem.ChangeCrust(crusts[choice - 1]);
                }
            }
        }

        static void Checkout()
        {
            Console.Clear();

            float total = 0f;
            foreach (var item in Cart.Instance.Items)
            {
                AppConsole.ItemDisplay(item);
                total += item.GetTotalCost();
            }

            Console.WriteLine(Environment.NewLine);
            if (Cart.Instance.Items.Count == 0)
            {
                Console.WriteLine("There were no items in your cart. ");
            }
            else
            {
                Console.WriteLine($"Total cost of all items: {total}");

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Payment received. Order Placed!");
                Console.WriteLine("Please Visit Again.");
            }
        }
    }
}
