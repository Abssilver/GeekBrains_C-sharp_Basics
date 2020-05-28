using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeekBrains_CSharpBasics_Ln8_Tsk4
{
    public partial class NewCategory : Form
    {
        public string Category { get; set; } = string.Empty;
        public NewCategory()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbNewCategory.Text.Equals(string.Empty))
            {
                MessageBox.Show("The category text is not set.", "Warning");
                return;
            }
            Category = tbNewCategory.Text.ToLower();
            this.DialogResult = DialogResult.OK;
        }
    }
}
