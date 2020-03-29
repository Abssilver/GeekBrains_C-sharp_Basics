using System;

namespace ExtensionMethods
{
    class Program
    {
        //Ремизов Павел
        /*
         *Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause).
        */
        static void Main(string[] args)
        {
            string test = "five";
            Console.WriteLine(test.isNaN());
        }
    }
    public static class Helpers
    {
        public static bool isNaN(this string msg)
        {
            double value;
            return double.TryParse(msg, out value);
        }
    }
}
