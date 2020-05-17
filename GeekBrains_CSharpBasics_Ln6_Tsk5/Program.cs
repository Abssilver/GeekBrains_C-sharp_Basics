using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//Ремизов Павел
/*
**Модифицировать задачу “Сложную задачу” ЕГЭ так, чтобы она решала задачу с 10 000 000
элементов менее чем за минуту.
*/
/* base 
 * >> при перемножении двух чисел, по значению близких к 100 000, происходит переполнение типа int
Для заданной последовательности неотрицательных целых чисел необходимо найти максимальное
произведение двух её элементов, номера которых различаются не менее, чем на 8. Значение каждого
элемента последовательности не превышает 100 000. Количество элементов последовательности
равно 100 000. Сгенерировать файл из случайных чисел и решить эту задачу
*/
namespace GeekBrains_CSharpBasics_Ln6_Tsk5
{
    class Program
    {
        static void Save(string fileName, int[] arrayToSave)
        {
            using (BinaryWriter writer =
                new BinaryWriter(File.Open(fileName, FileMode.Create, FileAccess.Write)))
            {
                foreach (var element in arrayToSave)
                    writer.Write(element);
            }
        }
        static void Load(string fileName)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int[] data;
            using (BinaryReader reader =
                new BinaryReader(File.Open(fileName, FileMode.Open, FileAccess.Read)))
            {
                data = new int[reader.BaseStream.Length/sizeof(int)];
                for (int i = 0; i < data.Length; i++)
                    data[i] = reader.ReadInt32();
            }
            /*
            int max = 0;
            try
            {
                for (int i = 0; i < data.Length; i++)
                    for (int j = 0; j < data.Length; j++)
                        if (Math.Abs(i - j) >= 8 && data[i] * data[j] > max)
                        {
                            max = data[i] * data[j];
                            Console.WriteLine(max);
                        }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! {ex.Message}");
            }
            */
            //int max = MaximumProductOfTwoElements(data, 8);
            Console.WriteLine(FastSearch(data, 8));
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            //Console.WriteLine(max);
        }
        static long FastSearch(int[] data, int positionDifference)
        {
            int[] indexArray = new int[positionDifference];
            int[] valuesArray = new int[positionDifference];
            int maxIndex; 
            for (int i = 0; i < positionDifference; i++)
            {
                maxIndex = Array.IndexOf(data, data.Max());
                indexArray[i] = maxIndex;
                valuesArray[i] = data[maxIndex];
                data[maxIndex] = -1;
            }
            if (Math.Abs(indexArray[0] - indexArray[1]) >= positionDifference)
                return valuesArray[0] * valuesArray[1];
            List<long> maxValueList = new List<long>();
            for (int i = 0; i < positionDifference; i++)
                for (int j = 0; j < positionDifference; j++)
                    if (i != j)
                        maxValueList.Add(valuesArray[i] * valuesArray[j]);
            return maxValueList.Max();
        }
        static int MaximumProductOfTwoElementsSlow(int[] data, int positionDifference)//another try
        {
            Queue<int> buffer = new Queue<int>();
            for (int i = positionDifference; i < data.Length; i++)
                buffer.Enqueue(data[i]);
            int max = 0;
            int valueToCompare;
            for (int i = 0; i < data.Length - positionDifference; i++)
            {
                if (i > 0 && data[i] <= data[i - 1])
                {
                    buffer.Dequeue();
                    continue;
                }
                valueToCompare = data[i] * buffer.Max();
                if (max < valueToCompare)
                {
                    max = valueToCompare;
                    buffer.Dequeue();
                    Console.WriteLine($"{max} - second");
                }    
            }
            return max;
        }
        static void Main(string[] args)
        {
            Save("data.bin", GenerateAnArray(10_000_000));
            Load("data.bin");
            Console.ReadKey();
        }
        static int[] GenerateAnArray(int size)
        {
            Random random = new Random();
            int[] toReturn = new int[size];
            for (int i = 0; i < size; i++)
                toReturn[i] = random.Next(0, 100_000);
            return toReturn;
        }
    }
}
