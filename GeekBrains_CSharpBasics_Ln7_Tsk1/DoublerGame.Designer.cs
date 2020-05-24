namespace GeekBrains_CSharpBasics_Ln7_Tsk1
{
    partial class DoublerGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoublerGame));
            this.lblCurrentValue = new System.Windows.Forms.Label();
            this.btnAddOne = new System.Windows.Forms.Button();
            this.btnDouble = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblNumberOfActionsText = new System.Windows.Forms.Label();
            this.lblNumberOfActionsValue = new System.Windows.Forms.Label();
            this.lblCurrentValueText = new System.Windows.Forms.Label();
            this.lblGoalText = new System.Windows.Forms.Label();
            this.lblGoalValue = new System.Windows.Forms.Label();
            this.lblMaxActionsText = new System.Windows.Forms.Label();
            this.lblMaxActionsValue = new System.Windows.Forms.Label();
            this.btnUndo = new System.Windows.Forms.Button();
            this.gbCommands = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbGameInfo = new System.Windows.Forms.GroupBox();
            this.lblGameStatus = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gbGameStatus = new System.Windows.Forms.GroupBox();
            this.gbCommands.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.gbGameInfo.SuspendLayout();
            this.gbGameStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCurrentValue
            // 
            this.lblCurrentValue.AutoSize = true;
            this.lblCurrentValue.Location = new System.Drawing.Point(139, 30);
            this.lblCurrentValue.Name = "lblCurrentValue";
            this.lblCurrentValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCurrentValue.Size = new System.Drawing.Size(16, 17);
            this.lblCurrentValue.TabIndex = 0;
            this.lblCurrentValue.Text = "1";
            // 
            // btnAddOne
            // 
            this.btnAddOne.Enabled = false;
            this.btnAddOne.Location = new System.Drawing.Point(15, 21);
            this.btnAddOne.Name = "btnAddOne";
            this.btnAddOne.Size = new System.Drawing.Size(121, 41);
            this.btnAddOne.TabIndex = 1;
            this.btnAddOne.Text = "+1";
            this.btnAddOne.UseVisualStyleBackColor = true;
            this.btnAddOne.Click += new System.EventHandler(this.btnAddOne_Click);
            // 
            // btnDouble
            // 
            this.btnDouble.Enabled = false;
            this.btnDouble.Location = new System.Drawing.Point(15, 82);
            this.btnDouble.Name = "btnDouble";
            this.btnDouble.Size = new System.Drawing.Size(121, 41);
            this.btnDouble.TabIndex = 2;
            this.btnDouble.Text = "x2";
            this.btnDouble.UseVisualStyleBackColor = true;
            this.btnDouble.Click += new System.EventHandler(this.btnDouble_Click);
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(15, 141);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(121, 41);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblNumberOfActionsText
            // 
            this.lblNumberOfActionsText.AutoSize = true;
            this.lblNumberOfActionsText.Location = new System.Drawing.Point(6, 103);
            this.lblNumberOfActionsText.Name = "lblNumberOfActionsText";
            this.lblNumberOfActionsText.Size = new System.Drawing.Size(127, 17);
            this.lblNumberOfActionsText.TabIndex = 5;
            this.lblNumberOfActionsText.Text = "Number of actions:";
            // 
            // lblNumberOfActionsValue
            // 
            this.lblNumberOfActionsValue.AutoSize = true;
            this.lblNumberOfActionsValue.Location = new System.Drawing.Point(139, 103);
            this.lblNumberOfActionsValue.Name = "lblNumberOfActionsValue";
            this.lblNumberOfActionsValue.Size = new System.Drawing.Size(16, 17);
            this.lblNumberOfActionsValue.TabIndex = 6;
            this.lblNumberOfActionsValue.Text = "0";
            // 
            // lblCurrentValueText
            // 
            this.lblCurrentValueText.AutoSize = true;
            this.lblCurrentValueText.Location = new System.Drawing.Point(6, 31);
            this.lblCurrentValueText.Name = "lblCurrentValueText";
            this.lblCurrentValueText.Size = new System.Drawing.Size(99, 17);
            this.lblCurrentValueText.TabIndex = 7;
            this.lblCurrentValueText.Text = "Current Value:";
            // 
            // lblGoalText
            // 
            this.lblGoalText.AutoSize = true;
            this.lblGoalText.Location = new System.Drawing.Point(6, 66);
            this.lblGoalText.Name = "lblGoalText";
            this.lblGoalText.Size = new System.Drawing.Size(42, 17);
            this.lblGoalText.TabIndex = 8;
            this.lblGoalText.Text = "Goal:";
            // 
            // lblGoalValue
            // 
            this.lblGoalValue.AutoSize = true;
            this.lblGoalValue.Location = new System.Drawing.Point(139, 66);
            this.lblGoalValue.Name = "lblGoalValue";
            this.lblGoalValue.Size = new System.Drawing.Size(16, 17);
            this.lblGoalValue.TabIndex = 9;
            this.lblGoalValue.Text = "0";
            // 
            // lblMaxActionsText
            // 
            this.lblMaxActionsText.AutoSize = true;
            this.lblMaxActionsText.Location = new System.Drawing.Point(6, 138);
            this.lblMaxActionsText.Name = "lblMaxActionsText";
            this.lblMaxActionsText.Size = new System.Drawing.Size(87, 17);
            this.lblMaxActionsText.TabIndex = 10;
            this.lblMaxActionsText.Text = "Max Actions:";
            // 
            // lblMaxActionsValue
            // 
            this.lblMaxActionsValue.AutoSize = true;
            this.lblMaxActionsValue.Location = new System.Drawing.Point(139, 138);
            this.lblMaxActionsValue.Name = "lblMaxActionsValue";
            this.lblMaxActionsValue.Size = new System.Drawing.Size(16, 17);
            this.lblMaxActionsValue.TabIndex = 11;
            this.lblMaxActionsValue.Text = "0";
            // 
            // btnUndo
            // 
            this.btnUndo.Enabled = false;
            this.btnUndo.Location = new System.Drawing.Point(15, 201);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(121, 41);
            this.btnUndo.TabIndex = 12;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // gbCommands
            // 
            this.gbCommands.Controls.Add(this.btnAddOne);
            this.gbCommands.Controls.Add(this.btnUndo);
            this.gbCommands.Controls.Add(this.btnDouble);
            this.gbCommands.Controls.Add(this.btnReset);
            this.gbCommands.Location = new System.Drawing.Point(12, 31);
            this.gbCommands.Name = "gbCommands";
            this.gbCommands.Size = new System.Drawing.Size(151, 251);
            this.gbCommands.TabIndex = 13;
            this.gbCommands.TabStop = false;
            this.gbCommands.Text = "Commands";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(373, 28);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.toolStripMenuItem1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.fileToolStripMenuItem.Text = "Game";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(122, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // gbGameInfo
            // 
            this.gbGameInfo.Controls.Add(this.lblMaxActionsValue);
            this.gbGameInfo.Controls.Add(this.lblGoalValue);
            this.gbGameInfo.Controls.Add(this.lblGoalText);
            this.gbGameInfo.Controls.Add(this.lblMaxActionsText);
            this.gbGameInfo.Controls.Add(this.lblNumberOfActionsValue);
            this.gbGameInfo.Controls.Add(this.lblCurrentValue);
            this.gbGameInfo.Controls.Add(this.lblNumberOfActionsText);
            this.gbGameInfo.Controls.Add(this.lblCurrentValueText);
            this.gbGameInfo.Location = new System.Drawing.Point(169, 34);
            this.gbGameInfo.Name = "gbGameInfo";
            this.gbGameInfo.Size = new System.Drawing.Size(190, 167);
            this.gbGameInfo.TabIndex = 15;
            this.gbGameInfo.TabStop = false;
            this.gbGameInfo.Text = "Game Info";
            // 
            // lblGameStatus
            // 
            this.lblGameStatus.AutoSize = true;
            this.lblGameStatus.Location = new System.Drawing.Point(23, 37);
            this.lblGameStatus.Name = "lblGameStatus";
            this.lblGameStatus.Size = new System.Drawing.Size(70, 17);
            this.lblGameStatus.TabIndex = 12;
            this.lblGameStatus.Text = "InProcess";
            // 
            // gbGameStatus
            // 
            this.gbGameStatus.Controls.Add(this.lblGameStatus);
            this.gbGameStatus.Location = new System.Drawing.Point(169, 207);
            this.gbGameStatus.Name = "gbGameStatus";
            this.gbGameStatus.Size = new System.Drawing.Size(190, 75);
            this.gbGameStatus.TabIndex = 16;
            this.gbGameStatus.TabStop = false;
            this.gbGameStatus.Text = "Game Status";
            // 
            // DoublerGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 296);
            this.Controls.Add(this.gbGameStatus);
            this.Controls.Add(this.gbGameInfo);
            this.Controls.Add(this.gbCommands);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "DoublerGame";
            this.Text = "Doubler";
            this.gbCommands.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbGameInfo.ResumeLayout(false);
            this.gbGameInfo.PerformLayout();
            this.gbGameStatus.ResumeLayout(false);
            this.gbGameStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentValue;
        private System.Windows.Forms.Button btnAddOne;
        private System.Windows.Forms.Button btnDouble;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblNumberOfActionsText;
        private System.Windows.Forms.Label lblNumberOfActionsValue;
        private System.Windows.Forms.Label lblCurrentValueText;
        private System.Windows.Forms.Label lblGoalText;
        private System.Windows.Forms.Label lblGoalValue;
        private System.Windows.Forms.Label lblMaxActionsText;
        private System.Windows.Forms.Label lblMaxActionsValue;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.GroupBox gbCommands;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbGameInfo;
        private System.Windows.Forms.Label lblGameStatus;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox gbGameStatus;
    }
}

