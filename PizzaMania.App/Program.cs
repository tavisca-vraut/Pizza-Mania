using System;

namespace PizzaMania.App
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientMenuManager.SetMenu();
            ClientCartManager.Instance = new ShoppingCart.Cart();

            var choice = "";

            while (choice.ToLower() != "q")
            {
                switch (choice)
                {
                    case "1":
                        ClientMenuManager.DisplayMenu();
                        break;
                    case "2":
                        ClientCartManager.DisplayCart();
                        break;
                    case "3":
                        ClientCartManager.Checkout();
                        break;
                }

                if (choice == "3") break;

                AppConsole.ShowMainOptions();
                choice = Console.ReadLine();
            }
        }
    }
}
