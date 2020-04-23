using System;
using System.Text.RegularExpressions;

//Ремизов Павел
/*
 * а) Написать программу, которая подсчитывает расстояние между точками с координатами 
 * x1, y1 и x2,y2 по формуле r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2).
 * Вывести результат, используя спецификатор формата .2f(с двумя знаками после запятой);
 * б) * Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.
*/

namespace GeekBrains_CSharpBasics_Ln1_Tsk3
{
    class Program
    {
        struct Point
        {
            public double xCoord, yCoord;
            public Point(double X, double Y)
            {
                xCoord = X;
                yCoord = Y;
            }
        }
        static void MagnitudeCalculation()
        {
            Console.Title = "MagnitudeCalculation";
            Console.WriteLine
                ("Welcome to the program of magnitude calculation!\n" +
                "To calculate the distance between two points at 2D space pleace enter its coordinates");
            Console.WriteLine
                 ("First, enter values for X and Y of the point A.\nUse space key or comma to separate values.");
            Point startPoint = InputCheck("A");
            Console.WriteLine
                ("Now, it's time to enter values for X and Y of the point B.\nAlso use space key or comma to separate values.");
            Point endPoint = InputCheck("B");
            Console.WriteLine($"A Magnitude of the vector AB with points\n" +
                $"A ({startPoint.xCoord}, {startPoint.yCoord})\n" +
                $"B ({endPoint.xCoord}, {endPoint.yCoord})\n" +
                $"was calculated and its value {VectorMagnitude(startPoint, endPoint):F2}");
        }
        static Point InputCheck(string pointName)
        {
            string[] userInput = Regex.Split(Console.ReadLine(), @"\s|[,]\s|[,]");
            while (userInput.Length != 2)
            {
                Console.WriteLine("Sorry, the number of values you entered is exceeded.\nTry again.\n" +
                    $"Please, enter values for X and Y of the point {pointName}.\nUse space key or comma to separate values.");
                userInput = Regex.Split(Console.ReadLine(), @"\s|[,]\s|[,]");
            }
            double xCoord, Ycoord;
            bool xIsNum = double.TryParse(userInput[0], out xCoord);
            bool yIsNum = double.TryParse(userInput[1], out Ycoord);
            if (xIsNum && yIsNum)
                return new Point(xCoord, Ycoord);
            else
            {
                Console.WriteLine("You entered invalid values.\nContinued using default values...");
                return new Point(0, 0);
            }
        }
        static double VectorMagnitude(Point startPoint, Point endPoint) =>
             Math.Sqrt(Math.Pow(endPoint.xCoord - startPoint.xCoord, 2) + Math.Pow(endPoint.yCoord - startPoint.yCoord, 2));

        static void Main(string[] args)
        {
            MagnitudeCalculation();
            Console.ReadKey();
        }
    }
}


