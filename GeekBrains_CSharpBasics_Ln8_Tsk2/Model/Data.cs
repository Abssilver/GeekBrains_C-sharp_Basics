using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

//Ремизов Павел
/*
Создайте простую форму на котором свяжите свойство Text элемента TextBox
со свойством Value элемента NumericUpDown
*/
namespace GeekBrains_CSharpBasics_Ln8_Tsk2.Model
{
    public class Data
    {
        Dictionary<int, string> textData = new Dictionary<int, string>();

        public int DataSize => textData.Count;
        void Add(string text, int index) => textData.Add(index, text);
        public void Edit(string text, int index)
        {
            if (textData.ContainsKey(index))
                textData[index] = text;
            else 
                Add(text, index);
        }
        public string Display(int index)
        {
            if (textData.Count > 0 && textData.ContainsKey(index))
                return textData[index];
            return null;
        }
    }
}
