using GeekBrains_CSharpBasics_Ln8_Tsk4.Model;
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
    public partial class AddExpense : Form
    {
        public Expense Expense { get; set; } = new Expense();
        public List<string> CategoryCollection { get; private set; }
        public AddExpense()
        {
            InitializeComponent();
        }
        public AddExpense(List<string> categoryCollection)
        {
            InitializeComponent();
            CategoryCollection = categoryCollection;
            if (CategoryCollection != null && CategoryCollection.Count > 0)
            {
                foreach (var category in CategoryCollection)
                    cbCategory.Items.Add(category);
            }
        }
        public void SetupForEditing()
        {
            tbDescription.Text = Expense.Text;
            nudDollars.Value = (int)Expense.Value;
            nudCents.Value = (Expense.Value - nudDollars.Value) * 100;
            cbCategory.SelectedIndex = CategoryCollection.IndexOf(Expense.Category);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbDescription.Text.Equals(string.Empty))
            {
                if (MessageBox.Show("A description text is not set.\nDo you want to continue?", 
                    "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }
            if (cbCategory.SelectedItem == null)
            {
                MessageBox.Show("The category is not set.", "Warning");
                return;
            }
            this.DialogResult = DialogResult.OK;
            Expense.Text = tbDescription.Text;
            Expense.Value = nudDollars.Value + nudCents.Value * 0.01m;
            Expense.Category = cbCategory.SelectedItem?.ToString();
        }
        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        private void btnNewCategory_Click(object sender, EventArgs e)
        {
            NewCategory newCategory = new NewCategory();
            newCategory.ShowDialog();
            if (newCategory.DialogResult == DialogResult.OK &&
                !CategoryCollection.Contains(newCategory.Category))
            {
                CategoryCollection.Add(newCategory.Category);
                cbCategory.Items.Add(newCategory.Category);
                cbCategory.SelectedIndex = CategoryCollection.IndexOf(newCategory.Category);
            }
        }
    }
}