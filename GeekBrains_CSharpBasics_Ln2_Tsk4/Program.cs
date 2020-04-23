using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

//Ремизов Павел
/*
Реализовать метод проверки логина и пароля. 
На вход метода подается логин и пароль. 
На выходе истина, если прошел авторизацию, и ложь, если не прошел 
(Логин: root, Password: GeekBrains). 
Используя метод проверки логина и пароля, написать программу: 
пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. 
С помощью цикла do while ограничить ввод пароля тремя попытками.
*/

namespace GeekBrains_CSharpBasics_Ln2_Tsk4
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.Title = "System Authorization";
            LoggingIn();
            Console.ReadLine();
        }
        private static void LoggingIn()
        {
            string[] userInput;
            int tryCounter = 3;
            Console.WriteLine("Welcome to the TGIF inc.");
            do
            {
                if (tryCounter < 3)
                {
                    Console.Clear();
                    Console.WriteLine($"Your username or password is invalid.\nTry again.\n" +
                        $"Be careful with register.\n{tryCounter} attempts to block.");
                }
                Console.WriteLine("To log in, please enter your username and password\n" +
                "Use space key or comma to split values.");
                userInput = Regex.Split(Console.ReadLine(), @"\s|[,]\s|[,]");
            } while ((userInput.Length != 2 || !AuthorizationCheck(userInput[0], userInput[1])) 
                                            && --tryCounter >= 1);
            string outputMsg = tryCounter < 1 ?
                "Access is denied.\nSecurity service was called." :
                "Access granted.\nWelcome back to the system.";
            Console.WriteLine(outputMsg);
        }
        private static bool AuthorizationCheck(string login, string pswrd) =>
            login.Equals("root") && pswrd.Equals("GeekBrains");
    }
}
