using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ремизов Павел
/*
а)  С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). 
Требуется подсчитать сумму всех нечётных положительных чисел. 
Сами числа и сумму вывести на экран, используя tryParse.
*/

namespace GeekBrains_CSharpBasics_Ln3
{
    class Ln3_Tsk2
    {
        internal static void OddNumbersSumExtended()
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
                isDigit = int.TryParse(userInput, out number);
                if (isDigit && number > 0 && number % 2 == 1)
                    oddNumbersList.Add(number);
            } while (isDigit && number != 0);
            Console.WriteLine($"You entered the next positive odd numbers: ");
            foreach (int addedNumber in oddNumbersList)
                Console.Write($"{addedNumber} ");
            Console.WriteLine($"\nThe sum of all odd positive numbers you entered is {oddNumbersList.Sum()}");
        }
    }
}

namespace GeekBrains_CSharpBasics_Ln2_Navigation
{
    partial class Ln2Tasks
    {
        
    }
}
