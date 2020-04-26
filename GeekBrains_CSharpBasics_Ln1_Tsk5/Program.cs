using System;
using ExtensionMethods;

//Ремизов Павел
/*
 * а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
 * б) *Сделать задание, только вывод организовать в центре экрана.
 * в) **Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y).
*/

namespace GeekBrains_CSharpBasics_Ln1_Tsk5
{
    class Program
    {
        /// <summary>
        /// Displays a message (msg) in the console window.
        /// xAnchor and yAnchor are anchor values relative to the console corner in percentage
        /// </summary>
        static void PrintName(string msg, int xAnchor, int yAnchor)
        {
            int xPosition = (xAnchor * Console.WindowWidth / 100)
                                .Clamp(msg.Length / 2, Console.WindowWidth - msg.Length / 2); //Custom .dll from tsk6
            int yPosition = (yAnchor * Console.WindowHeight / 100)
                                .Clamp(1, Console.WindowHeight); //Custom .dll from tsk6
            Console.SetCursorPosition(xPosition - msg.Length / 2, yPosition - 1);
            Console.WriteLine(msg);
        }
        struct Profile
        {
            public string name, surname, hometown;
            public Profile(string name, string surname, string hometown)
            {
                this.name = name;
                this.surname = surname;
                this.hometown = hometown;
            }
        }
        static void Main(string[] args)
        {
            Console.Title = "Text Alignment";
            Profile authorData = new Profile("Pavel", "Remizov", "Moscow");
            PrintName($"{authorData.name} {authorData.surname} {authorData.hometown}", 50, 50);
            Console.ReadLine();
        }

    }
}

