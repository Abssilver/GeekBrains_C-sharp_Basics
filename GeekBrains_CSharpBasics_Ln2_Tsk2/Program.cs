using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ремизов Павел
/*
Написать метод подсчета количества цифр числа.
*/

namespace GeekBrains_CSharpBasics_Ln2_Tsk2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "The number of digits";
            ulong number = 12345678910123456789;
            Console.WriteLine($"A length of the number {number} is {NumberLength(number, 0)}");
            Console.WriteLine($"A length of the number {number} is {NumberLength(number, 1)}");
            Console.ReadLine();
        }
        private static int NumberLength(ulong number, int option)
        {
            switch (option)
            {
                case 0:
                    return number.ToString().Length;
                default:
                    return RecursionCalculation(number);
            }
        }
        private static int RecursionCalculation(ulong number) => 
            number < 10 ? 1: RecursionCalculation(number / 10) + 1;
    }
}
