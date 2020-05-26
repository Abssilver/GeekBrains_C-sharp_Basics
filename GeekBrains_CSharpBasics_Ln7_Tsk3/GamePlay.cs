using GeekBrains_CSharpBasics_Ln7_Tsk3.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeekBrains_CSharpBasics_Ln7_Tsk3
{
    public partial class GamePlay : Form
    {
        GameLogic gameData;
        int numberOfEnemies = 3;
        HelpForm helpForm = new HelpForm();
        public GamePlay()
        {
            InitializeComponent();
            NewGame(numberOfEnemies);
        }
        void NewGame(int numberOfEnemies)
        {
            panelField.Controls.Clear();
            gameData = new GameLogic(panelField, numberOfEnemies);
            gameData.turnIsDone += CheckForWin;
        }
        void CheckForWin()
        {
            if (gameData.Status != GameStatus.InProcess)
            {
                if (MessageBox.Show
                    ($"You {gameData.Status}!\nWould you like to start a new game?",
                    "Results", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    NewGame(numberOfEnemies);
                }
                else this.Close();
                
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helpForm.ShowDialog();
        }
    }
}
