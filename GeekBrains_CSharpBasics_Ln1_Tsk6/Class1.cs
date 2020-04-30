using System;
using System.Text.RegularExpressions;

//Ремизов Павел
/*
 * *Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause).
*/

namespace ExtensionMethods
{
    //add reference to .dll file to use ExtensionMethods
    public static class Helpers
    {
        /// <summary>
        /// Returns true if the string is  not a number
        /// </summary>
        public static bool IsNaN(this string msg) => !double.TryParse(msg, out double _);
        /// <summary>
        /// Check user input for condition
        /// </summary>
        public static string[] InputCheck(string conditionMsg, int numberOfItems)
        {
            string[] userInput = Regex.Split(Console.ReadLine(), @"\s|[,]\s|[,]");
            while (userInput.Length != numberOfItems)
            {
                Console.WriteLine("Sorry, the values you entered are invalid.\nTry again.\n" +
                    $"Please, enter {conditionMsg}.\nUse space key or comma to split values.");
                userInput = Regex.Split(Console.ReadLine(), @"\s|[,]\s|[,]");
            }
            return userInput;
        }
        /// <summary>
        /// Math.Clamp for .NET Framework
        /// </summary>
        public static T Clamp<T>(this T value, T min, T max) where T : IComparable<T> => 
            (value.CompareTo(min) < 0) ? min : (value.CompareTo(max) > 0) ? max : value;
    }
}
