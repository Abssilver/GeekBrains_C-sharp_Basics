using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

//Ремизов Павел
/*
* а) Реализовать библиотеку с классом для работы с двумерным массивом.
Реализовать конструктор, заполняющий массив случайными числами.
Создать методы, которые возвращают сумму всех элементов массива, 
сумму всех элементов массива больше заданного, свойство, возвращающее 
минимальный элемент массива, свойство, возвращающее максимальный элемент массива,
метод, возвращающий номер максимального элемента массива
(через параметры, используя модификатор ref или out).
** б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
** в) Обработать возможные исключительные ситуации при работе с файлами.
*/

namespace GeekBrains_CSharpBasics_Ln4_Tsk5
{
    public class TwoDimensionalArray
    {
        int[,] matrix;
        List<int[]> listOfMatrixRows = new List<int[]>();
        public TwoDimensionalArray((int rows, int columns) size, int min, int max)
        {
            listOfMatrixRows.Clear();
            matrix = new int[size.rows, size.columns];
            Random random = new Random();
            for (int i = 0; i < size.rows; i++)
            {
                int[] elementsOfRow = new int[size.columns];
                for (int j = 0; j < size.columns; j++)
                {
                    matrix[i, j] = random.Next(min, max + 1);
                    elementsOfRow[j] = matrix[i, j];
                }
                listOfMatrixRows.Add(elementsOfRow);
            }
        }
        public TwoDimensionalArray(string filename)
        {
            LoadDataFromFile(filename);
        }
        public void LoadDataFromFile(string filename) 
        {
            listOfMatrixRows.Clear();
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader strReader = new StreamReader(filename))
                {
                    string line;
                    while ((line = strReader.ReadLine()) != null)
                        listOfMatrixRows.Add(Array.ConvertAll(line.Trim(' ').Split(' '), int.Parse));
                }
                if (listOfMatrixRows.Count > 0)
                {
                    JaggedArrayCheck(listOfMatrixRows);
                    matrix = new int[listOfMatrixRows.Count, listOfMatrixRows[0].Length];
                    TransferDataToMatrix(listOfMatrixRows);
                    Console.WriteLine("Loading is complete.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        public void SaveDataToFile(string filename)
        {
            TransferDataFromMatrixToList(listOfMatrixRows);
            try
            {
                using (StreamWriter strWriter = 
                    new StreamWriter(filename, false, System.Text.Encoding.Default))
                {
                    for (int i = 0; i < listOfMatrixRows.Count; i++)
                        strWriter.WriteLine(string.Join(" ", listOfMatrixRows[i]));
                }
                Console.WriteLine("Saving is complete.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be saved:");
                Console.WriteLine(e.Message);
            }
        }
        void JaggedArrayCheck(List<int[]> fileData)
        {
            if (fileData.Count > 1)
                for (int i = 0; i < fileData.Count - 1; i++)
                    if (!fileData[i].Length.Equals(fileData[i + 1].Length))
                        throw new ArgumentException(
                            "This class is not able to work with jagged multidimensional arrays");
        }
        void TransferDataToMatrix(List<int[]> fileData)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = fileData[i][j];
        }
        void TransferDataFromMatrixToList(List<int[]> fileData)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    fileData[i][j] = matrix[i, j];
        }
        public int SumOfArrayElements() => matrix.Cast<int>().Sum();
        public int SumOfArrayElementsThatMoreThan(int number) => 
            matrix.Cast<int>().Where(x => x > number).Sum();
        public int MinOfArray => matrix.Cast<int>().Min();
        public int MaxOfArray => matrix.Cast<int>().Max();
        public ref int PositionOfMaxElement(out (int row, int column) position)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j].Equals(MaxOfArray))
                    {
                        position = (i, j);
                        return ref matrix[i, j];
                    }
            if (matrix.Length == 0)
                throw new IndexOutOfRangeException("There is no elements in array.");
            position = (0, 0);
            return ref matrix[0, 0];
        }
        public int SumOfArrayElementsClassic()
        {
            int sum = 0;
            foreach (var item in matrix) //check for condition
                sum += item;
            return sum;
        }
        public int this[int row, int column]
        {
            get => matrix[row, column];
            set => matrix[row, column] = value;
        }
        public override string ToString()
        {
            TransferDataFromMatrixToList(listOfMatrixRows);
            string output = string.Empty;
            for (int i = 0; i < listOfMatrixRows.Count; i++)
            {
                string matrixRowToString = string.Join(" ", listOfMatrixRows[i]);
                output = string.Concat(output, matrixRowToString, Environment.NewLine);
            }
            return output;
        }
    }
}