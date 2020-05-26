namespace GeekBrains_CSharpBasics_Ln7_Tsk2
{
    partial class UserForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            this.tbUserInput = new System.Windows.Forms.TextBox();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.tbHelp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbUserInput
            // 
            this.tbUserInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbUserInput.Location = new System.Drawing.Point(12, 100);
            this.tbUserInput.Name = "tbUserInput";
            this.tbUserInput.Size = new System.Drawing.Size(360, 45);
            this.tbUserInput.TabIndex = 0;
            // 
            // btnAnswer
            // 
            this.btnAnswer.Location = new System.Drawing.Point(378, 100);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(131, 45);
            this.btnAnswer.TabIndex = 1;
            this.btnAnswer.Text = "Answer";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // tbHelp
            // 
            this.tbHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbHelp.Location = new System.Drawing.Point(12, 12);
            this.tbHelp.Multiline = true;
            this.tbHelp.Name = "tbHelp";
            this.tbHelp.ReadOnly = true;
            this.tbHelp.Size = new System.Drawing.Size(497, 82);
            this.tbHelp.TabIndex = 2;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 160);
            this.Controls.Add(this.tbHelp);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.tbUserInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserForm";
            this.Text = "PlayerTablet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUserInput;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.TextBox tbHelp;
    }
}

