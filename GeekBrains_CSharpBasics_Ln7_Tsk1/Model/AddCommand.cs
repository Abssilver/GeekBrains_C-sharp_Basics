using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeekBrains_CSharpBasics_Ln7_Tsk1.Model
{
    [Serializable]
    public class AddCommand : ICommand
    {
        int previousValue;
        GameLogic gameData;
        public AddCommand(GameLogic gameData)
        {
            this.gameData = gameData;
        }
        public void Execute() => previousValue = gameData.CurrentValue++;

        public void Undo() => gameData.CurrentValue = previousValue;
    }
}
