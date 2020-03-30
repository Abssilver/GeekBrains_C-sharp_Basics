using System;

namespace GeekBrains_ln1_tsk4
{
    class Program
    {
        //Ремизов Павел
        /*
         * Написать программу обмена значениями двух переменных:
         * а) с использованием третьей переменной;
         * б) * без использования третьей переменной. 
        */
        static void SwapValue<T>(ref T a, ref T b)
        {
            T temporal = a;
            a = b;
            b = temporal;
        }
        static void SwapWithNoIntermediary(ref int a, ref int b)
        {
            a = a ^ b;
            b = b ^ a;
            a = a ^ b;
        }
        public class Test 
        {
            public int a;
            public Test(int a)
            {
                this.a = a;
            }
        }
        static void Main(string[] args)
        {
            //swap tests
            double a = 6.2, b = 8.1;
            int c = -1, d = 0;
            bool e = true, f = false;
            Test one = new Test(1);
            Test two = new Test(2);

            Console.WriteLine($"{one.a} * {two.a}");
            SwapValue(ref one, ref two);
            Console.WriteLine($"{one.a} * {two.a}");

            Console.WriteLine($"a={a} * b={b}");
            SwapValue(ref a, ref b);
            Console.WriteLine($"a={a} was swapped with b={b}");

            Console.WriteLine($"c={c} * d={d}");
            SwapValue(ref c, ref d);
            Console.WriteLine($"c={c} was swapped with d={d}");
            SwapWithNoIntermediary(ref c, ref d);
            Console.WriteLine($"c={c} was swapped with d={d}, again, without buffer");

            Console.WriteLine($"e={e} * f={f}");
            SwapValue(ref e, ref f);
            Console.WriteLine($"e={e} was swapped with f={f}");
            
        }
    }
}
