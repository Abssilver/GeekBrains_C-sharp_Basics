using System;
using System.Text.RegularExpressions;

//Ремизов Павел
/*
 * Ввести вес и рост человека.Рассчитать и вывести индекс массы тела(ИМТ) по формуле I=m/(h* h); 
 * где m — масса тела в килограммах, h — рост в метрах.
*/
namespace GeekBrains_CSharpBasics_Ln1_Tsk2
{
    class Program
    {
        static void BMI()
        {
            Console.Title = "BMI";
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
            if (heightIsNum && weightIsNum)
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
            BMI();
            Console.ReadKey();
        }
    }
}