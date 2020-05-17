using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeekBrains_CSharpBasics_Ln4_Tsk5;

//Ремизов Павел
/*
Демонстрация работы библиотеки из задания 5
*/

namespace GeekBrains_CSharpBasics_Ln4_Tsk5_Demonstration
{
    class Program
    {
        static void Main(string[] args)
        {
            Demonstration();
            Console.ReadKey();
        }
        static void Demonstration()
        {
            Console.WriteLine("******* Working with TwoDimensional Array **********");
            Console.WriteLine("Creating array with random elements...\n");
            TwoDimensionalArray randomNumberArray = new TwoDimensionalArray((3, 5), -100, 100);
            Console.WriteLine(randomNumberArray);
            Console.WriteLine
                ($"A sum of all array elements, using LINQ is : {randomNumberArray.SumOfArrayElements()}");
            Console.WriteLine
                (string.Concat("A sum of all array elements, using FOR LOOPS is : ",
                    randomNumberArray.SumOfArrayElementsClassic()));
            int number = 25, numberToChange = -101;
            Console.WriteLine
                (string.Concat($"A sum of all array elements, that more than {number} is : ",
                    randomNumberArray.SumOfArrayElementsThatMoreThan(number)));
            Console.WriteLine($"The min element of the array : {randomNumberArray.MinOfArray}");
            Console.WriteLine($"The max element of the array : {randomNumberArray.MaxOfArray}");

            ref int maxElement = 
                ref randomNumberArray.PositionOfMaxElement(out (int row, int column) position);
            Console.WriteLine($"The reference to the maximum element of the array is : {maxElement}");
            Console.WriteLine($"It's position in the array is : [{position.row}, {position.column}]");
            Console.WriteLine($"Let's change it to {numberToChange}");
            maxElement = numberToChange;
            Console.WriteLine($"Now, our array changed to :\n");
            Console.WriteLine(randomNumberArray);
            Console.WriteLine
                ($"Also let's change the element with position [0,0] to {number} using an indexed property. ");
            randomNumberArray[0, 0] = number;
            Console.WriteLine($"Finally, our array will take the following form :\n");
            Console.WriteLine(randomNumberArray);

            Console.WriteLine("Loading data from file \"TwoDimensionalArray.txt\"");
            TwoDimensionalArray arrayFromFile = new TwoDimensionalArray("TwoDimensionalArray.txt");
            Console.WriteLine($"Loaded array:\n\n{arrayFromFile}");
            Console.WriteLine
                ("Now, we are loading new filedata in the same variable with helps of method :\n");
            arrayFromFile.LoadDataFromFile("NewTwoDimensionalArray.txt");
            Console.WriteLine($"\n{arrayFromFile}");
            Console.WriteLine("Let's save it as \"CompletedTests.txt\"");
            arrayFromFile.SaveDataToFile("CompletedTests.txt");
            Console.WriteLine("******* End Demonstration **********\n");
        }
    }
}