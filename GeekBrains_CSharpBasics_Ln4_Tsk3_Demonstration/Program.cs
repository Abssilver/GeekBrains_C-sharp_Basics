using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using GeekBrains_CSharpBasics_Ln4_Tsk3;

//Ремизов Павел
/*
Демонстрация работы библиотеки из задания 3
*/

namespace GeekBrains_CSharpBasics_Ln4_Tsk3_Demonstration
{
    class Program
    {
        static void Main(string[] args)
        {

            OneDimensionalArray arrayWithTheSameElement = new OneDimensionalArray(10, 5);
            OneDimensionalArray randomNumberArray = new OneDimensionalArray(10, -3, 3);
            OneDimensionalArray arrayWithSpecificElements = new OneDimensionalArray(10, (0, 2));
            Demonstration(arrayWithTheSameElement);
            Demonstration(randomNumberArray);
            Demonstration(arrayWithSpecificElements);
            ReadWriteDemonstration();
            Console.ReadKey();
            
        }
        static void Demonstration(OneDimensionalArray arrayToDemonstrate)
        {
            Console.WriteLine("******* Working with Array **********");
            arrayToDemonstrate.ShowFrequencyCollection();
            Console.WriteLine($"An array you are working with is:\n{arrayToDemonstrate}");
            Console.WriteLine($"Inversed array:\n{PrintArray(arrayToDemonstrate.Inverse())}");
            int number = -3;
            Console.WriteLine($"Array elemets are multiplied by a number {number}: ");
            Console.WriteLine(PrintArray(arrayToDemonstrate.MultiplyByNumber(number)));
            Console.WriteLine($"The number of max elements is : {arrayToDemonstrate.MaxCount}");
            Console.WriteLine($"The max element of the array : {arrayToDemonstrate.MaxElement}");
            Console.WriteLine($"The min element of the array : {arrayToDemonstrate.MinElement}");
            Console.WriteLine
                ($"The number of positive digits in the array is : {arrayToDemonstrate.CountPositiveNumbers}");
            Console.WriteLine($"A sum of all array elements is : {arrayToDemonstrate.SumOfElements}");
            Console.WriteLine($"A sum of all even elements is : {arrayToDemonstrate.SumOfEven}");
            Console.WriteLine($"An array you are working with is (nothing changed):\n{arrayToDemonstrate}");
            Console.WriteLine("******* End Demonstration **********\n");
        }
        static void ReadWriteDemonstration()
        {
            Console.WriteLine("******* Working with Array WebsiteExtra **********");
            int number = 0;
            string filename = "demoFinal.txt";
            OneDimensionalArray arrayFromFile = new OneDimensionalArray("OneDimensionalExample.txt");
            Console.WriteLine($"An array you are working with is:\n{arrayFromFile}");
            Console.WriteLine($"Let's change the first element of the array to : {number}");
            arrayFromFile[0] = number;
            Console.WriteLine($"Now your array is:\n{arrayFromFile}");
            Console.WriteLine($"Your array will be saved at : {filename}");
            arrayFromFile.WriteToFile(filename);
            Console.WriteLine("******* End Demonstration **********\n");
        }
        static string PrintArray(int [] array) => string.Join(" ", array);
    }
}
 