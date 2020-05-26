using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

//Ремизов Павел (задание выполнено в рамках старой методички)
/*
**Считайте файл различными способами. 
Смотрите “Пример записи файла различными способами”. 
Создайте методы, которые возвращают массив byte (FileStream, BufferedStream), 
строку для StreamReader и массив int для BinaryReader.
*/
namespace GeekBrains_CSharpBasics_Ln6_Tsk4
{
    class Program
    {
        static void Main(string[] args)
        {
            long kbyte = 1024;
            long mbyte = 1024 * kbyte;
            //long gbyte = 1024 * mbyte;
            long size = mbyte;
            byte[] dataArray = new byte[size];
            new Random().NextBytes(dataArray);
            Console.WriteLine
                ("FileStream. Milliseconds:{0}",
                FileStreamSample(@"..\..\FileStreamData.bin", dataArray));//Write FileStream
            Console.WriteLine
                ("BinaryStream. Milliseconds:{0}",
                BinaryStreamSample(@"..\..\BinaryStreamData.bin", dataArray));//Write BinaryStream
            Console.WriteLine
                ("StreamWriter. Milliseconds:{0}",
                StreamWriterSample(@"..\..\StreamWriterData.bin", dataArray));//Write StreamWriter
            Console.WriteLine
                ("BufferedStream. Milliseconds:{0}", 
                BufferedStreamSample(@"..\..\BufferedStreamData.bin", dataArray));//Write BufferedStream
            Console.WriteLine("Reading data...");
            Console.WriteLine
                ("FileStream. Success: {0}",
                CheckValues(dataArray, FileStreamReader(@"..\..\FileStreamData.bin")));
            Console.WriteLine
                ("BinaryStream. Success: {0}",
                CheckValues(dataArray, BinaryStreamReader(@"..\..\BinaryStreamData.bin")));
            Console.WriteLine
                ("StreamReader. Success: {0}",
                string.Join("", dataArray) == StreamReaderReader(@"..\..\StreamWriterData.bin"));
            Console.WriteLine
                ("BufferedStream. Success: {0}",
                CheckValues(dataArray, BufferedStreamReader(@"..\..\BufferedStreamData.bin")));
            Console.ReadKey();
        }
        static bool CheckValues(byte[] origin, byte[] fromFile)
        {
            if (origin.Length != fromFile.Length)
                return false;
            for (int i = 0; i < origin.Length; i++)
            {
                if (origin[i] != fromFile[i])
                    return false;
            }
            return true;
        }
        static bool CheckValues(byte[] origin, int [] fromFile)
        {
            if (origin.Length != fromFile.Length)
                return false;
            for (int i = 0; i < origin.Length; i++)
            {
                if (origin[i] != (byte)fromFile[i])
                    return false;
            }
            return true;
        }
        static long FileStreamSample(string fileName, byte[] dataArray)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                fileStream.Write(dataArray, 0, dataArray.Length);
                //for (int i = 0; i < dataArray.Length; i++)
                //    fileStream.WriteByte(dataArray[i]);
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        static byte[] FileStreamReader(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    byte[] dataArray = new byte[fileStream.Length];
                    fileStream.Read(dataArray, 0, (int)fileStream.Length);
                    //for (int i = 0; i < fileStream.Length; i++)
                    //dataArray[i] = (byte)fileStream.ReadByte();
                    return dataArray;
                }
            }
            return null;
        }
        static long BinaryStreamSample(string fileName, byte[] dataArray)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (BinaryWriter writer =
                    new BinaryWriter(File.Open(fileName, FileMode.Create, FileAccess.Write)))
                //for (int i = 0; i < dataArray.Length; i++)
                //    writer.Write(dataArray[i]);
                writer.Write(dataArray, 0, dataArray.Length);
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        static int[] BinaryStreamReader(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (BinaryReader reader =
                        new BinaryReader(File.Open(fileName, FileMode.Open, FileAccess.Read)))
                {
                    /*
                    byte[] dataArray= new byte[reader.BaseStream.Length];
                    reader.Read(dataArray, 0, dataArray.Length);
                    */
                    //int dataAmount = Convert.ToInt32(reader.BaseStream.Length / sizeof(int)));
                    int[] dataArray = new int[reader.BaseStream.Length];
                    for (int i = 0; i < dataArray.Length; i++)
                       dataArray[i] = reader.ReadByte();
                    //for (int i = 0; i < dataAmount; i++)
                    //    dataArray[i] = reader.ReadInt32();
                    return dataArray;
                }
            }
            return null;
        }
        static long StreamWriterSample(string fileName, byte[] dataArray)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (StreamWriter writer =
                new StreamWriter(File.Open(fileName, FileMode.Create, FileAccess.Write)))
                for (int i = 0; i < dataArray.Length; i++)
                    writer.Write(dataArray[i]);
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        static string StreamReaderReader(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (StreamReader reader =
                        new StreamReader(File.Open(fileName, FileMode.Open, FileAccess.Read)))
                {
                    char[] buffer = new char[(int)reader.BaseStream.Length];
                    reader.Read(buffer, 0, (int)reader.BaseStream.Length);
                    return new string(buffer);
                }
            }
            return null;
        }
        static long BufferedStreamSample(string fileName, byte[] dataArray)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //Used if data is repeated
            //int parts = 4;//number of parts
            //int bufferSize = dataArray.Length / parts;
            using (BufferedStream bufferedStream = 
                new BufferedStream(File.Open(fileName, FileMode.Create, FileAccess.Write), dataArray.Length))
                //for (int i = 0; i < dataArray.Length; i++)
                    bufferedStream.Write(dataArray, 0, dataArray.Length);
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        static byte[] BufferedStreamReader(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (Stream stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    //int parts = 4;//number of parts
                    //int bufferSize = (int)stream.Length / parts;
                    using (BufferedStream bufferedStream = new BufferedStream(stream, (int)stream.Length))
                    {
                        byte[] dataArray = new byte[stream.Length];
                        //for (int i = 0; i < parts; i++)
                            bufferedStream.Read(dataArray, 0, (int)stream.Length);
                        return dataArray;
                    }
                }
            }
            return null;
        }
    }
}
