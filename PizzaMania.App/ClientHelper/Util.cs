using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaMania.App
{
    public static class Util
    {
        public static void TabulatedDisplayWithNumber(int index, string name)
        {
            var itemName = name.CamelCaseToSpaceSeparated();
            Console.WriteLine($"\t{index}. {itemName} Pizza");
        }

        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static T EnumAtIndex<T>(int index)
        {
            return GetValues<T>().ToList()[index];
        }

        public static void PrintList<T>(List<T> list)
        {
            int index = 0;
            foreach (var value in list)
            {
                Console.WriteLine($"\t{1 + index++}. {value}");
            }
        }

        public static void PrintNoItemsInCart()
        {
            Console.WriteLine("There were no items in your cart. ");
        }
    }
}
