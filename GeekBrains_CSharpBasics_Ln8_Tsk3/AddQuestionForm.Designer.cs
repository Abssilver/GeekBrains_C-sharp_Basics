namespace GeekBrains_CSharpBasics_Ln8_Tsk3
{
    partial class AddQuestionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddQuestionForm));
            this.lblQuestion = new System.Windows.Forms.Label();
            this.tbQuestion = new System.Windows.Forms.TextBox();
            this.cbTrueFalse = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(13, 13);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(65, 17);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Question";
            // 
            // tbQuestion
            // 
            this.tbQuestion.Location = new System.Drawing.Point(12, 33);
            this.tbQuestion.Multiline = true;
            this.tbQuestion.Name = "tbQuestion";
            this.tbQuestion.Size = new System.Drawing.Size(632, 107);
            this.tbQuestion.TabIndex = 1;
            // 
            // cbTrueFalse
            // 
            this.cbTrueFalse.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbTrueFalse.AutoSize = true;
            this.cbTrueFalse.Location = new System.Drawing.Point(596, 146);
            this.cbTrueFalse.Name = "cbTrueFalse";
            this.cbTrueFalse.Size = new System.Drawing.Size(48, 27);
            this.cbTrueFalse.TabIndex = 2;
            this.cbTrueFalse.Text = "True";
            this.cbTrueFalse.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(343, 146);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 27);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(439, 146);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddQuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 181);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbTrueFalse);
            this.Controls.Add(this.tbQuestion);
            this.Controls.Add(this.lblQuestion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddQuestionForm";
            this.Text = "AddQuestionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.TextBox tbQuestion;
        private System.Windows.Forms.CheckBox cbTrueFalse;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}