using System;
using System.Collections.Generic;

namespace PizzaMania.Core
{
    public class Pizza: IEquatable<Pizza>
    {
        public PizzaName Name { get; }
        public HashSet<PizzaSize> SupportedSize { get; set; }

        public Pizza(PizzaName name)
        {
            Name = name;
            SupportedSize = new HashSet<PizzaSize>();
        }

        public void AddSize(PizzaSize pizzaSize)
        {
            SupportedSize.Add(pizzaSize);
        }

        public static bool operator ==(Pizza pizza1, Pizza pizza2)
        {
            return pizza1.Name == pizza2.Name;
        }

        public static bool operator !=(Pizza pizza1, Pizza pizza2)
        {
            return pizza1.Name != pizza2.Name;
        }

        public bool Equals(Pizza pizza)
        {
            return this.Name == pizza.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((Pizza)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Name.GetHashCode();
                hashCode = (hashCode * 397) ^ SupportedSize.GetHashCode();
                return hashCode;
            }
        }
    }
}
