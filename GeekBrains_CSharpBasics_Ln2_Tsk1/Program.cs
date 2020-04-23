using System;

//Ремизов Павел
/*
Написать метод, возвращающий минимальное из трёх чисел.
*/

namespace GeekBrains_CSharpBasics_Ln2_Tsk1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Minimum of the three";
            DisplayResult(6, 10, 15);
            DisplayResult(10.2, 0.9, 15);
            DisplayResult(90f, 65.5f, 6f);
            DisplayResult(true, false, true);
            
            Console.ReadLine();
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
