using GeekBrains_CSharpBasics_Ln8_Tsk4.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeekBrains_CSharpBasics_Ln8_Tsk4
{
    public partial class PocketForm : Form
    {
        GenericDatabase<Expense> database;
        List<string> categoryCollection = new List<string>();
        string databaseName = string.Empty;
        public PocketForm()
        {
            InitializeComponent();
            categoryCollection.Clear();
            database = new GenericDatabase<Expense>();
            database.ChangeCurrent = new Action(UpdateInfo);
            UpdateInfo();
            tsslStatus.Text = "New database created";
        }
        void UpdateInfo()
        {
            if (database.GetCurrentElement == null)
            {
                tbExpense.Text = "";
                tbPrice.Text = "";
            }
            else
            {
                tbExpense.Text = database.GetCurrentElement.Text;
                tbPrice.Text = 
                    database.GetCurrentElement.Value.ToString("C",
                    CultureInfo.CreateSpecificCulture("en-US"));
            }
            tstbRecordIndex.Text = (database.Current + 1).ToString();
            tsslStatus.Text = string.Empty;
            tbTotal.Text = GetGeneralExpenses();
            UpdateCategoryCollection();
            if (categoryCollection.Count > 0)
                tbCategory.Text = database.GetCurrentElement?.Category;
            else
                tbCategory.Text = string.Empty;
            tbSpentOnCategory.Text = GetTotalCategoryExpenses();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();
        string GetGeneralExpenses()
        {
            if (database == null || database.GetCurrentElement == null)
                return string.Empty;
            decimal generalExpanses = 0;
            for (int i = 0; i < database.Count; i++)
                generalExpanses += database[i].Value;
            return generalExpanses.ToString("C",
                    CultureInfo.CreateSpecificCulture("en-US"));
        }
        string GetTotalCategoryExpenses()
        {
            if (database == null || database.GetCurrentElement == null)
                return string.Empty;
            decimal totalCategory = 0;
            for (int i = 0; i < database.Count; i++)
                if (database[i].Category.Equals(tbCategory.Text))
                totalCategory += database[i].Value;
            return totalCategory.ToString("C",
                    CultureInfo.CreateSpecificCulture("en-US"));
        }
        void UpdateCategoryCollection()
        {
            for (int i = 0; i < database.Count; i++)
                if (!categoryCollection.Contains(database[i].Category))
                    categoryCollection.Add(database[i].Category);
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "XML files|*.XML|All files|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                databaseName = fileDialog.FileName;
                database.Save(databaseName);
                tsslStatus.Text = "Database Saved";
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "XML files|*.XML|All files|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(fileDialog.FileName))
                {
                    database.Load(fileDialog.FileName, out bool loaded);
                    {
                        if (loaded)
                        {
                            categoryCollection.Clear();
                            databaseName = fileDialog.FileName;
                            UpdateInfo();
                            tsslStatus.Text = "Database Loaded";
                        }
                    }
                }
            }
        }
        private void tbsPrevious_Click(object sender, EventArgs e) => database?.Previous();
        private void tsbNext_Click(object sender, EventArgs e) => database?.Next();
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            AddExpense expenseForm = new AddExpense(categoryCollection);
            expenseForm.ShowDialog();
            if (expenseForm.DialogResult == DialogResult.OK)
                database?.Add(expenseForm.Expense);
        }
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            categoryCollection.Clear();
            database = new GenericDatabase<Expense>();
            databaseName = string.Empty;
            database.ChangeCurrent = new Action(UpdateInfo);
            UpdateInfo();
            tsslStatus.Text = "New database created";
        }
        private void tsbRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Trying to remove element...\nAre you sure?",
                "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                database?.Remove();
        }
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (databaseName.Equals(string.Empty))
                saveAsToolStripMenuItem_Click(sender, e);
            else
            {
                database.Save(databaseName);
                tsslStatus.Text = "Database Saved";
            }
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }
        private void copyToolStripButton_Click(object sender, EventArgs e) =>
            Clipboard.SetText(tbExpense.Text);
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (database == null || database.GetCurrentElement == null)
                return;
            AddExpense expenseForm = new AddExpense(categoryCollection);
            expenseForm.Expense = database.GetCurrentElement;
            expenseForm.SetupForEditing();
            expenseForm.ShowDialog();
            if (expenseForm.DialogResult == DialogResult.OK)
            {
                database.Edit(expenseForm.Expense);
                UpdateInfo();
            }
        }
    }
}
