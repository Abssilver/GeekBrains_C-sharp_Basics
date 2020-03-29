using System;

namespace GeekBrains_ln1
{
    class Program
    {
        //Ремизов Павел
        /*
         *Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause).
        */
        /// <summary>
        /// Displays a message (msg) in the console window.
        /// xAnchor and yAnchor are anchor values relative to the console corner in percentage
        /// </summary>
        static void PrintName(string msg, int xAnchor, int yAnchor)
        {
            int xPosition = Math.Clamp(xAnchor * Console.WindowWidth / 100, msg.Length / 2, Console.WindowWidth);
            int yPosition = Math.Clamp(yAnchor * Console.WindowHeight / 100, 1, Console.WindowHeight);
            Console.SetCursorPosition (xPosition - msg.Length / 2, yPosition - 1);
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
            Profile authorData = new Profile("Pavel", "Remizov", "Moscow");
            PrintName($"{authorData.name} {authorData.surname} {authorData.hometown}", 50, 50);
            Console.ReadLine();
        }

    }
}
           
    /*


а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
б) * Сделать задание, только вывод организовать в центре экрана.
в) ** Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y).
*Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause).
Достаточно решить 3 задачи.Записывайте в начало программы условие и свою фамилию. Все программы создавайте в одном решении. Со звездочками задания выполняйте в том случае, если вы решили задачи без звездочек.

   */

