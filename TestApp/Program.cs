using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.Reflection;
using System.Xml.Serialization;

namespace TestApp
{
    #region ObserverPattern
    delegate void Action();
    class A
    {
        public A()
        {
            B.FlagIsTrue = new Action(DoSomething);
        }
        private void DoSomething()
        {
            Console.WriteLine("Oppa!");
        }
    }
    class B
    {
        static public Action FlagIsTrue;
        bool flag;
        void SetFlag(bool _flag)
        {
            flag = _flag;
            if (flag) FlagIsTrue();
        }
    }
    #endregion
    #region Serialization
    [Serializable]
    public class Student
    {
        // Чтобы поля можно было сериализовать, они должны быть открытыми 
        public string firstName;
        public string lastName;
        // Если поле не открыто, оно не будет сериализоваться
        int age;
        // Если мы хотим не нарушать принцип инкапсуляции и при этом сериализовать поле, то должны реализовать доступ к нему через публичное свойство        
        public int Age
        {
            get { return age; }
            set { if (value > 0) age = value; }
        }
        // Если есть отличный от конструктора по умолчанию конструктор, то пустой конструктор автоматически не создается
        public Student(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }
        //...в этом случае для сериализации требуется самим создать пустой конструктор
        public Student()
        {
        }
    }
    #endregion
    class Program
    {
        static int val = 0;
        static int Quiz()
        {
            val = val + 42;
            return 1;
        }
        static int value;
        static string console_message = "Введите число:";

        static void Main(string[] args)
        {
            //RandomFill();
            //Tabulation();
            //GuessANumber();
            //Reader();
            //ReadFromFileWithException();
            //Lesson8_2();
            //Pattern();
            //RegexExample();
            //val += Quiz();
            //List<int> a = default;
            //Console.WriteLine(a==null );
            Console.ReadKey();
            //int[][] a = new int[10][];

        }
        #region Lesson8
        
