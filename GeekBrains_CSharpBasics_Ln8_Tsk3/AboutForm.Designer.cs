namespace GeekBrains_CSharpBasics_Ln8_Tsk3
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.btnBack = new System.Windows.Forms.Button();
            this.tbAbout = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(168, 104);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tbAbout
            // 
            this.tbAbout.Enabled = false;
            this.tbAbout.Location = new System.Drawing.Point(12, 12);
            this.tbAbout.Multiline = true;
            this.tbAbout.Name = "tbAbout";
            this.tbAbout.Size = new System.Drawing.Size(385, 86);
            this.tbAbout.TabIndex = 1;
            this.tbAbout.Text = "This application was completed as a part of the homework\r\n for the final lesson o" +
    "f the C # basics course.\r\nAuthor: Remizov Pavel\r\nv 0.01a";
            this.tbAbout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 135);
            this.Controls.Add(this.tbAbout);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AboutForm";
            this.Text = "AboutForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox tbAbout;
    }
}