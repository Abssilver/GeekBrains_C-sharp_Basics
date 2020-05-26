using GeekBrains_CSharpBasics_Ln8_Tsk3.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeekBrains_CSharpBasics_Ln8_Tsk3
{
    public partial class DatabaseForm : Form
    {
        Timer timer = new Timer();
        Database database;
        string databaseName = string.Empty;
        public DatabaseForm()
        {
            InitializeComponent();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            database = new Database();
            database.ChangeCurrent = new Action(UpdateInfo); 
        }
        void UpdateInfo()
        {
            if (database.GetCurrentQuestion == null)
            {
                tbQuestionText.Text = "";
                cbTrueFalse.Checked = false;
            }
            else
            {
                tbQuestionText.Text = database.GetCurrentQuestion.Text;
                cbTrueFalse.Checked = database.GetCurrentQuestion.TrueFalse;
            }
            tstbCurrentQuestionIndex.Text = (database.Current + 1).ToString();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            tsslCurrentTime.Text = DateTime.Now.ToLongTimeString();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "XML files|*.XML|All files|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                databaseName = fileDialog.FileName;
                database.Save(databaseName);
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
                            databaseName = fileDialog.FileName;
                            UpdateInfo();
                        }
                    }
                }
            }
        }
        private void tbsPrevious_Click(object sender, EventArgs e) => database?.Previous();
        private void tsbNext_Click(object sender, EventArgs e) => database?.Next();


        private void tsbAdd_Click(object sender, EventArgs e)
        {
            AddQuestionForm questionForm = new AddQuestionForm();
            questionForm.ShowDialog();
            if (questionForm.DialogResult == DialogResult.OK)
            {
                //if (database == null)
                //{
                //    if (MessageBox.Show
                //        ("There is no database yet!\nDo you want to create one?",
                //        "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    {
                //        database = new Database();
                        database?.Add(questionForm.Question);
                  //  }
                //}
            }
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            database = new Database();
            databaseName = string.Empty;
            database.ChangeCurrent = new Action(UpdateInfo);
            UpdateInfo();
        }

        private void tsbRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Trying to remove element...\nAre you sure?",
                "Warning", MessageBoxButtons.YesNo)==DialogResult.Yes)
                database?.Remove();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (databaseName.Equals(string.Empty))
                saveAsToolStripMenuItem_Click(sender, e);
            else
            {
                database.Save(databaseName);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e) =>
            Clipboard.SetText(tbQuestionText.Text);

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (database == null || database.GetCurrentQuestion == null)
                return;
            AddQuestionForm questionForm = new AddQuestionForm();
            questionForm.Question = database.GetCurrentQuestion;
            questionForm.SetupForEditing();
            questionForm.ShowDialog();
            if (questionForm.DialogResult == DialogResult.OK)
            {
                database.Edit(questionForm.Question);
                UpdateInfo();
            }
        }
    }
}