        static void SaveAsXmlFormat(List<Student> obj, string fileName)
        {
            // Сериализовать список объектов не представляется большой проблемой
            // Дело в том, что все объекты в C# наследуются от класса Object,
            // который представляет собой дерево объектов
            // подробней читайте у Эндрю Троелсена “Язык программирования C# 5.0”
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Student>));
            // Создаем файловый поток (проще говоря, создаем файл)
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            // В этот поток записываем сериализованные данные (записываем xml-файл)
            xmlFormat.Serialize(fStream, obj);
            fStream.Close();
        } 
        static void LoadFromXmlFormat(ref List<Student> obj, string fileName)
        {
            // Считать класс List<Student> из файла fileName формата XML
            // Обратите внимание, что этот пример показывает нам, что List<Student> не более, чем класс, его структура более сложная и для ее понимания потребуется некоторый опыт
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Student>));
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            obj = (List<Student>)xmlFormat.Deserialize(fStream);
            fStream.Close();
        }
        static void Lesson8_2()
        {
            List<Student> list = new List<Student>();
            list.Add(new Student("Иван", "Иванов", 20));
            list.Add(new Student("Петр", "Петров", 21));
            SaveAsXmlFormat(list, "data.xml");
            LoadFromXmlFormat(ref list, "data.xml");
            foreach (var v in list)
            {
                Console.WriteLine("{0} {1} {2}", v.firstName, v.lastName, v.Age);
            }
            Console.ReadKey();
        }
        static void Lesson8_1()
        {
            DateTime dateTime = new DateTime();
            //dateTime.DayOfWeek
            Console.WriteLine(GetPropertyInfo(dateTime, "DayOfWeek").CanRead);
            Console.WriteLine(GetPropertyInfo(dateTime, "DayOfWeek").CanWrite);
            Console.WriteLine(GetPropertyInfo(dateTime, "DayOfWeek").GetValue(dateTime, null));
        }
        static PropertyInfo GetPropertyInfo(object obj, string str)
        {
            return obj.GetType().GetProperty(str);
        }
        #endregion

        static void InsertionSort(ref int[] a)
        {
            for (int j = 0; j < a.Length; j++)
            {
                int key = a[j];
                int i = j - 1;
                while (i >= 0 && a[i] > key)
                {
                    a[i + 1] = a[i];
                    i--;
                }
                a[i + 1] = key;
            }
        }
        static void RegexExample()
        {
            string input = "capybara,squirrel,chipmunk,porcupine,gopher," +
                       "beaver,groundhog,hamster,guinea pig,gerbil," +
                       "chinchilla,prairie dog,mouse,rat";
            string pattern = @"\G(\w+\s?\w*),?";
            Match match = Regex.Match(input, pattern);
            while (match.Success)
            {
                Console.WriteLine(match.Value);
                match = match.NextMatch();
            }
        }
        /* using System.Timers;
        public static void Lesson7_1()
        {
            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(TimerEventHandler);
            timer.Interval = 1000;
            timer.Enabled = true;
            Console.ReadKey();
        }
        private static void TimerEventHandler(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine(sender.ToString());
            Console.WriteLine(e.SignalTime.ToString());
        }
        */
        static void Lesson7_3()
        {
            Application.Run(new MyForm());
        }
        class MyForm : Form
        {
            public MyForm()
            {
                Text = "My Inherited Form";
                Width *= 2;
                Click += MyClicker;
                Paint += MyPainter;
            }
            void MyClicker(object objSrc, EventArgs args)
            {
                MessageBox.Show("The button has been clicked!", "Click");
            }
            void MyPainter(object objSrc, PaintEventArgs args)
            {
                Graphics grfx = args.Graphics;
                grfx.DrawString("Hello, Windows Forms", Font,
                SystemBrushes.ControlText, 0, 0);
            }
        }

        #region Lesson 6
        delegate void MessageHandler(string message);
        static void Lesson6_3()
        {
            MessageHandler handler = delegate
            {
                Console.WriteLine("анонимный метод");
            };
            handler("hello world!");    // анонимный метод
            Console.Read();
        }
        static void Lesson6_2()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\");
            printDirect(dir);
            DirectoryInfo[] subDirects = dir.GetDirectories();
            Console.WriteLine("Найдено {0} подкаталогов", subDirects.Length);
            foreach (DirectoryInfo d in subDirects)
            {
                printDirect(d);
            }
        }
        static void printDirect(DirectoryInfo dir)
        {
            //DirectoryInfo dir = new DirectoryInfo(".");//(@"C:\Temp")
            Console.WriteLine("***** " + dir.Name + " *****");
            Console.WriteLine("FullName: {0}", dir.FullName);
            Console.WriteLine("Name: {0}", dir.Name);
            Console.WriteLine("Parent: {0}", dir.Parent);
            Console.WriteLine("Creation: {0}", dir.CreationTime);
            Console.WriteLine("Attributes: {0}", dir.Attributes.ToString());
            Console.WriteLine("Root: {0}", dir.Root);
        }
        public static void Table(Fun F, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
        public delegate double Fun(double x);
        public static double MyFunc(double x)
        {
            return x * x * x;
        }
        static void Lesson6_1()
        {
            // Создаем новый делегат и передаем ссылку на него в метод Table
            Console.WriteLine("Таблица функции MyFunc:");
            // Параметры метода и тип возвращаемого значения, должны совпадать с делегатом
            Table(new Fun(MyFunc), -2, 2);
            Console.WriteLine("Еще раз та же таблица, но вызов организован по новому");
            // Упрощение(c C# 2.0).Делегат создается автоматически.            
            Table(MyFunc, -2, 2);
            Console.WriteLine("Таблица функции Sin:");
            Table(Math.Sin, -2, 2);      // Можно передавать уже созданные методы
            Console.WriteLine("Таблица функции x^2:");
            // Упрощение(с C# 2.0). Использование анонимного метода
            Table(delegate (double x){ return x * x; }, 0, 3);
        }
        #endregion
        #region Lesson 5
        static void Lesson5_5()
        {
            Console.WriteLine("Введите строку: ");
            StringBuilder a = new StringBuilder(Console.ReadLine());
            Console.WriteLine("Исходная строка: " + a);
            for (int i = 0; i < a.Length;)
                if (char.IsPunctuation(a[i])) a.Remove(i, 1);
                else ++i;
            string str = a.ToString();
            string[] s = str.Split(' ');
            Console.WriteLine("Искомые слова: ");
            for (int i = 0; i < s.Length; ++i)
                if (s[i][0] == s[i][s[i].Length - 1]) Console.WriteLine(s[i]);
        }
        static void Lesson5_4()
        {
            Regex myReg = new Regex(@"[A-Za-z]+[\.A-Za-z0-9_-]*[A-Za-z0-9]+@[A-Za-z0-9]+\.[A-Za-z]{2,6}");
            Console.WriteLine(myReg.IsMatch("email@email.com"));// True
            Console.WriteLine(myReg.IsMatch("email@email"));        // False
            Console.WriteLine(myReg.IsMatch("@email.com"));// False
        }
        static void Lesson5_3()
        {
            const int iIterations = 10000;
            DateTime dt = DateTime.Now;
            string str = String.Empty;
            for (int i = 0; i < iIterations; i++)
                str += "abcdefghijklmnopqrstuvwxyz\r\n";
            Console.WriteLine(DateTime.Now - dt);

            dt = DateTime.Now;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < iIterations; i++)
                sb.Append("abcdefghijklmnopqrstuvwxyz\r\n");
            str = sb.ToString();
            Console.WriteLine(DateTime.Now - dt);
        }
        static void Lesson5_2()
        {
            StringBuilder a = new StringBuilder("2*3=3*2");
            Console.WriteLine(a);
            int k = 0;
            for (int i = 0; i < a.Length; ++i)
                if (char.IsDigit(a[i]))
                    k += int.Parse(a[i].ToString());
            Console.WriteLine(k);
        }
        static void Lesson5_1()
        {

            try
            {
                StringBuilder str = new StringBuilder("Площадь");
                PrintString(str);
                str.Append(" треугольника равна");
                PrintString(str);
                str.AppendFormat(" {0:f2} см ", 123.456);
                PrintString(str);
                str.Insert(8, "данного ");
                PrintString(str);
                str.Remove(7, 21);
                PrintString(str);
                str.Replace("а", "о");
                PrintString(str);
                Console.WriteLine("Введите первую строку для сравнения:");
                StringBuilder str1 = new StringBuilder(Console.ReadLine());
                Console.WriteLine("Введите вторую строку для сравнения:");
                StringBuilder str2 = new StringBuilder(Console.ReadLine());
                Console.WriteLine("Строки равны: " + str1.Equals(str2));
            }
            catch
            {
                Console.WriteLine("Возникло исключение");
            }
        }
        static void PrintString(StringBuilder a)
        {
            Console.WriteLine("Строка: " + a);
            Console.WriteLine("Текущая длина строки " + a.Length);
            Console.WriteLine("Объем буфера " + a.Capacity);
            Console.WriteLine("Максимальный объем буфера " + a.MaxCapacity);
            Console.WriteLine();
        }
        static void Lesson5()
        {
            string s1 = "Hello!";
            string s2 = "HELLo!";
            // сравнение с использованием статического метода
            Console.WriteLine(String.Compare(s1, s2));
            // сравнение с использованием нестатического метода
            Console.WriteLine(s1.CompareTo(s2));
            string str1 = "Первая строка";
            string str2 = string.Copy(str1);
            string str3 = "Вторая строка";
            string str4 = "ВТОРАЯ строка";
            string strUp, strLow;
            int result, idx;
            Console.WriteLine("str1: " + str1);
            Console.WriteLine("Длина строки str1: " + str1.Length);
            // создаем прописную и строчную версии строки str1.
            strLow = str1.ToLower();
            strUp = str1.ToUpper();
            Console.WriteLine("Строчная версия строки str1: " + strLow);
            Console.WriteLine("Прописная версия строки str1: " + strUp);
            Console.WriteLine();
            // сравниваем строки
            result = str1.CompareTo(str3);
            if (result == 0) Console.WriteLine("str1 и str3 равны.");
            else if (result < 0) Console.WriteLine("str1 меньше, чем str3");
            else Console.WriteLine("str1 больше, чем str3");
            Console.WriteLine();
            // сравниваем строки без учета регистра
            result = String.Compare(str3, str4, true);
            if (result == 0) Console.WriteLine("str3 и str4 равны без учета регистра.");
            else Console.WriteLine("str3 и str4 не равны без учета регистра.");
            Console.WriteLine();
            // сравниваем части строк
            result = String.Compare(str1, 4, str2, 4, 2);
            if (result == 0) Console.WriteLine("часть str1 и str2 равны");
            else Console.WriteLine("часть str1 и str2 не равны");
            Console.WriteLine();
            // поиск строк
            idx = str2.IndexOf("строка");
            Console.WriteLine("Индекс первого вхождения подстроки строки: " + idx);
            idx = str2.LastIndexOf("о");
            Console.WriteLine("Индекс последнего вхождения символа о: " + idx);
            // конкатенация
            string str = String.Concat(str1, str2, str3, str4);
            Console.WriteLine(str);
            // удаление подстроки
            str = str.Remove(0, str1.Length);
            Console.WriteLine(str);
            // замена подстроки "строка" на пустую подстроку
            str = str.Replace("строка", "");
            Console.WriteLine(str);
        }
        #endregion
        #region Lesson 4
        static void Reader()
        {
            // Создаем объект sr и связываем его с файлом data.txt.
            StreamReader sr = new StreamReader("..\\..\\data.txt");
            // Считаем количество чисел.
            int n = int.Parse(sr.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int a = int.Parse(sr.ReadLine());
                Console.WriteLine(a);
            }
            // Освобождаем файл data.txt для использования другими программами.
            sr.Close();
        }
        
        static void ReadFromFileWithException()
        {
            StreamReader sr = new StreamReader("..\\..\\data.txt");
            int sum = 0, count = 0;
            while (!sr.EndOfStream)  // Пока не конец потока (файла)
            {
                string s = sr.ReadLine();
                Console.WriteLine("Считали строку:" + s);
                try
                {
                    int a = int.Parse(s);
                    sum = sum + a;
                    count++;
                    Console.WriteLine("{0}.Преобразовали в число:{1}", count, a);
                }
                // В экземпляре exc класса Exception будет
                // храниться информация об ошибке.
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            sr.Close();
            Console.WriteLine("Среднее арифметическое:{0:f2}", (double)sum / count);
            // Обратите внимание! Если не поставить явное преобразование типов перед sum, sum/count получит целое число. Попробуйте убрать (double) перед sum.
        }

        class MyArray
        {
            int[] a;  // он приватный
            public MyArray(int n)
            {
                a = new int[n];
            }
            // либо мы делаем метод для получения элемента массива
            public int Get(int i)
            {
                return a[i];
            }
            // и метод для того, чтобы задать элемент
            public void Set(int i, int value)
            {
                a[i] = value;
            }
            // либо создаем индексируемое свойство
            public int this[int i]
            {
                get { return a[i]; }
                set { a[i] = value; }
            }
        }
        #endregion
        #region Lesson 3
        static void GuessANumber()
        {
            int min = 1;
            int max = 100;
            int maxCount = (int)Math.Log(max - min + 1, 2) + 1;
            int count = 0;
            Random rnd = new Random();
            int guessNumber = rnd.Next(min, max);
            Console.WriteLine("Компьютер загадал число от {0} до {1}. Попробуйте угадать его за {2} попыток", min, max, maxCount);
            int n;
            do
            {
                count++;
                Console.Write("{0} попытка. Введите число:", count);
                n = int.Parse(Console.ReadLine());
                if (n > guessNumber) Console.WriteLine("Перелет!");
                if (n < guessNumber) Console.WriteLine("Недолет!");
            }
            while (count < maxCount && n != guessNumber);
            if (n == guessNumber) Console.WriteLine("Поздравляю! Вы угадали число за {0} попыток", count);
            else Console.WriteLine("Неудача. Попробуйте еще раз");
        }

        static void Tabulation()
        {
            double a = -5;
            double b = 5;
            double h = 0.5;
            Console.WriteLine("{0,10}{1,10}", "x", "F(x)");
            for (double x = a; x <= b; x = x + h)
            {
                Console.WriteLine("{0,10}{1,10:f3}", x, F(x));
            }
        }
        static double F(double x)
        {
            return 1 / x;
        }
        static void RandomFill()
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++) Console.Write("[{0,5}]", rnd.Next(0, 10));
            Console.WriteLine();
            Console.WriteLine("[{0, -25}]", "Microsoft"); // Left aligned 
            Console.WriteLine("[{0,  25}]", "Microsoft"); // Right aligned
            Console.WriteLine("[{0,   5}]", "Microsoft"); // Ignored, Microsoft is longer than 5 chars
        }
        #endregion
        #region Lesson 2
        static void Move(int number, int from, int to, int free)
        {
            if (number > 0)
            {
                Move(number - 1, from, free, to);
                Console.WriteLine("{0} => {1}", from, to);
                Move(number - 1, free, to, from);
            }
        }
        static void HanoiTower()
        {
            Move(4, 1, 2, 3);
            Console.ReadKey();
        }
        static void SecurityInput()
        {

            value = GetValue(console_message);
            Console.WriteLine("Return ...");
            value = ReturnValue();
            ShowValue("value после ReturnValue(): ");

            value = GetValue(console_message);
            Console.WriteLine("Out parameter ...");
            OutParameter(out value);
            ShowValue("value после OutParameter(): ");
        }
        static int GetValue(string message)
        {
            int x;
            string s;
            bool flag;       // Логическая переменная, выступающая в роли "флага". 
                             // Истинно (флаг поднят), ложно (флаг опущен)
            do
            {
                Console.WriteLine(message);
                s = Console.ReadLine();
                //  Если перевод произошел неправильно, то результатом будет false
                flag = int.TryParse(s, out x);
            }
            while (!flag);  //  Пока false(!false=true), повторять цикл
            return x;
        }
        static void ShowValue(string description)
        {
            Console.WriteLine(description + value);
        }
        static int ReturnValue()
        {
            ShowValue("ReturnValue (до): ");
            int tmp = 10;
            ShowValue("ReturnValue (после): ");
            return tmp;
        }
        static void OutParameter(out int tmp)
        {
            ShowValue("OutParameter (до): ");
            tmp = 10;
            ShowValue("OutParameter (после): ");
        }
        #endregion
    }
}
