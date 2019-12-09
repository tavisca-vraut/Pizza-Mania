using System.Collections.Generic;

using PizzaMania.Core;

namespace PizzaMania.App
{
    public static class ExtensionMethods
    {
        public static void Display(this ShopMenu shopMenu)
        {
            System.Console.WriteLine("Menu:");
            int index = 0;
            foreach (var item in shopMenu.GetItemsList())
            {
                Util.TabulatedDisplayWithNumber(1 + index++, $"{item.Name}");
            }
        }

        public static string CamelCaseToSpaceSeparated(this string str)
        {
            var listOfWords = new List<string>();

            string word = "";

            foreach (var character in str)
            {
                if (char.IsUpper(character) && string.IsNullOrWhiteSpace(word) == false)
                {
                    listOfWords.Add(word);
                    word = "";
                }
                word = $"{word}{character}";
            }

            if (string.IsNullOrWhiteSpace(word) == false)
            {
                listOfWords.Add(word);
            }

            return string.Join(" ", listOfWords);
        }
    }
}
