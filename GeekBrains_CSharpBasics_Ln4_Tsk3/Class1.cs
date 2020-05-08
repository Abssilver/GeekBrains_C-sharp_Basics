using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

//Ремизов Павел
/*
а) Дописать класс для работы с одномерным массивом.
Реализовать конструктор, создающий массив определенного размера и 
заполняющий массив числами от начального значения с заданным шагом.
Создать свойство Sum, которое возвращает сумму элементов массива, 
метод Inverse, возвращающий новый массив с измененными знаками у всех 
элементов массива(старый массив, остается без изменений),  метод Multi, 
умножающий каждый элемент массива на определённое число, свойство MaxCount, 
возвращающее количество максимальных элементов.
б)** Создать библиотеку содержащую класс для работы с массивом.Продемонстрировать работу библиотеки
е) *** Подсчитать частоту вхождения каждого элемента в массив(коллекция Dictionary<int, int>)
*** Website version
б)Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл. 
*/

namespace GeekBrains_CSharpBasics_Ln4_Tsk3
{
    public class OneDimensionalArray
    {
        Dictionary<int, int> elementEntryFrequency = new Dictionary<int, int>();
        int[] array;
        public OneDimensionalArray(int length) => array = new int[length];
        //  Создание массива и заполнение его одним значением element
        public OneDimensionalArray(int length, int element)
        {
            array = new int[length];
            for (int i = 0; i < length; i++)
                array[i] = element;
        }
        //  Создание массива и заполнение его случайными числами от min до max
        public OneDimensionalArray(int length, int min, int max) : this(length)
        {
            Random random = new Random();
            for (int i = 0; i < length; i++)
                array[i] = random.Next(min, max + 1);
        }
        public OneDimensionalArray(int length, (int startValue, int step) tuple)
        {
            array = new int[length];
            for (int i = 0; i < length; i++)
                array[i] = tuple.startValue + tuple.step * i;
        }
        public OneDimensionalArray(string filename)
        {
            if (File.Exists(filename))
            {
                using (StreamReader strReader = new StreamReader(filename))
                {
                    int.TryParse(strReader.ReadLine(), out int length);
                    array = new int[length];
                    for (int i = 0; i < length; i++)
                    {
                        int.TryParse(strReader.ReadLine(), out array[i]);
                    }
                }
            }
            else
                array = new int[10];
        }
        public void WriteToFile(string filename)
        {
            using (StreamWriter strWriter = new StreamWriter(filename))
            {
                strWriter.WriteLine(array.Length);
                foreach (var element in array)
                    strWriter.WriteLine(element);
            }
        }
        void CreateAFrequencyCollection(int[] array)
        {
            foreach (var item in array)
            {
                if (elementEntryFrequency.ContainsKey(item))
                    elementEntryFrequency[item]++;
                else
                    elementEntryFrequency.Add(item, 1);
            }
        }
        public void ShowFrequencyCollection()
        {
            CreateAFrequencyCollection(array);
            foreach (var item in elementEntryFrequency)
                Console.WriteLine($"The number {item.Key} is presented {item.Value} times in array");
        }
        public int[] Inverse() => MultiplyByNumber(-1);
        public int[] MultiplyByNumber(int number) => array.Select(x => x * number).ToArray();
        public int MaxCount => array.Where(x => x.Equals(array.Max())).Count();
        public int MaxElement => array.Max();
        public int MinElement => array.Min();
        public int CountPositiveNumbers => array.Where(x => x > 0).Count();
        public int SumOfEven => array.Where(x => x % 2 == 0).Sum();
        public int SumOfElements => array.Sum();
        public int this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }
        public override string ToString() => string.Join(" ", array);
    }
}