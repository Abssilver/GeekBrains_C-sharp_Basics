using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeekBrains_CSharpBasics_Ln7_Tsk1.Model
{
    [Serializable]
    public class MultiplyByTwo : ICommand
    {
        int previousValue;
        GameLogic gameData;
        public MultiplyByTwo(GameLogic gameData)
        {
            this.gameData = gameData;
        }
        public void Execute()
        {
            previousValue = gameData.CurrentValue;
            gameData.CurrentValue *= 2;
        }
        public void Undo() => gameData.CurrentValue = previousValue;

    }
}
