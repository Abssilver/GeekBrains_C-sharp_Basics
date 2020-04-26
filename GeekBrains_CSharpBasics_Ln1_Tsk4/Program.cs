using System;
using System.Text.RegularExpressions;

//Ремизов Павел
/*
 * Написать программу обмена значениями двух переменных:
 * а) с использованием третьей переменной;
 * б) * без использования третьей переменной. 
*/

namespace GeekBrains_CSharpBasics_Ln1_Tsk4
{
    class Program
    {
        static void SwapValue<T>(ref T a, ref T b)
        {
            T temporal = a;
            a = b;
            b = temporal;
        }
        static void SwapWithNoIntermediary(ref int a, ref int b)
        {
            a = a ^ b;
            b = b ^ a;
            a = a ^ b;
        }
        public class Test
        {
            public int a;
            public Test(int a)
            {
                this.a = a;
            }
        }
        static void SwappingSystem()
        {
            Console.Title = "Swapping System";
            Console.WriteLine
                ("The Swap program welcomes you!\n" +
                "To swap any numerical values, please enter them below\n" +
                "Use space key or comma to split values.");
            string[] userInput = Regex.Split(Console.ReadLine(), @"\s|[,]\s|[,]");
            while (userInput.Length != 2)
            {
                Console.WriteLine("Sorry, the number of values you entered is exceeded.\nTry again.\n" +
                    "Please, enter two numerical values.\nUse space key or comma to split values.");
                userInput = Regex.Split(Console.ReadLine(), @"\s|[,]\s|[,]");
            }
            int first, second;
            bool firstIsNum = int.TryParse(userInput[0], out first);
            bool secondIsNum = int.TryParse(userInput[1], out second);
            if (firstIsNum && secondIsNum)
            {
                Console.WriteLine($"Your values are {first} and {second}");
                ChooseAnAlgorithm(ref first, ref second);
            }
            else
                Console.WriteLine("You entered invalid values");
            Console.WriteLine($"Now your values are {first} and {second}");
        }
        private static void ChooseAnAlgorithm(ref int first, ref int second)
        {
            Console.WriteLine("Please, choose an algorithm:\na - for regular swap with buffer,\n" +
                "b - for swap with no intermediary");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "a":
                    SwapValue(ref first, ref second);
                    break;
                default:
                    SwapWithNoIntermediary(ref first, ref second);
                    break;
            }
        }
        static void Main(string[] args)
        {
            //swap tests
            /*
            double a = 6.2, b = 8.1;
            int c = -1, d = 0;
            bool e = true, f = false;
            Test one = new Test(1);
            Test two = new Test(2);

            Console.WriteLine($"{one.a} * {two.a}");
            SwapValue(ref one, ref two);
            Console.WriteLine($"{one.a} * {two.a}");

            Console.WriteLine($"a={a} * b={b}");
            SwapValue(ref a, ref b);
            Console.WriteLine($"a={a} was swapped with b={b}");

            Console.WriteLine($"c={c} * d={d}");
            SwapValue(ref c, ref d);
            Console.WriteLine($"c={c} was swapped with d={d}");
            SwapWithNoIntermediary(ref c, ref d);
            Console.WriteLine($"c={c} was swapped with d={d}, again, without buffer");

            Console.WriteLine($"e={e} * f={f}");
            SwapValue(ref e, ref f);
            Console.WriteLine($"e={e} was swapped with f={f}");
            */
            SwappingSystem();
            Console.ReadKey();
        }
    }
}