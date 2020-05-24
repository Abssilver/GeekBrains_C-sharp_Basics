using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekBrains_CSharpBasics_Ln7_Tsk1.Model
{
    interface ICommand
    {
        void Execute();
        void Undo();
    }
}
