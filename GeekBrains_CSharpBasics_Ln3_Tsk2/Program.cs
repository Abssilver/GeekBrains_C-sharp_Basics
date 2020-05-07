using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ремизов Павел
/*
а) С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). 
Требуется подсчитать сумму всех нечётных положительных чисел. 
Сами числа и сумму вывести на экран. Используйте tryParse.
б) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные.
При возникновении ошибки вывести сообщение. Напишите соответствующую функцию;
*/

namespace GeekBrains_CSharpBasics_Ln3_Tsk2
{
    class Program
    {
        static void Main(string[] args)
        {
            OddNumbersSumExtended();
            Console.ReadLine();
        }
        static void OddNumbersSumExtended()
        {
            Console.Title = "Odd numbers sum";
            List<int> oddNumbersList = new List<int>();
            string userInput = string.Empty;
            bool isDigit = false;
            int number = 0;
            do
            {
                Console.Write("Enter a digit: ");
                userInput = Console.ReadLine();
                isDigit = InputCheck(userInput, out number);
                if (isDigit && IsOddAndPositive(number))
                    oddNumbersList.Add(number);
            } while (isDigit && number != 0);
            Console.WriteLine($"You entered the next positive odd numbers: ");
            foreach (int addedNumber in oddNumbersList)
                Console.Write($"{addedNumber} ");
            Console.WriteLine($"\nThe sum of all odd positive numbers you entered is {oddNumbersList.Sum()}");
        }
        static bool IsOddAndPositive(int number) => number > 0 && number % 2 == 1;
        static bool InputCheck(string userInput, out int number)
        {
            bool isDigit = int.TryParse(userInput, out number);
            if (!isDigit)
                throw new ArgumentException(string.Format("You entered an invalid value"));
            return isDigit;
        }
    }
}