using System;
using System.Collections.Generic;
using System.Linq;

using PizzaMania.Core.Customizations.Crust;
using PizzaMania.Core.Customizations.Toppings;

namespace PizzaMania.App
{
    public static class Cart
    {
        public static ShoppingCart.Cart Instance;

        public static void Display()
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
                Util.PrintNoItemsInCart();
            }
            else
            {
                AppConsole.HowToSelectDisplay(Cart.Instance.Items.Count);

                try
                {
                    int cartItemIndex = int.Parse(Console.ReadLine());
                    CustomizeCartItem(Cart.Instance.Items[cartItemIndex - 1]);
                }
                catch (Exception) { }
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
                    Cart.ModifyCrustOfCartItem(cartItem);
                    break;
                case "3":
                    Cart.AddToppingToCartItem<VegTopping>(cartItem);
                    break;
                case "4":
                    Cart.RemoveToppingFromCartItem(cartItem, cartItem.ChoiceOfToppings.VegToppings);
                    break;
                case "5":
                    Cart.AddToppingToCartItem<NonVegTopping>(cartItem);
                    break;
                case "6":
                    Cart.RemoveToppingFromCartItem(cartItem, cartItem.ChoiceOfToppings.NonVegToppings);
                    break;
                default:
                    break;
            }
        }

        public static void Checkout()
        {
            Console.Clear();
            float total = 0f;

            foreach (var item in Cart.Instance.Items)
            {
                AppConsole.ItemDisplay(item);
                total += item.GetTotalCost();
            }

            AppConsole.OrderPlacedDisplay(total);
        }

        public static void ModifyCrustOfCartItem(ShoppingCart.CartItem cartItem)
        {
            Console.Clear();
            Console.WriteLine("Choose a crust:");

            AppConsole.EnumValuesDisplay<Crust>();

            try
            {
                int index = int.Parse(Console.ReadLine());
                cartItem.ChangeCrust(Util.EnumAtIndex<Crust>(index - 1));
            }
            catch (Exception) { }
        }

        public static void AddToppingToCartItem<T>(ShoppingCart.CartItem cartItem)
        {
            Console.Clear();
            Console.WriteLine("Choose a topping:");

            var toppings = Util.GetValues<T>().ToList();
            Util.PrintList(toppings);

            AppConsole.HowToSelectDisplay(toppings.Count());

            try
            {
                int toppingIndex = int.Parse(Console.ReadLine());
                cartItem.ChoiceOfToppings.Add(toppings[toppingIndex - 1]);
            }
            catch (Exception) { }
        }

        public static void RemoveToppingFromCartItem<T>(ShoppingCart.CartItem cartItem, List<T> toppings)
        {
            Console.Clear();
            Console.WriteLine("Choose a topping:");

            Util.PrintList(toppings);

            AppConsole.HowToSelectDisplay(toppings.Count());

            try
            {
                int toppingIndex = int.Parse(Console.ReadLine());
                cartItem.ChoiceOfToppings.Remove(toppings[toppingIndex - 1]);
            }
            catch (Exception) { }
        }
    }
}
