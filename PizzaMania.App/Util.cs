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
            System.Console.WriteLine($"    {index}. {itemName} Pizza");
        }

        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
