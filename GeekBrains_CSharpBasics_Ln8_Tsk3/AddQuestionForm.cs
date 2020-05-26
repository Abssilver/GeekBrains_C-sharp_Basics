using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeekBrains_CSharpBasics_Ln8_Tsk3.Model;

namespace GeekBrains_CSharpBasics_Ln8_Tsk3
{
    public partial class AddQuestionForm : Form
    {
        public Question Question { get; set; } = new Question();
        public AddQuestionForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbQuestion.Text.Equals(string.Empty))
            {
                if (MessageBox.Show("A question text is not set.\nDo you want to continue?", "Warning",
                    MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }
            this.DialogResult = DialogResult.OK;
            Question.Text = tbQuestion.Text;
            Question.TrueFalse = cbTrueFalse.Checked;
        }
        public void SetupForEditing()
        {
            tbQuestion.Text = Question.Text;
            cbTrueFalse.Checked = Question.TrueFalse;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
