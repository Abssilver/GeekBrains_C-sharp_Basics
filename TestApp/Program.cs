using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {

        static int value;
        static string console_message = "Введите число:";

        static void Main(string[] args)
        {
            //RandomFill();
            //Tabulation();
            GuessANumber();
            Console.ReadKey();
        }
        static void GuessANumber()
        {
            int min = 1;
            int max = 100;
            int maxCount = (int)Math.Log(max - min + 1, 2) + 1;
            int count = 0;
            Random rnd = new Random();
            int guessNumber = rnd.Next(min, max);
            Console.WriteLine("Компьютер загадал число от {0} до {1}. Попробуйте угадать его за {2} попыток", min, max, maxCount);
            int n;
            do
            {
                count++;
                Console.Write("{0} попытка. Введите число:", count);
                n = int.Parse(Console.ReadLine());
                if (n > guessNumber) Console.WriteLine("Перелет!");
                if (n < guessNumber) Console.WriteLine("Недолет!");
            }
            while (count < maxCount && n != guessNumber);
            if (n == guessNumber) Console.WriteLine("Поздравляю! Вы угадали число за {0} попыток", count);
            else Console.WriteLine("Неудача. Попробуйте еще раз");
        }

        static void Tabulation()
        {
            double a = -5;
            double b = 5;
            double h = 0.5;
            Console.WriteLine("{0,10}{1,10}", "x", "F(x)");
            for (double x = a; x <= b; x = x + h)
            {
                Console.WriteLine("{0,10}{1,10:f3}", x, F(x));
            }
        }
        static double F(double x)
        {
            return 1 / x;
        }
        static void RandomFill()
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++) Console.Write("[{0,5}]", rnd.Next(0, 10));
            Console.WriteLine();
            Console.WriteLine("[{0, -25}]", "Microsoft"); // Left aligned 
            Console.WriteLine("[{0,  25}]", "Microsoft"); // Right aligned
            Console.WriteLine("[{0,   5}]", "Microsoft"); // Ignored, Microsoft is longer than 5 chars
        }
        static void Move(int number, int from, int to, int free)
        {
            if (number > 0)
            {
                Move(number - 1, from, free, to);
                Console.WriteLine("{0} => {1}", from, to);
                Move(number - 1, free, to, from);
            }
        }
        static void HanoiTower()
        {
            Move(4, 1, 2, 3);
            Console.ReadKey();
        }
        static void SecurityInput()
        {

            value = GetValue(console_message);
            Console.WriteLine("Return ...");
            value = ReturnValue();
            ShowValue("value после ReturnValue(): ");

            value = GetValue(console_message);
            Console.WriteLine("Out parameter ...");
            OutParameter(out value);
            ShowValue("value после OutParameter(): ");
        }
        static int GetValue(string message)
        {
            int x;
            string s;
            bool flag;       // Логическая переменная, выступающая в роли "флага". 
                             // Истинно (флаг поднят), ложно (флаг опущен)
            do
            {
                Console.WriteLine(message);
                s = Console.ReadLine();
                //  Если перевод произошел неправильно, то результатом будет false
                flag = int.TryParse(s, out x);
            }
            while (!flag);  //  Пока false(!false=true), повторять цикл
            return x;
        }
        static void ShowValue(string description)
        {
            Console.WriteLine(description + value);
        }
        static int ReturnValue()
        {
            ShowValue("ReturnValue (до): ");
            int tmp = 10;
            ShowValue("ReturnValue (после): ");
            return tmp;
        }
        static void OutParameter(out int tmp)
        {
            ShowValue("OutParameter (до): ");
            tmp = 10;
            ShowValue("OutParameter (после): ");
        }
    }
}
