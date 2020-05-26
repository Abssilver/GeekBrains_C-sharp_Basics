using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Ремизов Павел
/*
***В заданной папке найти во всех html файлах теги <img src=...> и вывести названия картинок.
*/
namespace GeekBrains_CSharpBasics_Ln6_Tsk6
{
    class Program
    {
        static List<string> imageNameList = new List<string>();
        static void Main(string[] args)
        {
            FindHTMLFiles();
            DisplayResults();
            Console.ReadKey();
        }
        static void FindHTMLFiles()
        {
            string filePath = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(filePath);
            FileInfo[] files = directory.GetFiles();
            Regex htmlSearcher = new Regex(@".+.html$");
            foreach (var fileInFolder in files)
            {
                Match htmlFile = htmlSearcher.Match(fileInFolder.Name);
                while (htmlFile.Success)
                {
                    using (StreamReader reader = new StreamReader(fileInFolder.Name))
                    {
                        string text = reader.ReadToEnd();
                        FindImageNames(text);
                    }
                    htmlFile = htmlFile.NextMatch();
                }
            }
        }
        static void DisplayResults()
        {
            foreach (var pictureName in imageNameList)
                Console.WriteLine(pictureName);
        }
        static void FindImageNames(string text)
        {
            Regex pattern = new Regex
                (@"<img src=""(([.\w\s!@^\-\(\)\[\]])+\/|([.\w\s!@^\-\(\)\[\]])+)+"">");
            Match imageName = pattern.Match(text);
            char[] separator = { '.', '/', '"' };
            while (imageName.Success)
            {
                string [] nameParts = imageName.ToString().Split(separator);
                if (nameParts.Length > 3)
                    imageNameList.Add(nameParts[nameParts.Length - 3]);
                imageName = imageName.NextMatch();
            }
        }
    }
}
