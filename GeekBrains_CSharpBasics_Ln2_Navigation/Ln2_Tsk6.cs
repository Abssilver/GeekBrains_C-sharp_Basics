using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

//Ремизов Павел
/*
Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. 
«Хорошим» называется число, которое делится на сумму своих цифр.
Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
*/

namespace GeekBrains_CSharpBasics_Ln2_Navigation
{
    partial class Ln2Tasks
    {
        internal static void GoodNumbers()
        {
            Console.Title = "Good Numbers";
            //Execution started at: 24.04.2020 11:21:08
            //There are 61574510 good numbers in the range from 1 to 1 000 000 000
            //Execution completed at: 24.04.2020 11:26:43
            //Spent time on execution: 00:05:35.3944913

            //Stopwatch watch = new Stopwatch();

            var start = DateTime.Now;
            Console.WriteLine($"Execution started at: {start}");
            //watch.Start();
            FindGoodNumbers();
            //watch.Stop();
            var end = DateTime.Now;
            Console.WriteLine($"Execution completed at: {end}");

            Console.WriteLine($"Spent time on execution: {end - start}");
            //Console.WriteLine($"Program execution time in milliseconds: {watch.ElapsedMilliseconds}");
        }
        static void FindGoodNumbers()
        {
            int goodNumber = 0;
            for (int i = 1; i <= 1_000_000_000; i++)
            {
                if (i % DividerCalculation(i) == 0)
                    goodNumber++;
            }
            Console.WriteLine($"There are {goodNumber} good numbers in the range from 1 to 1 000 000 000");
        }
        /*
        static int DividerCalculationSlow(int number) => 
            number.ToString().ToCharArray().Sum(x=>int.Parse(x.ToString()));
        */
        static int DividerCalculation(int number) =>
            number < 10 ? number : number % 10 + DividerCalculation(number / 10);
    }
}