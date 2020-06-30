using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

//Ремизов Павел
/*
С помощью рефлексии выведите все свойства структуры DateTime
*/

namespace GeekBrains_CSharpBasics_Ln8_Tsk1
{
    class Program
    {
        static PropertyInfo GetPropertyInfo(object obj, string str)
        {
            return obj.GetType().GetProperty(str);
        }

        static void Main(string[] args)
        {
            DateTime dateTime = new DateTime();
            Console.WriteLine(GetPropertyInfo(dateTime, "DayOfWeek").CanRead);
            Console.WriteLine(GetPropertyInfo(dateTime, "DayOfWeek").CanWrite);
            Console.WriteLine(GetPropertyInfo(dateTime, "DayOfWeek").GetValue(dateTime, null));
            //
            Console.WriteLine("***** Homework Start *****");
            DateTime homework = DateTime.Now;
            PropertyInfo[] properties = homework.GetType().GetProperties();
            foreach (var property in properties)
                Console.WriteLine($"{property} - {property.GetValue(homework)}");
            Console.ReadKey();
        }

    }
}
