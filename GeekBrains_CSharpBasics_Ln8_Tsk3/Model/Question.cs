﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBrains_CSharpBasics_Ln8_Tsk3.Model
{
    public class Question
    {
        public string Text { get; set; }
        public bool TrueFalse { get; set; }
        public Question()
        { 
        }
        public Question(string text, bool trueFalse)
        {
            this.Text = text;
            this.TrueFalse = trueFalse;
        }
    }
}
