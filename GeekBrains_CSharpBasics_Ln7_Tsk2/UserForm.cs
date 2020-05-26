using GeekBrains_CSharpBasics_Ln7_Tsk2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GeekBrains_CSharpBasics_Ln7_Tsk2
{
    public partial class UserForm : Form
    {
        GameLogic gameDataLink;
        public UserForm()
        {
            InitializeComponent();
        }
        public void GetLinkToGameData(GameLogic link)
        {
            gameDataLink = link;
            gameDataLink.updateUI += UpdateUI;
            UpdateUI();
        }
        public void UpdateUI() => tbHelp.Text = gameDataLink.UserHelpText;
        private void btnAnswer_Click(object sender, EventArgs e)
        {
            int.TryParse(tbUserInput.Text, out int userInput);
            gameDataLink.CheckAnswer(userInput);
        }
    }
}
