using GeekBrains_CSharpBasics_Ln7_Tsk1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeekBrains_CSharpBasics_Ln7_Tsk1
{
    public partial class DoublerGame : Form
    {
        GameLogic gameInstance = null;
        AboutForm about = new AboutForm();
        public DoublerGame()
        {
            InitializeComponent();
        }
        private void btnAddOne_Click(object sender, EventArgs e) => gameInstance.AddOne();
        private void btnDouble_Click(object sender, EventArgs e) => gameInstance.Double();
        private void btnReset_Click(object sender, EventArgs e) => gameInstance.Reset();
        private void btnUndo_Click(object sender, EventArgs e) => gameInstance.Undo();

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }
        void NewGame()
        {
            gameInstance = new GameLogic();
            gameInstance.updateGameInfo += UpdateInfo;
            UpdateInfo();
            EnableControls();
        }
        void EnableControls()
        {
            btnAddOne.Enabled = true;
            btnDouble.Enabled = true;
            btnReset.Enabled = true;
            btnUndo.Enabled = true;
        }
        void UpdateInfo()
        {
            lblCurrentValue.Text = gameInstance.CurrentValue.ToString();
            lblGoalValue.Text = gameInstance.Goal.ToString();
            lblMaxActionsValue.Text = gameInstance.MaxSteps.ToString();
            lblNumberOfActionsValue.Text = gameInstance.Steps.ToString();
            lblGameStatus.Text = gameInstance.Status.ToString();
            if (gameInstance.Status != GameStatus.InProcess)
            {
                btnAddOne.Enabled = !btnAddOne.Enabled;
                btnDouble.Enabled = !btnDouble.Enabled;
                ShowDialogueWindow();
            }
            else if (!btnAddOne.Enabled && !btnDouble.Enabled)
            {
                btnAddOne.Enabled = !btnAddOne.Enabled;
                btnDouble.Enabled = !btnDouble.Enabled;
            }
        }
        void ShowDialogueWindow()
        {
            string message = gameInstance.Status == GameStatus.Win ? "You Won!" : "You Lost!";
            if (MessageBox.Show
                    (string.Concat(message, Environment.NewLine, "Would you like to restart?"),
                    "Results", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    NewGame();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) => 
            about.ShowDialog();

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) => 
            gameInstance?.SaveData();

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameLogic newInstance = GameLogic.LoadData();
            if (newInstance != null)
            {
                gameInstance = newInstance;
                gameInstance.updateGameInfo += gameInstance.CheckForWin;
                gameInstance.updateGameInfo += UpdateInfo;
                EnableControls();
                UpdateInfo();
            }
        }
    }
}
