using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Ремизов Павел
/*
** В файле могут встречаться номера телефонов, записанные в формате xx-xx-xx, xxx-xxx или
xxx-xx-xx.Вывести все номера телефонов, которые содержатся в файле.
*/

namespace GeekBrains_CSharpBasics_Ln6_Tsk4_New
{
    class Program
    {
        static List<string> phoneNumbers = new List<string>();
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("phoneNumberHistory.txt"))
            {
                string text = reader.ReadToEnd();
                FindPhoneNumbers(text);
            }
            Console.ReadKey();
        }
        static void FindPhoneNumbers(string text)
        {
            Regex pattern = new Regex(@"\b(?:\d{2}-){2}\d{2}\b|\b\d{3}-\d{3}\b|\b\d{3}(?:-\d{2}){2}\b");
            Match phoneNumber = pattern.Match(text);
            using (StreamWriter writer = new StreamWriter("phoneNumbers.txt", false))
            {
                while (phoneNumber.Success)
                {
                    writer.WriteLine(phoneNumber);
                    phoneNumbers.Add(phoneNumber.ToString());
                    phoneNumber = phoneNumber.NextMatch();
                }
            }
            DisplayPhoneNumbers();
        }
        static void DisplayPhoneNumbers()
        {
            foreach (var number in phoneNumbers)
                Console.WriteLine(number);
        }
    }
}
