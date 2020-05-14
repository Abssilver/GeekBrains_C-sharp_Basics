using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;

//Ремизов Павел
/*
Создать программу, которая будет проверять корректность ввода логина. 
Корректным логином будет строка от 2 до 10 символов, 
содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
а) без использования регулярных выражений;
б) **с использованием регулярных выражений.
*/

namespace GeekBrains_CSharpBasics_Ln5_Tsk1
{
    class Program
    {
        delegate bool LoginCheckDelegate(string userInput, out string errorMessage);
        static void Main(string[] args)
        {
            Write("Would you like to use regular expressions? [Y/N] ");
            string userInput = ReadLine();
            bool isRegular = userInput.Equals("Y") || userInput.Equals("y");
            LoginCheck(isRegular);
            ReadKey();
        }
        static void LoginCheck(bool withRegularExpressions)
        {
            WriteLine($"Using regular expressions - {withRegularExpressions}");
            LoginCheckDelegate delegateHandler;
            if (withRegularExpressions)
                delegateHandler = CheckUserInputWithHelpOfRegularExpressions;
            else
                delegateHandler = CheckUserInputWithoutRegularExpressions;
            WriteLine("Welcome to CPH: a Company of Puppy Haircuts");
            WriteLine("Before you can get a consultation of our experts - please, provide us your login.");
            bool conditionsAreMet = default;
            string error = string.Empty;
            do
            {
                conditionsAreMet = delegateHandler(ReadLine(), out error);
                #region Methods solution
                /*
                if (!withRegularExpressions)
                    conditionsAreMet = 
                        CheckUserInputWithoutRegularExpressions(ReadLine(), out error);
                else
                    conditionsAreMet =
                           CheckUserInputWithHelpOfRegularExpressions(ReadLine(), out error);
                */
                #endregion
                if (!conditionsAreMet)
                    WriteLine($"Your login is invalid.\n{error}");
            } while (!conditionsAreMet);
            WriteLine("Hello, my name is Derik and I make the best hairstyles for pets " +
                "on the entire coast of California.\nHow can I help you?");
        }
        private static bool CheckUserInputWithHelpOfRegularExpressions(string userInput, out string error)
        {
            Regex pattern = new Regex(@"^[a-z][a-z\d]{1,9}$", RegexOptions.IgnoreCase);
            error = string.Empty;
            if (pattern.IsMatch(userInput))
                return true;
            error = "Pattern requirements are not met";
            return false;
        }
        static bool CheckUserInputWithoutRegularExpressions(string userInput, out string error)
        {
            error = string.Empty;
            if (!LengthCheck(userInput))
            {
                error = "Login length is not within acceptable limits.";
                return false;
            }
            else if (char.IsDigit(userInput[0]))
            {
                error = "The digit cannot be used at the beginning of the login.";
                return false;
            }
            else
                for (int i = 0; i < userInput.Length; i++)
                {
                    if (!char.IsDigit(userInput[i]) && !isLatinAlphabet(userInput[i]))
                    {
                        error = "Invalid character used in login.";
                        return false;
                    }
                }
            return true;
        }
        static bool isLatinAlphabet(char letter) => 
            char.ToUpper(letter) >= 'A' && char.ToUpper(letter) <= 'Z';
        static bool LengthCheck(string userInput) => userInput.Length >= 2 && userInput.Length <= 10;
    }
}
