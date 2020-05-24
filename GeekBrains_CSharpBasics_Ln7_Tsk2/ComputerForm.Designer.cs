namespace GeekBrains_CSharpBasics_Ln7_Tsk2
{
    partial class ComputerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComputerForm));
            this.lblGameName = new System.Windows.Forms.Label();
            this.tbRiddleText = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGameName
            // 
            this.lblGameName.AutoSize = true;
            this.lblGameName.Location = new System.Drawing.Point(100, 20);
            this.lblGameName.Name = "lblGameName";
            this.lblGameName.Size = new System.Drawing.Size(155, 17);
            this.lblGameName.TabIndex = 0;
            this.lblGameName.Text = "The Pirate\'s Joe Riddle";
            // 
            // tbRiddleText
            // 
            this.tbRiddleText.Location = new System.Drawing.Point(12, 58);
            this.tbRiddleText.Multiline = true;
            this.tbRiddleText.Name = "tbRiddleText";
            this.tbRiddleText.ReadOnly = true;
            this.tbRiddleText.Size = new System.Drawing.Size(358, 118);
            this.tbRiddleText.TabIndex = 3;
            this.tbRiddleText.Text = "Old pirate Joe made a number from 1 to 100.";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(285, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(84, 31);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Got It!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // ComputerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 189);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tbRiddleText);
            this.Controls.Add(this.lblGameName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ComputerForm";
            this.Text = "Pirate\'s Joe Tablet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGameName;
        private System.Windows.Forms.TextBox tbRiddleText;
        private System.Windows.Forms.Button btnStart;
    }
}