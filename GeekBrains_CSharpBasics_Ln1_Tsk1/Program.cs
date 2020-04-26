using System;

//Ремизов Павел
/*
 * Написать программу «Анкета». Последовательно задаются вопросы(имя, фамилия, возраст, рост, вес). 
 * В результате вся информация выводится в одну строчку:
 * а) используя склеивание;
 * б) используя форматированный вывод;
 * в) используя вывод со знаком $.
*/
namespace GeekBrains_CSharpBasics_Ln1_Tsk1
{
    class Program
    {
        public class ProfileData
        {
            public string name, surname;
            public int age;
            public double height, weight;
        }
        static void Profile()
        {
            Console.Title = "Profile Program";
            ProfileData userdata = new ProfileData();
            Console.WriteLine
                ("The Profile program welcomes you!\nPlease, answer to next questions.");
            Console.WriteLine("What is your name?");
            userdata.name = Console.ReadLine();
            Console.WriteLine($"Ok, {userdata.name}, and your surname?");
            userdata.surname = Console.ReadLine();
            userdata.age = (int)NumberCheck("How old are you? (number)");
            userdata.height = NumberCheck("What is your height? (number / cm)");
            userdata.weight = NumberCheck("And what about your weight? (number / kg)");
            Console.WriteLine
                ("Solution to check:\na - for concatination\n" +
                                     "b - for composit formatting\n" +
                                     "c - for string interpolation");
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
        static double NumberCheck(string msg)
        {
            double number;
            bool inputIsNum;
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

        static void Main(string[] args)
        {
            Profile();
            Console.ReadKey();
        }
    }
}
