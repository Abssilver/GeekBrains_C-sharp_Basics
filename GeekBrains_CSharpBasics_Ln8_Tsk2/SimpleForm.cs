using GeekBrains_CSharpBasics_Ln8_Tsk2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeekBrains_CSharpBasics_Ln8_Tsk2
{
    public partial class SimpleForm : Form
    {
        Data messageData = new Data();
        public SimpleForm()
        {
            InitializeComponent();
            textBoxMessage.Text = 
                messageData.Display((int)numericUpDown.Value) ?? string.Empty;
        }
        private void numericUpDown_ValueChanged(object sender, EventArgs e) =>
            textBoxMessage.Text =
                messageData.Display((int)numericUpDown.Value) ?? string.Empty;

        private void btnEdit_Click(object sender, EventArgs e) =>
            messageData.Edit(textBoxMessage.Text, (int)numericUpDown.Value);
    }
}
