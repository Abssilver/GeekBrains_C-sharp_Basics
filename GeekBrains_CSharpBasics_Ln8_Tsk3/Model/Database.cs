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
а) Создать приложение, показанное на уроке, 
добавив в него защиту от возможных ошибок
(не создана база данных, обращение к несуществующему вопросу,
открытие слишком большого файла и т.д.).
б) Изменить интерфейс программы, 
увеличив шрифт, поменяв цвет элементов
и добавив другие «косметические» улучшения на свое усмотрение.
в) Добавить в приложение меню 
«О программе» с информацией о программе (автор, версия, авторские права и др.).
г) Добавить в приложение сообщение с предупреждением при попытке удалить вопрос.
д) Добавить пункт меню Save As,
в котором можно выбрать имя для сохранения базы данных(элемент SaveFileDialog).
*/
namespace GeekBrains_CSharpBasics_Ln8_Tsk3.Model
{
    class Database
    {
        public Action ChangeCurrent { get; set; }
        List<Question> list;
        int current = -1;
        int maxFileSize = int.MaxValue;
        public int Current
        {
            get
            {
                return current;
            }
            private set
            {
                current = value;
                ChangeCurrent?.Invoke();
            }
        }
        public Question GetCurrentQuestion => current == -1 ? null : list[Current];
        public int Count => list.Count;

        public Database()
        {
            list = new List<Question>();
            Current = -1;
        }
        public void Add(Question question)
        {
            list.Add(question);
            Current = list.Count - 1;
        }
        public void Remove()
        {
            if (Current != -1)
            {
                list.RemoveAt(Current);
                Current--;
            }
        }
        public void Edit(Question question) => list[Current] = question;

        public void Next()
        {
            if (Current + 1 < list.Count)
                Current++;
        }
        public void Previous()
        {
            if (Current > 0)
                Current--;
        }
        public void Save(string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
        }
        public void Load(string fileName, out bool loaded)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            loaded = false;
            using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                if (stream.Length > maxFileSize)
                {
                    if (MessageBox.Show("The file length is too big.\nContinue?",
                        "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                }
                list = (List<Question>)xmlFormat.Deserialize(stream);
                //Current = 0;
            }
            loaded = true;
        }
    }
}
