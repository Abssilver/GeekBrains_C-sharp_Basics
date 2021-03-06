﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ремизов Павел
/*
С клавиатуры вводятся числа, пока не будет введен 0. 
Подсчитать сумму всех нечетных положительных чисел.
*/

namespace GeekBrains_CSharpBasics_Ln2_Navigation
{
    partial class Ln2Tasks
    {
        internal static void OddNumbersSum()
        {
            Console.Title = "Odd numbers sum";
            string userInput = string.Empty;
            bool isDigit = false;
            int number = 0, sum = 0;
            do
            {
                Console.Write("Enter a digit: ");
                userInput = Console.ReadLine();
                isDigit = int.TryParse(userInput, out number);
                if (isDigit && number > 0 && number % 2 == 1)
                    sum += number;
            } while (isDigit && number != 0);
            Console.WriteLine($"The sum of all odd positive numbers you entered is {sum}");
        }
    }
}