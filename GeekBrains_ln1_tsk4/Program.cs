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
        static void SwapValue<T>(ref T a, ref T b) where T : struct
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
        static void Main(string[] args)
        {
            //swap test
            double a = 6.2, b = 8.1;
            int c = -1, d = 0;
            bool e = true, f = false;
            SwapValue(ref a, ref b);
            Console.WriteLine($"a={a} was swapped with b={b}");
            SwapValue(ref c, ref d);
            Console.WriteLine($"c={c} was swapped with d={d}");
            SwapValue(ref e, ref f);
            Console.WriteLine($"e={e} was swapped with f={f}");
            SwapWithNoIntermediary(ref c, ref d);
            Console.WriteLine($"c={c} was swapped with d={d}, again, without buffer");
        }
    }
}
