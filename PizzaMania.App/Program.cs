using System;
using System.Collections.Generic;
using System.Linq;

using PizzaMania.Core.Customizations.Toppings;

namespace PizzaMania.App
{
    class Program
    {
        private static Core.ShopMenu ShopMenu;
        private static ShoppingCart.Cart Cart;

        static void Main(string[] args)
        {
            ShopMenu = MenuBuilder.GetMenu();
            Cart = new ShoppingCart.Cart();

            ShowOptions();
            var choice = Console.ReadLine();

            while (choice.ToLower() != "q")
            {
                switch (choice)
                {
                    case "1":
                        ViewMenu();
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

                ShowOptions();
                choice = Console.ReadLine();
            }
        }

        static void ShowOptions()
        {
            Console.Clear();
            Console.WriteLine("1. Select from Menu.");
            Console.WriteLine("2. View Cart.");
            Console.WriteLine("3. Checkout and place order.");
            Console.WriteLine("4. Clear the Console.");
            Console.WriteLine("q. Quit");
            Console.WriteLine("Choose your option (1, 2, 3, 4, q): ");
        }

        static void ViewMenu()
        {
            var choice = "";

            while (choice != "0")
            {
                ShopMenu.Display();

                Console.WriteLine(Environment.NewLine + $"Choose a pizza from the above list (1 - " +
                    $"{ShopMenu.GetItemsList().Count}):");
                Console.WriteLine("Press 0 to return to main menu...");
                Console.WriteLine("Your choice is ?");

                choice = Console.ReadLine();

                if (int.TryParse(choice, out int value) == true)
                {
                    if (value == 0) return;

                    if (value >= 1 && value <= ShopMenu.GetItemsList().Count)
                    {
                        ChoosePizza(ShopMenu.GetItemsList()[value - 1]);
                        return;
                    }
                    Console.WriteLine("Invalid Choice. Try Again...");
                }
                else
                {
                    Console.WriteLine("Invalid Choice. Try Again...");
                }
            }
        }

        static void ChoosePizza(Core.Pizza pizza)
        {
            var cartItem = new ShoppingCart.CartItem(pizza)
            {
                Size = ChooseSize(pizza.SupportedSize)
            };

            Cart.Add(cartItem);
        }

        static Core.PizzaSize ChooseSize(HashSet<Core.PizzaSize> supportedSizes)
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

        static void ViewCart()
        {
            float total = 0f;
            int index = 0;
            foreach (var item in Cart.Items)
            {
                Console.WriteLine($"{1 + index++}. Pizza: {item.Pizza.Name}, cost: {item.Pizza.GetPrice()}");
                Console.WriteLine($"    Size: {item.Size}");

                var crust = $"{item.ChoiceOfCrust.Value}".CamelCaseToSpaceSeparated();
                Console.WriteLine($"    Crust: {crust}");

                Console.WriteLine($"    Toppings Total Cost: (Total Cost: {item.ChoiceOfToppings.GetPrice()})");
                Console.WriteLine($"        Veg Toppings:");
                foreach (var topping in item.ChoiceOfToppings.VegToppings)
                {
                    var toppingInString = $"{topping}".CamelCaseToSpaceSeparated();
                    Console.WriteLine($"            {toppingInString}");
                }
                Console.WriteLine($"        Non-Veg Toppings:");
                foreach (var topping in item.ChoiceOfToppings.NonVegToppings)
                {
                    var toppingInString = $"{topping}".CamelCaseToSpaceSeparated();
                    Console.WriteLine($"            {toppingInString}");
                }

                var itemTotal = item.GetTotalCost();
                Console.WriteLine($"    Total: {itemTotal}" + Environment.NewLine);
                total += itemTotal;
            }

            if (Cart.Items.Count == 0)
            {
                Console.WriteLine("There were no items in your cart. ");
            }
            else
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine($"Choose number from 1-{Cart.Items.Count} to modify that pizza. " +
                    $"(Note: Invalid choice will take you to main menu.)");

                var choice = Console.ReadLine();

                if (int.TryParse(choice, out int value) == true)
                {
                    if (value >= 1 && value <= Cart.Items.Count)
                    {
                        CustomizeCartItem(Cart.Items[value - 1]);
                    }
                }
            }
        }

        static void CustomizeCartItem(ShoppingCart.CartItem cartItem)
        {
            Console.WriteLine($"Pizza: {cartItem.Pizza.Name}, cost: {cartItem.Pizza.GetPrice()}");
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

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    cartItem.Size = ChooseSize(cartItem.Pizza.SupportedSize);
                    break;
                case "2":
                    ModifyCrust(cartItem);
                    break;
                case "3":
                    AddVegTopping(cartItem);
                    break;
                case "4":
                    RemoveVegTopping(cartItem);
                    break;
                case "5":
                    AddNonVegTopping(cartItem);
                    break;
                case "6":
                    RemoveNonVegTopping(cartItem);
                    break;
                default:
                    break;
            }
        }

