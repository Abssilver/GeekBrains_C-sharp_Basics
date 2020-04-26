using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ремизов Павел
/*
а) Написать программу, которая запрашивает массу и рост человека, 
вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
*/

namespace GeekBrains_CSharpBasics_Ln2_Navigation
{
    partial class Ln2Tasks
    {
        internal static void BMICalculations()
        {
            Console.Title = "BMI Calculations";
            ExecuteBMIProgram();
            double height = GeekBrains_CSharpBasics_Ln1_Tsk2.Program.Height;
            double bmi = GeekBrains_CSharpBasics_Ln1_Tsk2.Program.BMIvalue;
            SayRecommendation(bmi, height);
        }
        static void ExecuteBMIProgram()
        {
            GeekBrains_CSharpBasics_Ln1_Tsk2.Program.BMI();
        }
        static void SayRecommendation(double userBMI, double userHeigth)
        {
            //I = m / (h * h)
            //BMIvalue = weight / Math.Pow(height / 100, 2);
            string cheerUpUser = string.Empty;
            double[] healthyBMI = new double[2] { 18.5, 25 }; //18.5 - exclusive
            int result = userBMI.CompareTo(healthyBMI[0]) < 0 ? -1 :
                         userBMI.CompareTo(healthyBMI[1]) >= 0 ? 1 : 0;
            switch (result)
            {
                case -1:
                    cheerUpUser = "No worry!\nOur recommendation for underweight person like you is " +
                                  "to gain a little bit more than " +
                                 $"{(healthyBMI[0] - userBMI) * Math.Pow(userHeigth / 100, 2):f2} kg";
                    break;
                case 0:
                    cheerUpUser = "Brilliant!\nYou have a great physique!\n" +
                        "There is no recommendations for you, just keep up the good work!";
                    break;
                case 1:
                    cheerUpUser = "No worry!\nOur recommendation for overweight person like you is " +
                    $"to lose at least {(userBMI - healthyBMI[1]) * Math.Pow(userHeigth / 100, 2):f2} kg";
                    break;
            }
            Console.WriteLine(cheerUpUser);
        }
    }
}