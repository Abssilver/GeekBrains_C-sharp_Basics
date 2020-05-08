using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Ремизов Павел
/*
Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив.
Создайте структуру Account, содержащую Login и Password.
*/

namespace GeekBrains_CSharpBasics_Ln4_Tsk4
{
    struct Account
    {
        public string Login { get; }
        public string Password { get; }
        public Account(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SystemAuthorization();
            Console.ReadLine();
        }
        internal static void SystemAuthorization()
        {
            //string filename = "login_password.txt";
            Console.Title = "System Authorization With Helps Of External File";
            int tryCounter = 3;
            char[] charsToTrim = { '\"', ' ', '\'' };
            Console.WriteLine("Welcome to the TGIF inc.");
            Account userAccount;
            do
            {
                if (tryCounter < 3)
                {
                    Console.WriteLine($"Your username or password is invalid.\nTry again.\n" +
                         "Your username should be written in the first line of file " +
                         $"and password - in the second.\n{tryCounter} attempts to block.");
                }
                Console.WriteLine("To log in, please provide your username and password\n" +
                "You must enter the full name of the file from which we read your data.");
                userAccount = ReadTextAndTryToCreateAccount(Console.ReadLine().Trim(charsToTrim));
            } while (!AuthorizationCheck(userAccount.Login, userAccount.Password) && --tryCounter >= 1);
            string outputMsg = tryCounter < 1 ?
                "Access is denied.\nSecurity service was called." :
                "Access granted.\nWelcome back to the system.";
            Console.WriteLine(outputMsg);
        }
        static Account ReadTextAndTryToCreateAccount(string filename)
        {
            List<string> filedata = new List<string>();
            if (File.Exists(filename))
            {
                Console.WriteLine("Loading data...");
                foreach (var line in File.ReadLines(filename))
                    filedata.Add(line);
                if (filedata.Count.Equals(2))
                    return new Account(filedata[0], filedata[1]);
                Console.WriteLine("The amount of data does not meet the requirements.");
            }
            Console.WriteLine ("The attempt to load data failed.");
            return new Account(default, default);
        }
        private static bool AuthorizationCheck(string login, string pswrd) => login!=null && pswrd!=null ?
            login.Equals("root", StringComparison.OrdinalIgnoreCase) && pswrd.Equals("GeekBrains") : false;
    }
}