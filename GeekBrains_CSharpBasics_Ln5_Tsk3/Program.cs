using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ремизов Павел
/*
*Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
Регистр можно не учитывать. Например:
badc являются перестановкой abcd.
а) с использованием методов C#;
б) *разработав собственный алгоритм.
*/
namespace GeekBrains_CSharpBasics_Ln5_Tsk3
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = "Uncharacteristically";
            string second = "aitlraccytasurcinehl";
            string third = "hatrilltaypceiaccsrn";
            Console.WriteLine("Using C# Methods...");
            Console.WriteLine($"Does the \'{second}\' is rebuild version of the string \'{first}\'?");
            Console.WriteLine($"The answer is : {isRebuildingOfString(first, second)}");
            Console.WriteLine($"And what about \'{third}\'?");
            Console.WriteLine($"The answer is : {isRebuildingOfString(first, third)}");
            Console.WriteLine("Using an Algorithm...");
            Console.WriteLine($"Does the \'{second}\' is rebuild version of the string \'{first}\'?");
            Console.WriteLine($"The answer is : {isRebuildingOfStringAlgorithm(first, second)}");
            Console.WriteLine($"And what about \'{third}\'?");
            Console.WriteLine($"The answer is : {isRebuildingOfStringAlgorithm(first, third)}");
            Console.ReadLine();
        }
        static bool isRebuildingOfString(string first, string second) =>
            new string(first.ToLower().OrderBy(x => x).ToArray()).Equals
                (new string(second.ToLower().OrderBy(x => x).ToArray()));
        static bool isRebuildingOfStringAlgorithm(string first, string second)
        {
            if (first.Length != second.Length)
                return false;
            List<char> charsOfFirstString = first.ToLower().ToList();
            foreach (char letter in second)
            {
                char lowerLetter = char.ToLower(letter);
                if (charsOfFirstString.Contains(lowerLetter))
                    charsOfFirstString.Remove(lowerLetter);
                else
                    return false;
            }
            return true;
        }
    }
}
