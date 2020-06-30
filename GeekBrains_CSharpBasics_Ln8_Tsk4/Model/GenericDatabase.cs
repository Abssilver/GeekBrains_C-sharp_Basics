using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

//Ремизов Павел
/*
*Используя полученные знания и класс TrueFalse в качестве шаблона,
разработать собственную утилиту хранения данных 
(Например: Дни рождения, Траты, Напоминалка, Английские слова и другие).
*/
namespace GeekBrains_CSharpBasics_Ln8_Tsk4.Model
{
    class GenericDatabase<T> where T : class
    {
        public Action ChangeCurrent { get; set; }
        List<T> list;
        int current = -1;
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
        public T GetCurrentElement => current == -1 ? null : list[Current];
        public int Count => list.Count;
        public GenericDatabase()
        {
            list = new List<T>();
            Current = -1;
        }
        public T this[int index]
        {
            get 
            {
                if (index < Count && Count > 0 && index >= 0)
                {
                    return list[index];
                }
                return null;
            }
        }
        public void Add(T element)
        {
            list.Add(element);
            Current = list.Count - 1;
        }
        public void Remove()
        {
            if (Current != -1)
            {
                list.RemoveAt(Current);
                if (list.Count > 0 && Current - 1 == -1)
                    Current = current;
                else
                    Current--;
            }
        }
        public void Edit(T element) => list[Current] = element;

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
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<T>));
            using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                xmlFormat.Serialize(stream, list);
        }
        public void Load(string fileName, out bool loaded)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<T>));
            loaded = false;
            using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                list = (List<T>)xmlFormat.Deserialize(stream);
            loaded = true;
            if (list.Count > 0) Current = 0;
        }
    }
}

