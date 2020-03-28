using System;
using System.Text.RegularExpressions;

namespace GeekBrains_ln1
{
    class Program
    {
        //Ремизов Павел
        /*
         * Написать программу «Анкета». Последовательно задаются вопросы(имя, фамилия, возраст, рост, вес). 
         * В результате вся информация выводится в одну строчку:
         * а) используя склеивание;
         * б) используя форматированный вывод;
         * в) используя вывод со знаком $.
        */
        struct ProfileData
        {
            public string name, surname;
            public int age;
            public double height, weight;
        }
        static void Profile()
        {
            ProfileData userdata = new ProfileData();
            Console.WriteLine
                ("The Profile program welcomes you!\nPlease, answer to next questions.");
            Console.WriteLine("What is your name?");
            userdata.name = Console.ReadLine();
            Console.WriteLine("Ok, and your surname?");
            userdata.surname = Console.ReadLine();
            userdata.age = (int)NumberCheck("How old are you? (number)");
            userdata.height = NumberCheck("What is your height? (number in cm)");
            userdata.weight = NumberCheck("And what about your weight? (number in kg)");
            Console.WriteLine("Solution to check:\na - for concatination\nb - for composit formatting\nc - for string interpolation");
            string solution = Console.ReadLine();
            Console.WriteLine("Your profile data:");
            switch (solution)
            {
                case "a":
                    Console.WriteLine(ConcatInput(userdata));
                    break;
                case "b":
                    Console.WriteLine(CompositFormatting(userdata));
                    break;
                default:
                    Console.WriteLine(StringInterpolation(userdata));
                    break;
            }
        }
        static double NumberCheck (string msg)
        {
            double number;
            bool inputIsNum = false;
            do
            {
                Console.WriteLine(msg);
                inputIsNum = double.TryParse(Console.ReadLine(), out number);
            } while (!inputIsNum);
            return number;
        }
        static string ConcatInput(ProfileData profile) =>
            profile.name + " " + profile.surname + ", age: " + profile.age +
            ", height: " + profile.height + "cm, weight: " + profile.weight + "kg";
        static string CompositFormatting(ProfileData profile) =>
            string.Format("{0} {1}, age: {2}, height: {3}cm, weight: {4}kg",
                profile.name, profile.surname, profile.age, profile.height, profile.weight);
        static string StringInterpolation(ProfileData profile) =>
            $"{profile.name} {profile.surname}, age: {profile.age}, height: {profile.height}cm, weight: {profile.weight}kg";
        /*
         * Ввести вес и рост человека.Рассчитать и вывести индекс массы тела(ИМТ) по формуле I=m/(h* h); 
         * где m — масса тела в килограммах, h — рост в метрах.
        */
        static void BMI()
        {
            Console.WriteLine
                 ("The program of calculating your body mass index (BMI) welcomes you!\n" +
                 "Please, enter your height (cm) and weight (kg).\nUse space key or comma to split values.");
            string[] userInput = Regex.Split(Console.ReadLine(), @"\s|[,]\s|[,]");
            while (userInput.Length != 2)
            {
                Console.WriteLine("Sorry, the number of values you entered is exceeded.\nTry again.\n" +
                    "Please, enter your height (cm) and weight (kg).\nUse space key or comma to split values.");
                userInput = Regex.Split(Console.ReadLine(), @"\s|[,]\s|[,]");
            }
            double height, weight;
            bool heightIsNum = double.TryParse(userInput[0], out height);
            bool weightIsNum = double.TryParse(userInput[1], out weight);
            if (heightIsNum&&weightIsNum)
            {
                double bmi = weight / Math.Pow(height / 100, 2);
                Console.WriteLine($"Your BMI is {bmi:F1} and this value is considered to be {BMIRecommendation(bmi)}");
            }
            else
                Console.WriteLine("You entered invalid values");
        }
        static string BMIRecommendation(double BMIvalue) =>
            BMIvalue <= 15 ? "very severely underweight" :
            BMIvalue <= 16 ? "severely underweight" :
            BMIvalue <= 18.5 ? "underweight" :
            BMIvalue <= 25 ? "normal(healthy weight)" :
            BMIvalue <= 30 ? "overweight" :
            BMIvalue <= 35 ? "obese Class I (Moderately obese)" :
            BMIvalue <= 40 ? "obese Class II (Severely obese)" :
            "obese Class III (Very severely obese)";
        
        static void Main(string[] args)
        {
            //Profile();
            BMI();
        }

    }
}
           
    /*
а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 по формуле r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2).Вывести результат, используя спецификатор формата .2f(с двумя знаками после запятой);
б) * Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.
Написать программу обмена значениями двух переменных:
а) с использованием третьей переменной;
б) * без использования третьей переменной.
а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
б) * Сделать задание, только вывод организовать в центре экрана.
в) ** Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y).
*Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause).
Достаточно решить 3 задачи.Записывайте в начало программы условие и свою фамилию. Все программы создавайте в одном решении. Со звездочками задания выполняйте в том случае, если вы решили задачи без звездочек.

   */
 
