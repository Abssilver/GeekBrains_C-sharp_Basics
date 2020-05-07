using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ремизов Павел
/*
а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. 
Продемонстрировать работу структуры.
б) Дописать класс Complex, добавив методы вычитания и произведения чисел. 
Проверить работу класса.
в) Добавить диалог с использованием switch демонстрирующий работу класса.
*/

namespace GeekBrains_CSharpBasics_Ln3_Tsk1
{
    class Program
    {
        static void Main(string[] args)
        {
            DialogueWithUser();
            Console.ReadLine();
        }
        static void DialogueWithUser()
        {
            Console.Title = "Fun with Classes and Structures";
            Console.WriteLine("This is Lesson 3 Homework, Task 1\n" +
                             "Please, choose an option you would like to check\n" +
                             "1 - Structures\n" +
                             "2 - Classes\n" +
                             "Press 0 to exit");
            object userInput = Console.ReadLine();
            var choice = int.TryParse(userInput.ToString(), out int option) ? option : userInput;
            switch (choice)
            {
                case int number when number == 1:
                case string optionName when optionName.Equals("Structures", StringComparison.OrdinalIgnoreCase):
                    DemonstrateStructWork();
                    break;
                case int number when number == 2:
                case string optionName when optionName.Equals("Classes", StringComparison.OrdinalIgnoreCase):
                    DemonstrateClassWork();
                    break;
                default:
                    Console.WriteLine("Bye-Bye!");
                    break;
            }
        }
        static void DemonstrateClassWork()
        {
            ComplexClass complexOne = new ComplexClass(4, 4);
            ComplexClass complexTwo = new ComplexClass(1, 2);
            Console.WriteLine($"The first complex number: {complexOne}");
            Console.WriteLine($"The second complex number: {complexTwo}");
            Console.WriteLine("What operation would you like to check?\n" +
                "1 - Addition\n" +
                "2 - Subtraction\n" +
                "3 - Multiplication");
            object userInput = Console.ReadLine();
            var choice = int.TryParse(userInput.ToString(), out int operation) ? operation : userInput;
            switch (choice)
            {
                case int number when number == 1:
                case string operationName when operationName.Equals("Addition", StringComparison.OrdinalIgnoreCase):
                    Console.WriteLine($"The sum of this complex numbers is: {complexOne + complexTwo}");
                    break;
                case int number when number == 2:
                case string operationName when operationName.Equals("Subtraction", StringComparison.OrdinalIgnoreCase):
                    Console.WriteLine
                        ($"The difference of this complex numbers is: {complexOne - complexTwo}");
                    break;
                case int number when number == 3:
                case string operationName when operationName.Equals("Multiplication", StringComparison.OrdinalIgnoreCase):
                    Console.WriteLine($"The product of this complex numbers is: {complexOne * complexTwo}");
                    break;
                default:
                    break;
            }

        }
        static void DemonstrateStructWork()
        {
            ComplexStruct complexOne = new ComplexStruct(3, 5);
            ComplexStruct complexTwo = new ComplexStruct(4, 2);
            Console.WriteLine($"The first complex number: {complexOne}");
            Console.WriteLine($"The second complex number: {complexTwo}");
            Console.WriteLine("What operation would you like to check?\n" +
                "1 - Addition\n" +
                "2 - Subtraction\n" +
                "3 - Multiplication");
            object userInput = Console.ReadLine();
            var choice = int.TryParse(userInput.ToString(), out int operation) ? operation : userInput;
            switch (choice)
            {
                case int number when number == 1:
                case string operationName when operationName.Equals("Addition", StringComparison.OrdinalIgnoreCase):
                    Console.WriteLine($"The sum of this complex numbers is: {complexOne + complexTwo}");
                    break;
                case int number when number == 2:
                case string operationName when operationName.Equals("Subtraction", StringComparison.OrdinalIgnoreCase):
                    Console.WriteLine
                        ($"The difference of this complex numbers is: {complexOne - complexTwo}");
                    break;
                case int number when number == 3:
                case string operationName when operationName.Equals("Multiplication", StringComparison.OrdinalIgnoreCase):
                    Console.WriteLine($"The product of this complex numbers is: {complexOne * complexTwo}");
                    break;
                default:
                    break;
            }
        }
        struct ComplexStruct
        {
            public double real, imaginary;
            public ComplexStruct(double real, double imaginary)
            {
                this.real = real;
                this.imaginary = imaginary;
            }
            public ComplexStruct Addition(ComplexStruct toAdd) => new ComplexStruct
            {
                real = this.real + toAdd.real,
                imaginary = this.imaginary + toAdd.imaginary
            };
            public ComplexStruct Subtraction(ComplexStruct toSubtract) => new ComplexStruct
            {
                real = this.real - toSubtract.real,
                imaginary = this.imaginary - toSubtract.imaginary
            };
            public ComplexStruct Multiplication(ComplexStruct toMultiplyWith) => new ComplexStruct
            {
                real = this.real * toMultiplyWith.real - this.imaginary * toMultiplyWith.imaginary,
                imaginary = this.imaginary * toMultiplyWith.real + this.real * toMultiplyWith.imaginary
            };
            public static ComplexStruct operator +(ComplexStruct first, ComplexStruct second)
                => first.Addition(second);
            public static ComplexStruct operator -(ComplexStruct first, ComplexStruct second)
                => first.Subtraction(second);
            public static ComplexStruct operator *(ComplexStruct first, ComplexStruct second)
                => first.Multiplication(second);
            public override string ToString() => $"{real} + {imaginary}i";
        }
        class ComplexClass
        {
            private double imaginary;
            public double Real { get; }
            public double Imaginary
            {
                get
                { return imaginary; }
                private set
                {
                    // Для примера ограничимся только положительными числами.
                    if (value >= 0)
                        imaginary = value;
                }
            }
            public ComplexClass()
            {
                Real = default;
                imaginary = default;
            }
            public ComplexClass(double real, double imaginary)
            {
                this.Real = real;
                this.imaginary = imaginary;
            }
            public ComplexClass Addition(ComplexClass toAdd) =>
                new ComplexClass(this.Real + toAdd.Real, this.imaginary + toAdd.imaginary);
            public ComplexClass Subtraction(ComplexClass toSubtract) =>
                new ComplexClass(this.Real - toSubtract.Real, this.imaginary - toSubtract.imaginary);
            public ComplexClass Multiplication(ComplexClass toMultiplyWith) =>
                new ComplexClass
                (this.Real * toMultiplyWith.Real - this.imaginary * toMultiplyWith.imaginary,
                    this.imaginary * toMultiplyWith.Real + this.Real * toMultiplyWith.imaginary);
            public static ComplexClass operator +(ComplexClass first, ComplexClass second)
                => first.Addition(second);
            public static ComplexClass operator -(ComplexClass first, ComplexClass second)
                => first.Subtraction(second);
            public static ComplexClass operator *(ComplexClass first, ComplexClass second)
                => first.Multiplication(second);
            public override string ToString() => $"{Real} + {imaginary}i";
        }
    }
}