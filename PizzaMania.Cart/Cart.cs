using System.Collections.Generic;

namespace PizzaMania.ShoppingCart
{
    public class Cart
    {
        public List<CartItem> Items;

        public Cart()
        {
            Items = new List<CartItem>();
        }

        public void Add(CartItem cartItem)
        {
            Items.Add(cartItem);
        }
    }
}
