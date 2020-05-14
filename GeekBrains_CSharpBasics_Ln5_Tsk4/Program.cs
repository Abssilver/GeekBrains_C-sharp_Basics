using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ремизов Павел
/*
*Задача ЕГЭ.
На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы.
В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, 
каждая из следующих N строк имеет следующий формат:
<Фамилия> <Имя> <оценки>,
где <Фамилия> — строка, состоящая не более чем из 20 символов,
<Имя> — строка, состоящая не более чем из 15 символов,
<оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе.
<Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом.
Пример входной строки:
Иванов Петр 4 5 3
Требуется написать как можно более эффективную программу,
которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников.
Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших,
следует вывести и их фамилии и имена.
*/

namespace GeekBrains_CSharpBasics_Ln5_Tsk4
{
    struct StudentInfo
    {
        public string SurnameAndName { get; set; }
        public int SumOfMarks { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //ShuffleDataAndGenerateMarks("StudentProgress.txt");
            int numberOfPoorPerformances = 3;
            LoadDataFromFile("StudentProgress.txt", out StudentInfo[] examResults);
            Console.WriteLine("A list of students showing the weakest results:");
            ShowPoorPerformance(examResults, numberOfPoorPerformances);
            Console.ReadLine();
        }
        static void ShuffleDataAndGenerateMarks(string filename)
        {
            List<string> studentsNames = new List<string>();
            using (StreamReader strReader = new StreamReader("StudentProgress.txt"))
            {
                int students = int.Parse(strReader.ReadLine());
                for (int i = 0; i < students; i++)
                    studentsNames.Add(strReader.ReadLine());
            }
            using (StreamWriter strWriter = new StreamWriter("StudentProgress.txt"))
            {
                strWriter.WriteLine(studentsNames.Count);
                Random random = new Random();
                foreach (var student in studentsNames)
                    strWriter.WriteLine
                        ($"{student} {random.Next(3,6)} {random.Next(3, 6)} {random.Next(3, 6)}");
            }
        }
        static void LoadDataFromFile(string filename, out StudentInfo[] examResults)
        {
            try
            {
                using (StreamReader strReader = new StreamReader("StudentProgress.txt"))
                {
                    int students = int.Parse(strReader.ReadLine());
                    examResults = new StudentInfo[students];
                    for (int i = 0; i < students; i++)
                    {
                        string[] student = strReader.ReadLine().Split(' ');
                        examResults[i].SurnameAndName = string.Join(" ", student[0], student[1]);
                        examResults[i].SumOfMarks =
                            SumOfDigits(int.Parse($"{student[2]}{student[3]}{student[4]}"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Reading file error!");
                Console.WriteLine(ex.Message);
                examResults = null;
            }
        }
        static void ShowPoorPerformance(StudentInfo[] examResults, int numberOfPoorPerformances)
        {
            if (examResults != null)
            {
                Dictionary<int, List<string>> performance = new Dictionary<int, List<string>>();
                foreach (var studentResult in examResults)
                {
                    if (performance.ContainsKey(studentResult.SumOfMarks))
                        performance[studentResult.SumOfMarks].Add(studentResult.SurnameAndName);
                    else
                        performance.Add
                            (studentResult.SumOfMarks, new List<string> { studentResult.SurnameAndName });
                }
                for (int i = 0; i <= 15; i++)
                {
                    if (performance.ContainsKey(i))
                    {
                        foreach (var student in performance[i])
                            Console.WriteLine($"{student,36} - average {i / 3.0:f1}"); //magic numbers!!!
                        numberOfPoorPerformances -= performance[i].Count;
                        if (numberOfPoorPerformances < 1)
                            break;
                    }
                }
            }
        }
        static int SumOfDigits(int number) => 
            number < 10 ? number : number % 10 + SumOfDigits(number / 10);
    }
}
