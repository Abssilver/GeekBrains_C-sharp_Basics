using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Ремизов Павел
/*
Реализуйте задачу 1 в виде статического класса StaticClass;
а) Класс должен содержать статический метод, 
который принимает на вход массив и решает задачу 1;
б) * Добавьте статический метод для считывания массива из текстового файла.
Метод должен возвращать массив целых чисел;
в)** Добавьте обработку ситуации отсутствия файла на диске.
*/
namespace GeekBrains_CSharpBasics_Ln4_Tsk2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "The only one is divided by 3. Extended";
            int[] arrayToSearchIn = 
                GeekBrains_CSharpBasics_Ln4_Tsk1.Program.CreateArray(20, -10_000, 10_000);
                //CreateArray(20, -10_000, 10_000);
            int result = TheOnlyOneIsDividedByThree.FindTheNumberOfPairs(arrayToSearchIn);
            Console.WriteLine($"The program found {result} pairs of desired feature");
            Console.WriteLine("There is an array you have:");
            GeekBrains_CSharpBasics_Ln4_Tsk1.Program.PrintElements(arrayToSearchIn);
            Console.WriteLine("The data that was loaded from a file: ");
            int[] arrayFromFile = TheOnlyOneIsDividedByThree.ConvertFileDataIntoArray("data.TXT");
            GeekBrains_CSharpBasics_Ln4_Tsk1.Program.PrintElements(arrayFromFile);
            Console.WriteLine("Trying to load data from nonexistent file: ");
            int[] invalidArray = TheOnlyOneIsDividedByThree.ConvertFileDataIntoArray("invalidFilePath.txt");
            Console.ReadLine();
        }
    }
    static class TheOnlyOneIsDividedByThree
    {
        public static int[] ConvertFileDataIntoArray(string filename)
        {
            if (File.Exists(filename))
            {
                string[] fileData = File.ReadAllLines(filename);
                int[] arrayToReturn = new int[fileData.Length];
                for (int i = 0; i < fileData.Length; i++)
                    arrayToReturn[i] = int.TryParse(fileData[i], out int number) ? number : default;
                return arrayToReturn;
            }
            Console.WriteLine("File does not exists!");
            return null;
        }
        public static int FindTheNumberOfPairs(int[] array)
        {
            int result = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (DesiredFeature(array[i], array[i + 1]))
                    result++;
            }
            return result;
        }
        static bool DesiredFeature(int firstNumber, int secondNumber) =>
            IsDividedByThree(firstNumber) ^ IsDividedByThree(secondNumber);
        static bool IsDividedByThree(int number) => number % 3 == 0;
    }
}