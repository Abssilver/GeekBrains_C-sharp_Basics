using GeekBrains_CSharpBasics_Ln8_Tsk5.Model;
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

namespace GeekBrains_CSharpBasics_Ln8_Tsk5
{
    public partial class MainForm : Form
    {
        ConverterLogic converter;
        public MainForm()
        {
            InitializeComponent();
            tbFilePath.Text = string.Empty;
            tbComplete.Text = string.Empty;
        }
        private void btnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "CSV files|*.CSV|All files|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(fileDialog.FileName))
                {
                    converter = new ConverterLogic();
                    converter.LoadData(fileDialog.FileName);
                    tbFilePath.Text = fileDialog.FileName;
                }
            }
            else
                tbFilePath.Text = string.Empty;
        }
        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (converter!=null)
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Filter = "XML files|*.XML|All files|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    converter.Save(fileDialog.FileName);
                    tbComplete.Text = "Convert Completed";
                }
                else
                    tbComplete.Text = string.Empty;
            }
            else
                tbComplete.Text = "Convert Failed";
        }
    }
}
