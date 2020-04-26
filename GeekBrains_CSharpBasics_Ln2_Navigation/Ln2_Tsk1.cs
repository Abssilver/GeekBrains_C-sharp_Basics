using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ремизов Павел
/*
Написать метод, возвращающий минимальное из трёх чисел.
*/

namespace GeekBrains_CSharpBasics_Ln2_Navigation
{
    partial class Ln2Tasks
    {
        internal static void MinimumOfTheThree()
        {
            Console.Title = "Minimum of the three";
            DisplayResult(6, 10, 15);
            DisplayResult(10.2, 0.9, 15);
            DisplayResult(90f, 65.5f, 6f);
            DisplayResult(true, false, true);
        }
        private static void DisplayResult<T>(T a, T b, T c) where T : IComparable<T>
        {
            Console.WriteLine($"Min value of {a}, {b}, {c} is {GetMinValueOf(a, b, c)}");
        }
        private static T GetMinValueOf<T>(T first, T second, T third) where T : IComparable<T> =>
            first.CompareTo(second) < 0 ? first.CompareTo(third) < 0 ? first : third :
            second.CompareTo(third) < 0 ? second : third;
    }
}