using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ремизов Павел
/*
Дан целочисленный  массив из 20 элементов.
Элементы массива  могут принимать  целые значения  от –10 000 до 10 000 включительно.
Заполнить случайными числами.
Написать программу, позволяющую найти и вывести количество пар элементов массива, 
в которых только одно число делится на 3. 
В данной задаче под парой подразумевается два подряд идущих элемента массива.
Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.
*** Website version
Написать программу, позволяющую найти и вывести количество пар элементов массива, 
в которых хотя бы одно число делится на 3. 
В данной задаче под парой подразумевается два подряд идущих элемента массива. 
Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.
*/
namespace GeekBrains_CSharpBasics_Ln4_Tsk1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "The only one is divided by 3";
            int[] arrayToSearchIn = CreateArray(20, -10_000, 10_000);
            int result = FindTheNumberOfPairs(arrayToSearchIn, false);
            Console.WriteLine($"The program found {result} pairs of desired feature");
            result = FindTheNumberOfPairs(arrayToSearchIn, true);
            Console.WriteLine($"The program found {result} pairs of desired feature (website version)");
            Console.WriteLine("There is an array you have:");
            PrintElements(arrayToSearchIn);
            Console.ReadLine();
        }
        public static void PrintElements(int [] array)
        {
            foreach (var item in array)
                Console.WriteLine("{0,8} - {1}", item, IsDividedByThree(item));
        }
        static int FindTheNumberOfPairs(int [] array, bool isWebsite)
        {
            int result=0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (!isWebsite)
                {
                    if (DesiredFeature(array[i], array[i + 1]))
                        result++;
                }
                else
                {
                    if (DesiredFeatureWebsiteVersion(array[i], array[i + 1]))
                        result++;
                }
            }
            return result;
        }
        public static int [] CreateArray(int length, int minValue, int maxValue)
        {
            int[] arrayToReturn = new int[length];
            Random random = new Random();
            for (int i = 0; i < length; i++)
                arrayToReturn[i] = random.Next(minValue, maxValue + 1);
            return arrayToReturn;
        }
        static bool DesiredFeature(int firstNumber, int secondNumber) =>
            IsDividedByThree(firstNumber) ^ IsDividedByThree(secondNumber);
        static bool DesiredFeatureWebsiteVersion(int firstNumber, int secondNumber) =>
            IsDividedByThree(firstNumber) || IsDividedByThree(secondNumber);
        static bool IsDividedByThree(int number) => number % 3 == 0;
    }
}
