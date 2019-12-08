using PizzaMania.Core;
using PizzaMania.Core.Customizations.Crust;
using PizzaMania.Core.Customizations.Toppings;

namespace PizzaMania.ShoppingCart
{
    public class CartItem
    {
        public Pizza Pizza;

        public PizzaSize Size;

        public ChoiceOfCrust ChoiceOfCrust;
        public ChoiceOfToppings ChoiceOfToppings;

        public CartItem(Pizza pizza)
        {
            Pizza = pizza;
            ChoiceOfCrust = new ChoiceOfCrust();
            ChoiceOfToppings = new ChoiceOfToppings();
        }

        public void ChangeCrust(Crust crust)
        {
            ChoiceOfCrust = new ChoiceOfCrust(crust);
        }

        public void AddTopping(VegTopping vegTopping)
        {
            ChoiceOfToppings.AddToVeg(vegTopping);
        }

        public void AddTopping(NonVegTopping nonVegTopping)
        {
            ChoiceOfToppings.AddToNonVeg(nonVegTopping);
        }

        public float GetTotalCost()
        {
            float cost = 0;

            cost += Pizza.GetPrice();
            cost += ChoiceOfCrust.GetPrice();
            cost += ChoiceOfToppings.GetPrice();

            return cost;
        }
    }
}
