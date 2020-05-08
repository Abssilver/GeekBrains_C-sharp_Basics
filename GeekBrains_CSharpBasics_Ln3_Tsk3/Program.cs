using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ремизов Павел
/*
* Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел.
 Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
 Написать программу, демонстрирующую все разработанные элементы класса.
 * Добавить свойства типа int для доступа к числителю и знаменателю;
* Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
** Добавить проверку, чтобы знаменатель не равнялся 0. 
Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
*** Добавить упрощение дробей.
*/

namespace GeekBrains_CSharpBasics_Ln3_Tsk3
{
    class Program
    {
        static void Main(string[] args)
        {
            FractionsDemonstation();
            Console.ReadKey();
        }
        static void FractionsDemonstation()
        {
            Console.Title = "Fractions";
            //Fraction fractionOne = new Fraction();
            Fraction fractionOne = new Fraction(50, 20);
            Fraction fractionTwo = new Fraction(7, 8);
            int number = -6;
            Console.WriteLine($"The first fraction is: {fractionOne}");
            Console.WriteLine($"The second fraction is: {fractionTwo}");
            Console.WriteLine($"The sum of this fractions is: {fractionOne + fractionTwo}");
            Console.WriteLine($"The difference of this fractions is: {fractionOne - fractionTwo}");
            Console.WriteLine($"The product of this fractions is: {fractionOne * fractionTwo}");
            Console.WriteLine($"The quotient of this fractions is: {fractionOne / fractionTwo}");
            Console.WriteLine($"The sum of the fraction {fractionOne} and number {number} is : " +
                $"{fractionOne.AddNumberToFraction(number)}");
            Console.WriteLine($"The difference of the fraction {fractionOne} and number {number} is : " +
                $"{fractionOne.SubtractNumberFromFraction(number)}");
            Console.WriteLine($"The quotient of the fraction {fractionOne} and number {number} is : " +
                $"{fractionOne.DivideFractionByNumber(number)}");
            Console.WriteLine($"The product of the fraction {fractionOne} and number {number} is : " +
                $"{fractionOne.MultiplyFractionByNumber(number)}");
        }
        class Fraction
        {
            public int Numerator { get; private set; } = 0;
            public int Denominator { get; private set; } = 1;
            public double decimalFraction => (double)Numerator / (double)Denominator;
            public Fraction(int numerator, int denominator)
            {
                this.Numerator = numerator;
                if (denominator.Equals(0))
                    throw new ArgumentException(
                        string.Format("The denominator cannot be equal to 0"));
                else
                    this.Denominator = denominator;
                if (!this.Numerator.Equals(0))
                    FractionSimplification(this.Numerator, this.Denominator);
            }
            public Fraction() { }
            public void FractionSimplification(int numerator, int denominator)
            {
                numerator = numerator > 0 ? numerator : -numerator;
                denominator = denominator > 0 ? denominator : -denominator;
                int GCF = GreatestCommonFactor(numerator, denominator);
                if (GCF != 1)
                {
                    this.Numerator /= GCF;
                    this.Denominator /= GCF;
                }
            }
            int GreatestCommonFactor(int first, int second) =>
                first != second ? first > second ?
                GreatestCommonFactor(first - second, second) :
                GreatestCommonFactor(first, second - first) : first;
            Fraction Addition(Fraction toAdd) =>
                new Fraction(this.Numerator * toAdd.Denominator + Denominator * toAdd.Numerator,
                    this.Denominator * toAdd.Denominator);
            Fraction Subtraction(Fraction toSubtract) =>
                this.Addition(toSubtract.MultiplyFractionByNumber(-1));
            Fraction Multiplication(Fraction toMultiplyWith) =>
                new Fraction(this.Numerator * toMultiplyWith.Numerator,
                    this.Denominator * toMultiplyWith.Denominator);
            Fraction Division(Fraction divideBy) =>
                new Fraction(this.Numerator * divideBy.Denominator,
                    this.Denominator * divideBy.Numerator);
            public Fraction MultiplyFractionByNumber(int number) =>
                new Fraction(this.Numerator * number, this.Denominator);
            public Fraction DivideFractionByNumber(int number) => number>0?
                new Fraction(this.Numerator, this.Denominator * number):
                new Fraction(this.Numerator*(-1), this.Denominator * -number);
            public Fraction AddNumberToFraction(int number) =>
                new Fraction(this.Numerator + this.Denominator * number, this.Denominator);
            public Fraction SubtractNumberFromFraction(int number) =>
                AddNumberToFraction(-number);
            public static Fraction operator +(Fraction first, Fraction second)
                => first.Addition(second);
            public static Fraction operator -(Fraction first, Fraction second)
                => first.Subtraction(second);
            public static Fraction operator *(Fraction first, Fraction second)
                => first.Multiplication(second);
            public static Fraction operator /(Fraction first, Fraction second)
                => first.Division(second);
            public override string ToString() =>
                Math.Abs(Numerator) < Math.Abs(Denominator) && Numerator != 0 ?
                $"[ {Numerator} / {Denominator} ]" :
                Math.Abs(Numerator) > Math.Abs(Denominator) && Numerator % Denominator != 0 ?
                $"[ {Numerator / Denominator} and {Math.Abs(Numerator % Denominator)} / {Denominator} ]" :
                $"[ {Numerator / Denominator} ]";
        }
    }
}