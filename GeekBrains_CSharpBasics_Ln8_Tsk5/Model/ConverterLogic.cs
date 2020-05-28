using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

//Ремизов Павел
/*
Написать программу-преобразователь из CSV в XML-файл с информацией о студентах (6 урок).
*/
namespace GeekBrains_CSharpBasics_Ln8_Tsk5.Model
{
    class ConverterLogic
    {
        List<StudentData> studentsData = new List<StudentData>();
        public void LoadData(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    try
                    {
                        string[] studentInfo = reader.ReadLine().Split(';');
                        if (studentInfo.Length == 9)
                            studentsData.Add(new StudentData(
                                studentInfo[0],
                                studentInfo[1],
                                studentInfo[2],
                                studentInfo[3],
                                studentInfo[4],
                                int.Parse(studentInfo[5]),
                                byte.Parse(studentInfo[6]),
                                int.Parse(studentInfo[7]),
                                studentInfo[8]
                                ));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
            }
        }
        public void Save(string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<StudentData>));
            if (studentsData.Count > 0)
                using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                    xmlFormat.Serialize(stream, studentsData);
        }
    }
}