        static void RemoveVegTopping(ShoppingCart.CartItem cartItem)
        {
            Console.Clear();
            var vegToppings = cartItem.ChoiceOfToppings.VegToppings;

            Console.WriteLine("Choose a Veg topping to remove:");
            int index = 0;
            foreach (var enumValue in vegToppings)
            {
                Console.WriteLine($"    {1 + index++}. {enumValue}");
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Choose a number: (1-{vegToppings.Count()}). " +
                $"(NOTE: Invalid choice will redirect to main menu)");

            if (int.TryParse(Console.ReadLine(), out int choice) == true)
            {
                if (choice >= 1 && choice <= vegToppings.Count())
                {
                    cartItem.ChoiceOfToppings.RemoveFromVeg(vegToppings[choice - 1]);
                }
            }
        }

        static void RemoveNonVegTopping(ShoppingCart.CartItem cartItem)
        {
            Console.Clear();
            var nonVegToppings = cartItem.ChoiceOfToppings.NonVegToppings;

            Console.WriteLine("Choose a Non-Veg topping to remove:");
            int index = 0;
            foreach (var enumValue in nonVegToppings)
            {
                Console.WriteLine($"    {1 + index++}. {enumValue}");
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Choose a number: (1-{nonVegToppings.Count()}). " +
                $"(NOTE: Invalid choice will redirect to main menu)");

            if (int.TryParse(Console.ReadLine(), out int choice) == true)
            {
                if (choice >= 1 && choice <= nonVegToppings.Count())
                {
                    cartItem.ChoiceOfToppings.RemoveFromNonVeg(nonVegToppings[choice - 1]);
                }
            }
        }

        static void AddVegTopping(ShoppingCart.CartItem cartItem)
        {
            Console.Clear();
            var vegToppings = Util.GetValues<VegTopping>().ToList();

            Console.WriteLine("Choose a Veg topping:");
            int index = 0;
            foreach (var enumValue in vegToppings)
            {
                Console.WriteLine($"    {1 + index++}. {enumValue}");
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Choose a number: (1-{vegToppings.Count()}). " +
                $"(NOTE: Invalid choice will redirect to main menu)");

            if (int.TryParse(Console.ReadLine(), out int choice) == true)
            {
                if (choice >= 1 && choice <= vegToppings.Count())
                {
                    cartItem.AddTopping(vegToppings[choice - 1]);
                }
            }
        }

        static void AddNonVegTopping(ShoppingCart.CartItem cartItem)
        {
            Console.Clear();
            var nonVegToppings = Util.GetValues<NonVegTopping>().ToList();

            Console.WriteLine("Choose a Non-Veg topping:");
            int index = 0;
            foreach (var enumValue in nonVegToppings)
            {
                Console.WriteLine($"    {1 + index++}. {enumValue}");
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Choose a number: (1-{nonVegToppings.Count()}). " +
                $"(NOTE: Invalid choice will redirect to main menu)");

            if (int.TryParse(Console.ReadLine(), out int choice) == true)
            {
                if (choice >= 1 && choice <= nonVegToppings.Count())
                {
                    cartItem.AddTopping(nonVegToppings[choice - 1]);
                }
            }
        }

        static void ModifyCrust(ShoppingCart.CartItem cartItem)
        {
            Console.Clear();
            var crusts = Util.GetValues<Core.Customizations.Crust.Crust>() as List<Core.Customizations.Crust.Crust>;

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
            float total = 0f;
            foreach (var item in Cart.Items)
            {
                Console.WriteLine($"Pizza: {item.Pizza.Name}, cost: {item.Pizza.GetPrice()}");
                Console.WriteLine($"    Size: {item.Size}");

                var crust = $"{item.ChoiceOfCrust.Value}".CamelCaseToSpaceSeparated();
                Console.WriteLine($"    Crust: {crust}");

                Console.WriteLine($"    Toppings Total Cost: (Total Cost: {item.ChoiceOfToppings.GetPrice()})");
                Console.WriteLine($"        Veg Toppings:");
                foreach (var topping in item.ChoiceOfToppings.VegToppings)
                {
                    var toppingInString = $"{topping}".CamelCaseToSpaceSeparated();
                    Console.WriteLine($"            {toppingInString}");
                }
                Console.WriteLine($"        Non-Veg Toppings:");
                foreach (var topping in item.ChoiceOfToppings.NonVegToppings)
                {
                    var toppingInString = $"{topping}".CamelCaseToSpaceSeparated();
                    Console.WriteLine($"            {toppingInString}");
                }

                var itemTotal = item.GetTotalCost();
                Console.WriteLine($"    Total: {itemTotal}" + Environment.NewLine);
                total += itemTotal;
            }

            Console.WriteLine(Environment.NewLine);
            if (Cart.Items.Count == 0)
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
