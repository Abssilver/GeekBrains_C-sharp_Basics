namespace GeekBrains_CSharpBasics_Ln8_Tsk4
{
    partial class AddExpense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddExpense));
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lblDollar = new System.Windows.Forms.Label();
            this.nudDollars = new System.Windows.Forms.NumericUpDown();
            this.lblCent = new System.Windows.Forms.Label();
            this.nudCents = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbCostInfo = new System.Windows.Forms.GroupBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.btnNewCategory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudDollars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCents)).BeginInit();
            this.gbCostInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(13, 13);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(79, 17);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(16, 33);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(295, 22);
            this.tbDescription.TabIndex = 1;
            // 
            // lblDollar
            // 
            this.lblDollar.AutoSize = true;
            this.lblDollar.Location = new System.Drawing.Point(6, 20);
            this.lblDollar.Name = "lblDollar";
            this.lblDollar.Size = new System.Drawing.Size(52, 17);
            this.lblDollar.TabIndex = 2;
            this.lblDollar.Text = "Dollars";
            // 
            // nudDollars
            // 
            this.nudDollars.Location = new System.Drawing.Point(9, 40);
            this.nudDollars.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudDollars.Name = "nudDollars";
            this.nudDollars.Size = new System.Drawing.Size(69, 22);
            this.nudDollars.TabIndex = 3;
            // 
            // lblCent
            // 
            this.lblCent.AutoSize = true;
            this.lblCent.Location = new System.Drawing.Point(90, 18);
            this.lblCent.Name = "lblCent";
            this.lblCent.Size = new System.Drawing.Size(44, 17);
            this.lblCent.TabIndex = 4;
            this.lblCent.Text = "Cents";
            // 
            // nudCents
            // 
            this.nudCents.Location = new System.Drawing.Point(93, 39);
            this.nudCents.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudCents.Name = "nudCents";
            this.nudCents.Size = new System.Drawing.Size(69, 22);
            this.nudCents.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(205, 106);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(106, 33);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(205, 145);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 32);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbCostInfo
            // 
            this.gbCostInfo.Controls.Add(this.lblDollar);
            this.gbCostInfo.Controls.Add(this.nudDollars);
            this.gbCostInfo.Controls.Add(this.lblCent);
            this.gbCostInfo.Controls.Add(this.nudCents);
            this.gbCostInfo.Location = new System.Drawing.Point(12, 106);
            this.gbCostInfo.Name = "gbCostInfo";
            this.gbCostInfo.Size = new System.Drawing.Size(174, 71);
            this.gbCostInfo.TabIndex = 8;
            this.gbCostInfo.TabStop = false;
            this.gbCostInfo.Text = "Price";
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(213, 71);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(98, 24);
            this.cbCategory.TabIndex = 9;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(142, 72);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(65, 17);
            this.lblCategory.TabIndex = 10;
            this.lblCategory.Text = "Category";
            // 
            // btnNewCategory
            // 
            this.btnNewCategory.Location = new System.Drawing.Point(15, 68);
            this.btnNewCategory.Name = "btnNewCategory";
            this.btnNewCategory.Size = new System.Drawing.Size(121, 29);
            this.btnNewCategory.TabIndex = 11;
            this.btnNewCategory.Text = "New Category";
            this.btnNewCategory.UseVisualStyleBackColor = true;
            this.btnNewCategory.Click += new System.EventHandler(this.btnNewCategory_Click);
            // 
            // AddExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 189);
            this.Controls.Add(this.btnNewCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.gbCostInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.lblDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddExpense";
            this.Text = "AddExpense";
            ((System.ComponentModel.ISupportInitialize)(this.nudDollars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCents)).EndInit();
            this.gbCostInfo.ResumeLayout(false);
            this.gbCostInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lblDollar;
        private System.Windows.Forms.NumericUpDown nudDollars;
        private System.Windows.Forms.Label lblCent;
        private System.Windows.Forms.NumericUpDown nudCents;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbCostInfo;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Button btnNewCategory;
    }
}