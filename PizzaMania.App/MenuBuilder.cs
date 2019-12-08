using PizzaMania.Core;
using PizzaMania.Core.Customizations;

namespace PizzaMania.App
{
    public static class MenuBuilder
    {
        public static ShopMenu GetMenu()
        {
            var menu = new ShopMenu();

            var pizza = new Pizza(PizzaName.BarbequeChicken);
            pizza.AddSize(PizzaSize.Large);
            pizza.AddSize(PizzaSize.Medium);
            pizza.AddSize(PizzaSize.Regular);
            menu.AddPizza(pizza);

            pizza = new Pizza(PizzaName.BeefTeriyaki);
            pizza.AddSize(PizzaSize.Large);
            menu.AddPizza(pizza);

            pizza = new Pizza(PizzaName.ChickenSausage);
            pizza.AddSize(PizzaSize.Medium);
            pizza.AddSize(PizzaSize.Regular);
            menu.AddPizza(pizza);

            pizza = new Pizza(PizzaName.ChickenPepperoni);
            pizza.AddSize(PizzaSize.Large);
            pizza.AddSize(PizzaSize.Medium);
            menu.AddPizza(pizza);

            pizza = new Pizza(PizzaName.ChickenTikka);
            pizza.AddSize(PizzaSize.Large);
            pizza.AddSize(PizzaSize.Medium);
            pizza.AddSize(PizzaSize.Regular);
            menu.AddPizza(pizza);

            pizza = new Pizza(PizzaName.PaneerTikka);
            pizza.AddSize(PizzaSize.Medium);
            pizza.AddSize(PizzaSize.Regular);
            menu.AddPizza(pizza);

            pizza = new Pizza(PizzaName.ChickenKeema);
            pizza.AddSize(PizzaSize.Large);
            pizza.AddSize(PizzaSize.Medium);
            menu.AddPizza(pizza);

            return menu;
        }
    }
}
