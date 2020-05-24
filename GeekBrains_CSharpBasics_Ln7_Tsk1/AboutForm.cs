using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeekBrains_CSharpBasics_Ln7_Tsk1
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            //Setup();
        }
        void Setup()
        {
            lblGameName.Text = "The Doubler Game";
            tbInfo.Text = string.Concat(
                "In this mini - game, the user is invited to get a value ",
                "with help of the minimum number of commands.",
                Environment.NewLine,
                "A value is generated in a pseudo-random manner.",
                Environment.NewLine,
                "The game was completed as part of the task of lesson 7 of the C# basics.",
                Environment.NewLine,
                "Author - Remizov Pavel");
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
