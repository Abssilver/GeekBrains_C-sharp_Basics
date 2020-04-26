using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;

//Ремизов Павел
/*
a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
*/

namespace GeekBrains_CSharpBasics_Ln2_Navigation
{
    partial class Ln2Tasks
    {
        internal static void IncredibleRecursion()
        {
            Console.Title = "Incredible recursion";
            Console.WriteLine("Please, enter two integers\n" +
            "Use space key or comma to split values.");
            string[] userInput = Helpers.InputCheck("two integers", 2);
            if (!userInput[0].IsNaN() && !userInput[1].IsNaN())
            {
                int first = int.Parse(userInput[0]);
                int second = int.Parse(userInput[1]);
                int minValue = Math.Min(first, second);
                int maxValue = Math.Max(first, second);
                Console.WriteLine($"Here is a segment of numbers between {minValue} and {maxValue}");
                PrintNumbers(minValue, maxValue);
                Console.WriteLine
                    ($"\nA sum of all numbers of a segment is {SumOfTheSegment(minValue, maxValue)}");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Your input is invalid");
                IncredibleRecursion();
            }
        }
        static void PrintNumbers(int start, int end)
        {
            Console.Write($"{start} ");
            if (start++ < end)
                PrintNumbers(start, end);
        }
        static int SumOfTheSegment(int start, int end) =>
            start < end ? start + SumOfTheSegment(++start, end) : end;
    }
}