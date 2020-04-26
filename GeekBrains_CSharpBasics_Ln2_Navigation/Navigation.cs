using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ремизов Павел
/*
Навигация по домашнему заданию к уроку 2.
*/
namespace GeekBrains_CSharpBasics_Ln2_Navigation
{
    class Navigation
    {
        static void Main(string[] args)
        {
            Console.Title = "Navigator";
            Console.WriteLine("A lesson 2 task navigator welcomes you!\n"+
                "Please, choose a task you would like to check (number or name): ");
            Console.WriteLine("Task 1 - Minimum Of Three\n" +
                              "Task 2 - The Number Of Digits\n"+
                              "Task 3 - Odd Numbers Sum\n" +
                              "Task 4 - System Authorization\n" +
                              "Task 5 - BMI Calculations\n" +
                              "Task 6 - Good Numbers\n" +
                              "Task 7 - Incredible Recursion\n" +
                              "Press 0 to exit");
            object userInput = Console.ReadLine();
            var choice = int.TryParse(userInput.ToString(), out int tsk) ? tsk : userInput;
            switch (choice)
            {
                case int number when number == 1:
                case string taskString when taskString.Equals("Task 1", StringComparison.OrdinalIgnoreCase):
                case string taskName when taskName.Equals("Minimum Of Three", StringComparison.OrdinalIgnoreCase):
                    Ln2Tasks.MinimumOfTheThree();
                    break;
                case int number when number == 2:
                case string taskString when taskString.Equals("Task 2", StringComparison.OrdinalIgnoreCase):
                case string taskName when taskName.Equals("The Number Of Digits", StringComparison.OrdinalIgnoreCase):
                    Ln2Tasks.TheNumberOfDigits();
                    break;
                case int number when number == 3:
                case string taskString when taskString.Equals("Task 3", StringComparison.OrdinalIgnoreCase):
                case string taskName when taskName.Equals("Odd Numbers Sum", StringComparison.OrdinalIgnoreCase):
                    Ln2Tasks.OddNumbersSum();
                    break;
                case int number when number == 4:
                case string taskString when taskString.Equals("Task 4", StringComparison.OrdinalIgnoreCase):
                case string taskName when taskName.Equals("System Authorization", StringComparison.OrdinalIgnoreCase):
                    Ln2Tasks.SystemAuthorization();
                    break;
                case int number when number == 5:
                case string taskString when taskString.Equals("Task 5", StringComparison.OrdinalIgnoreCase):
                case string taskName when taskName.Equals("BMI Calculations", StringComparison.OrdinalIgnoreCase):
                    Ln2Tasks.BMICalculations();
                    break;
                case int number when number == 6:
                case string taskString when taskString.Equals("Task 6", StringComparison.OrdinalIgnoreCase):
                case string taskName when taskName.Equals("Good Numbers", StringComparison.OrdinalIgnoreCase):
                    Ln2Tasks.GoodNumbers();
                    break;
                case int number when number == 7:
                case string taskString when taskString.Equals("Task 7", StringComparison.OrdinalIgnoreCase):
                case string taskName when taskName.Equals("Incredible Recursion", StringComparison.OrdinalIgnoreCase):
                    Ln2Tasks.IncredibleRecursion();
                    break;
                default:
                    Console.WriteLine("Well...Goodbye!");
                    break;
            }
            Console.ReadKey();
        }
    }
}