using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ремизов Павел
/*
Переделать программу Пример использования коллекций для решения следующих задач:
а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (*частотный массив);
в) отсортировать список по возрасту студента;
г) *отсортировать список по курсу и возрасту студента;
д) разработать единый метод подсчета количества студентов по различным параметрам
выбора с помощью делегата и методов предикатов.
*/
namespace GeekBrains_CSharpBasics_Ln6_Tsk3
{
    public class AgeComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            string[] first = (string[])x;
            string[] second = (string[])y;
            return first[5].CompareTo(second[5]);
        }
    }
    public class NameComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            string[] first = (string[])x;
            string[] second = (string[])y;
            int result = string.Concat(first[1], first[0]).CompareTo
                (string.Concat(second[1], second[0]));
            return result;
        }
    }
    public class CourseAndAgeComparer: IComparer
    {
        public int Compare(object x, object y)
        {
            string[] first = (string[])x;
            string[] second = (string[])y;
            int result = first[6].CompareTo(second[6]);
            if (result == 0)
                result = first[5].CompareTo(second[5]);
            return result;
        }
    }

    class Program
    {
        static bool IsYoungerThanTwenty(string[] studentInfo)
        {
            int.TryParse(studentInfo[5], out int age);
            return age > 0 && age < 20;
        }
        static bool IsStudentOfYale(string[] studentInfo) => studentInfo[2].ToLower().Equals("yale");
        public static int FindTheNumberOfStudentsByCondition(ArrayList list, Func<string[], bool> comparer) =>
            list.Cast<string[]>().Where(x => comparer(x)).Count();
        #region Classic
        /*{
            int number = 0;
            try
            {
                foreach (string[] element in list)
                    if (comparer(element))
                        number++;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! {ex.Message}");
            }
            return number;
        }*/
        #endregion 
        /* base
        Сколько всего студентов?
        Сколько всего бакалавров?
        Сколько всего магистров?
        Вывести всех студентов (по ФИО) в алфавитном порядке.
        */
        static ArrayList fileData = new ArrayList();
        static Dictionary<int, int> youngStudents = new Dictionary<int, int>();
        static int bachelor = 0, fifthYearStudent = 0, sixthYearStudent = 0;
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (StreamReader reader = new StreamReader(@"..\..\students_1.csv"))
            {
                while (!reader.EndOfStream)
                {
                    try
                    {
                        string[] studentInfo = reader.ReadLine().Split(';');
                        fileData.Add(studentInfo);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error!\n{ex.Message}");
                    }
                }
            }
            ArrayAnalysis(fileData);
            DisplayResults(fileData);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            Console.WriteLine
                ("There (is)are {0} student(s) who younder than 20 years.",
                FindTheNumberOfStudentsByCondition(fileData, IsYoungerThanTwenty));
            Console.WriteLine
                ("There (is)are {0} student(s) who studies in Yale.",
                FindTheNumberOfStudentsByCondition(fileData, new Func<string[], bool>(IsStudentOfYale)));
            Console.ReadKey();
        }
        static void ArrayAnalysis(ArrayList data)
        {
            foreach (string[] student in data)
            {
                int.TryParse(student[6], out int studyCourse);
                DetermineStudentDegree(studyCourse);
                int.TryParse(student[5], out int studentAge);
                if (studentAge>=18 && studentAge<=20)
                {
                    if (youngStudents.ContainsKey(studyCourse))
                        youngStudents[studyCourse]++;
                    else
                        youngStudents.Add(studyCourse, 1);
                }
            }
        }
        static void DisplayResults(ArrayList dataList)
        {
            Console.WriteLine("Total number of students :{0}", dataList.Count);
            Console.WriteLine($"Fifth Year students: {fifthYearStudent}");
            Console.WriteLine($"Sixth Year students: {sixthYearStudent}");
            Console.WriteLine($"Masters : {fifthYearStudent + sixthYearStudent}");
            Console.WriteLine("Bachelors :{0}", bachelor);
            foreach (var young in youngStudents)
                Console.WriteLine
                    ($"There is(are) {young.Value} student(s) between the ages of 18 and 25 " +
                    $"study at the {young.Key} course");
            SortByName(dataList);
            SortByAge(dataList);
            SortByCourseAndAge(dataList);
        }
        static void SortByCourseAndAge(ArrayList dataList)
        {
            IComparer courseAndAgeComparer = new CourseAndAgeComparer();
            dataList.Sort(courseAndAgeComparer);
            Console.WriteLine
                (string.Concat(new string('*', 35), " Sorting By Course And Age ", new string('*', 35)));
            DisplayArrayElements(dataList);
            Console.WriteLine
                (string.Concat(new string('*', 40), " End Of Sorting ", new string('*', 40)));
        }
        static void SortByName(ArrayList dataList)
        {
            IComparer nameComparer = new NameComparer();
            dataList.Sort(nameComparer);
            Console.WriteLine
               (string.Concat(new string('*', 5), " Sorting By Name ", new string('*', 5)));
            foreach (string[] studentName in dataList)
                Console.WriteLine(string.Join(" ", studentName[1], studentName[0]));
            Console.WriteLine
                (string.Concat(new string('*', 5), " End Of Sorting ", new string('*', 5)));
        }
        static void SortByAge(ArrayList dataList)
        {
            IComparer ageComparer = new AgeComparer();
            dataList.Sort(ageComparer);
            Console.WriteLine
                (string.Concat(new string('*', 40), " Sorting By Age ", new string('*', 40)));
            DisplayArrayElements(dataList);
            Console.WriteLine
                (string.Concat(new string('*', 40), " End Of Sorting ", new string('*', 40)));
        }
        static void DisplayArrayElements(ArrayList dataList)
        {
            foreach (string[] student in dataList)
            {
                Console.WriteLine
                    ("{0,12} {1,12} {2,10} {3,25} {4,2} {5,3} {6,2} {7,5} {8,12}",
                    student[0], student[1], student[2], student[3], student[4],
                    student[5], student[6], student[7], student[8]);
            }
        }
        static void DetermineStudentDegree(int course)
        {
            switch (course)
            {
                case 5:
                    fifthYearStudent++;
                    break;
                case 6:
                    sixthYearStudent++;
                    break;
                default:
                    bachelor++;
                    break;
            }
        }
    }
}

