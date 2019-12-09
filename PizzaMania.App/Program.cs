using System;

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
                        Menu.Display();
                        break;
                    case "2":
                        Cart.Display();
                        break;
                    case "3":
                        Cart.Checkout();
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
    }
}
