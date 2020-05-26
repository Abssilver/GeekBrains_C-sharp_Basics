using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ремизов Павел
/*
Модифицировать программу нахождения минимума функции так,
чтобы можно было передавать функцию в виде делегата. 
а) Сделать меню с различными функциями и представить пользователю выбор,
для какой функции и на каком отрезке находить минимум.
Использовать массив (или список) делегатов, в котором хранятся различные функции.
б) *Переделать функцию Load, чтобы она возвращала массив считанных значений.
Пусть она возвращает минимум через параметр (с использованием модификатора out). 
*/
namespace GeekBrains_CSharpBasics_Ln6_Tsk2
{
    class Program
    {
        static List<Func<double, double>> delegateCollection = new List<Func<double, double>>();
        public static double F1(double x) => MethodConstructor(x, 25, 1); //f(x) = x + 25
        public static double F2(double x) => MethodConstructor(x, 1, -3); //f(x) = -3 * x + 1
        public static double F3(double x) => MethodConstructor(x, 0, 0, 2); //f(x) = x^2
        public static double F4(double x) => MethodConstructor(x, 10, -50, 1); //f(x) = x^2 - 50 * x + 10
        public static double F5(double x) => MethodConstructor(x, -4, 0, 10); //f(x) = 10 * x^2 - 4
        public static double F6(double x) => MethodConstructor(x, 0, 0, 0, -5); //f(x) = -5 * x^3
        public static double F7(double x) => MethodConstructor(x, 4, 0, 0, 1); //f(x) = x^3 + 4
        public static double F8(double x) => MethodConstructor(x, 6, 0, 1, 1); //f(x) = x^3 + x^2 + 6

        public static double MethodConstructor(double x, params double[] coef)
        {
            switch (coef.Length)
            {
                case 1:
                    return coef[0];
                case 2:
                    return coef[1] * x + coef[0];
                case 3:
                    return coef[2] * Math.Pow(x, 2) + coef[1] * x + coef[0];
                case 4:
                    return coef[3] * Math.Pow(x, 3) + coef[2] * Math.Pow(x, 2) + coef[1] * x + coef[0];
                default:
                    return 0;
            }
        }
        public static void SaveFunc
            (string fileName, (double min, double max, double step) interval, Func<double, double> funct)
        {
            using (BinaryWriter writer =
                new BinaryWriter(File.Open(fileName, FileMode.Create, FileAccess.Write)))
            {
                while (interval.min <= interval.max)
                {
                    writer.Write(funct(interval.min));
                    interval.min += interval.step;
                }
            }
        }
        public static double [] LoadData (string fileName, out double min)
        {
            if (File.Exists(fileName))
            {
                using (BinaryReader reader =
                    new BinaryReader(File.Open(fileName, FileMode.Open, FileAccess.Read)))
                {
                    try
                    {
                        int dataAmount =
                        checked(Convert.ToInt32(reader.BaseStream.Length / sizeof(double)));
                        double[] dataFromFile = new double [dataAmount];
                        for (int i = 0; i < dataAmount; i++)
                            dataFromFile[i] = reader.ReadDouble();
                        min = dataFromFile.Length > 0 ? dataFromFile.Min() : 0;
                        return dataFromFile;
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine("Data has been lost!");
                        Console.WriteLine(e.Message);
                    }   
                }
            }
            min = 0;
            return null;
        }
        static void ShowMenu()
        {
            string[] functions = {
                "x + 25",
                "-3 * x + 1",
                "x^2",
                "x^2 - 50 * x + 10",
                "10 * x^2 - 4",
                "-5 * x^3",
                "x^3 + 4",
                "x^3 + x^2 + 6"
                };
            Console.WriteLine("This Is Mighty Delegates! Welcome!");
            Console.WriteLine("Use numbers to navigate menu.");
            for (int i = 0; i < functions.Length; i++)
                Console.WriteLine($"{i}: f(x) = {functions[i]}");
            int methodNumber;
            double step;
            if (delegateCollection.Count > 0)
            {
                do
                {
                    Console.WriteLine("Select function to explore.");
                    int.TryParse(Console.ReadLine(), out methodNumber);
                } while (methodNumber < 0 || methodNumber >= delegateCollection.Count);
                Console.WriteLine("Indicate the interval for analysis.");
                Console.Write("X start's from : ");
                double.TryParse(Console.ReadLine(), out double start);
                Console.Write("X end's to : ");
                double.TryParse(Console.ReadLine(), out double end);
                do
                {
                    Console.Write("Value for step : ");
                    double.TryParse(Console.ReadLine(), out step);
                } while (step == 0);
                SaveFunc
                    ("data.bin", 
                    (Math.Min(start, end), Math.Max(start, end), step), delegateCollection[methodNumber]);
                Console.WriteLine
                    ($"f(x) = {functions[methodNumber]} || X:[{start}, {end}] || Step : {step}");
            }
        }
        static void DisplayResults()
        {
            double[] functionValues = LoadData("data.bin", out double min);
            Console.WriteLine($"The function minimum value is : {min}");
            Console.WriteLine("Function values:");
            foreach (var val in functionValues)
                Console.WriteLine(val);
        }
        static void FillCollection()
        {
            delegateCollection.Add(F1);
            delegateCollection.Add(F2);
            delegateCollection.Add(F3);
            delegateCollection.Add(F4);
            delegateCollection.Add(F5);
            delegateCollection.Add(F6);
            delegateCollection.Add(F7);
            delegateCollection.Add(F8);
        }
        static void Main(string[] args)
        {
            FillCollection();
            ShowMenu();
            DisplayResults();
            Console.ReadKey();
        }
    }
}
