using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBrains_CSharpBasics_Ln8_Tsk4.Model
{
    public class Expense
    {
        public string Text { get; set; }
        public string Category { get; set; }
        public decimal Value { get; set; }
        public Expense()
        {
        }
        public Expense(string text, string category, decimal value)
        {
            this.Text = text;
            this.Category = category;
            this.Value = value;
        }
    }
}
