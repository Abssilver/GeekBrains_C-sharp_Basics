using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Ремизов Павел
/*
Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
а) Вывести только те слова сообщения,  которые содержат не более n букв.
б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
в) Найти самое длинное слово сообщения.
г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
д) ***Создать метод, который производит частотный анализ текста. 
В качестве параметра в него передается массив слов и текст, 
в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст. 
Здесь требуется использовать класс Dictionary.
*/
namespace GeekBrains_CSharpBasics_Ln5_Tsk2
{
    static class Message
    {
        public static void PrintWordsThatAreShorterThan(string input, int wordLength)
        {
            string pattern = $"\\b\\w{{1,{wordLength}}}\\b";
            foreach (Match match in Regex.Matches(input, pattern))
                Console.Write($"{match.Value} ");
        }
        public static void DeleteAllWordsEndingWith(ref string input, char symbol)
        {
            string pattern = 
                $"\\s\\w*{symbol}\\b|\\s\\w*{char.ToUpper(symbol)}\\b|\\w*{char.ToUpper(symbol)}\\b\\s";
            input = Regex.Replace(input, pattern, string.Empty);
        }
        public static string FindTheLongestWordOfTheMessage
            (string input, out StringBuilder longestWordsStringBuilder) 
        {
            try
            {
                string pattern = @"\b\w+\b";
                var matches = Regex.Matches(input, pattern);
                string[] wordArray = new string[matches.Count];
                int index = 0;
                foreach (Match match in matches)
                    wordArray[index++] = match.Value;
                //char[] charSeparators = new char[] { ',', '.', ';', '!', '?', ':', '-', ' ' };
                //string [] wordArray = input.Split(charSeparators);
                var theLongestWordCollection =
                    wordArray.Where(x => x.Length == (wordArray.Max(word => word.Length)));
                StringBuilder strBuilder = new StringBuilder();
                foreach (var longestWord in theLongestWordCollection)
                    strBuilder.Append($"{longestWord} ");
                longestWordsStringBuilder = strBuilder;
                return theLongestWordCollection.First();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!");
                Console.WriteLine(ex.Message);
            }
            longestWordsStringBuilder = null;
            return null;
            /*
            string toReturn = wordArray[0];
            foreach (var word in wordArray)
                if (toReturn.Length < word.Length)
                    toReturn = word;
            return toReturn;
            */
        }
        public static StringBuilder LoadText(string filename)
        {
            if (File.Exists(filename))
            {
                StringBuilder strBuilder = new StringBuilder();
                using (StreamReader strReader = new StreamReader(filename))
                {
                    string line;
                    while ((line = strReader.ReadLine()) != null)
                        strBuilder.Append(line + Environment.NewLine);
                }
                return strBuilder;
            }
            else
                return null;
        }
        public static Dictionary<string,int> TextFrequencyAnalysis(string [] wordsArray, string text)
        {
            Dictionary<string, int> frequencyAnalysis = new Dictionary<string, int>();
            foreach (var word in wordsArray)
            {
                string wordTemplate = 
                    $"\\b{word}\\b|" +
                    $"\\b{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word)}\\b";
                var matches = Regex.Matches(text, wordTemplate);
                frequencyAnalysis.Add(word, matches.Count);
            }
            return frequencyAnalysis;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Demonstration();
            Console.ReadLine();
        }
        static void Demonstration()
        {
            string text = Message.LoadText("textExample.txt")?.ToString();
            Console.WriteLine("Text you are working with:\n");
            Console.WriteLine(text);
            int wordLength = 2;
            Console.WriteLine($"These words contain {wordLength} letters or less:");
            Message.PrintWordsThatAreShorterThan(text, wordLength);
            char endLetter = 's';
            Console.WriteLine($"\n\nDelete all words which end up with letter \'{endLetter}\'\n");
            Message.DeleteAllWordsEndingWith(ref text, 's');
            Console.WriteLine(text);
            Console.WriteLine("Finding of the longest word of the text: ");
            string result = 
                Message.FindTheLongestWordOfTheMessage(text, out StringBuilder longestWords);
            Console.WriteLine(result);
            Console.WriteLine("\nA string formed by StringBuilder: ");
            Console.WriteLine(longestWords);
            Console.WriteLine("\nText Frequency Analysis\n");
            string[] searchingWords = { "old", "frog", "one", "little", "water", "ox" };
            string fable = Message.LoadText("fable.txt")?.ToString();
            Console.WriteLine(fable);
            Dictionary<string, int> frequencyAnalysis =
                Message.TextFrequencyAnalysis(searchingWords, fable);
            foreach (var pair in frequencyAnalysis)
                Console.WriteLine($"{pair.Key,15} meets {pair.Value,-2} times.");
        }
    }
}
