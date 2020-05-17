using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ремизов Павел
/*
Изменить программу вывода таблицы функции так, чтобы можно было передавать 
функции типа double (double, double). Продемонстрировать работу 
с функцией a * x^2 и функцией a * sin(x).
*/
namespace GeekBrains_CSharpBasics_Ln6_Tsk1
{
    public delegate double Fun (double x);

    class Program
    {
        public static void Table(Fun F, double x, double b)
        {
            string line = new string('-', 6);
            Console.WriteLine("{0} X {0} Y {0}", line);
            while (x <= b)
                Console.WriteLine("| {0,8:f3} | {1,8:f3} |", x++, F?.Invoke(x));
            Console.WriteLine(string.Concat(line,line,line,line));
        }
        public static void Table
            (Func<double, double, double> F, (double startX, double endX) interval, double coefficient)
        {
            string line = new string('-', 6);
            Console.WriteLine("{0} X {0} Y {0}", line, coefficient);
            while (interval.startX <= interval.endX)
                Console.WriteLine
                    ("| {0,8:f1} | {1,8:f3} |", interval.startX++, F?.Invoke(interval.startX, coefficient));
            Console.WriteLine(string.Concat(line, line, line, line));
        }
        public static double MyFunc(double x) => Math.Pow(x, 3);

        static void Main()
        {
            //OldVersion();
            NewVersion();
            Console.ReadKey();
        }
        static void NewVersion()
        {
            int coefFirst = 3, coefSecond = 5;
            Console.WriteLine($"A table of : f(x) = {coefFirst} * x^2");
            Table((double x, double coef) => coef * Math.Pow(x, 2), (-2, 2), coefFirst);
            Console.WriteLine($"A table of : f(x) = {coefSecond} * sin(x)");
            Table(Sin, (-2, 2), coefSecond);
        }
        static double Sin(double x, double coefficient) => coefficient * Math.Sin(x);
        static void OldVersion()
        {
            Console.WriteLine("Таблица функции MyFunc:");
            Table(new Fun(MyFunc), -2, 2);
            Console.WriteLine("Еще раз та же таблица, но вызов организован по новому");
            Table(MyFunc, -2, 2);
            Console.WriteLine("Таблица функции Sin:");
            Table(Math.Sin, -2, 2);      // Можно передавать уже созданные методы
            Console.WriteLine("Таблица функции x^2:");
            Table(delegate (double x) { return x * x; }, 0, 3);
        }
    }
}
