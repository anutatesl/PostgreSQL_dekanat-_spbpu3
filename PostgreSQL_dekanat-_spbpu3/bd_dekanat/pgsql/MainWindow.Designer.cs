namespace pgsql
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemJournal = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDirs = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDir1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDir2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDir3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemReports = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemReport1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemReport2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemReport3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemReport4 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemMenu,
            this.ToolStripMenuItemJournal,
            this.ToolStripMenuItemDirs,
            this.ToolStripMenuItemReports});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1683, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemMenu
            // 
            this.ToolStripMenuItemMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemExit});
            this.ToolStripMenuItemMenu.Name = "ToolStripMenuItemMenu";
            this.ToolStripMenuItemMenu.Size = new System.Drawing.Size(65, 24);
            this.ToolStripMenuItemMenu.Text = "&Меню";
            // 
            // ToolStripMenuItemExit
            // 
            this.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            this.ToolStripMenuItemExit.Size = new System.Drawing.Size(136, 26);
            this.ToolStripMenuItemExit.Text = "&Выход";
            this.ToolStripMenuItemExit.Click += new System.EventHandler(this.ToolStripMenuItemExit_Click);
            // 
            // ToolStripMenuItemJournal
            // 
            this.ToolStripMenuItemJournal.Name = "ToolStripMenuItemJournal";
            this.ToolStripMenuItemJournal.Size = new System.Drawing.Size(77, 24);
            this.ToolStripMenuItemJournal.Text = "&Журнал";
            this.ToolStripMenuItemJournal.Click += new System.EventHandler(this.ToolStripMenuItemJournal_Click);
            // 
            // ToolStripMenuItemDirs
            // 
            this.ToolStripMenuItemDirs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemDir1,
            this.ToolStripMenuItemDir2,
            this.ToolStripMenuItemDir3});
            this.ToolStripMenuItemDirs.Name = "ToolStripMenuItemDirs";
            this.ToolStripMenuItemDirs.Size = new System.Drawing.Size(117, 24);
            this.ToolStripMenuItemDirs.Text = "&Справочники";
            // 
            // ToolStripMenuItemDir1
            // 
            this.ToolStripMenuItemDir1.Name = "ToolStripMenuItemDir1";
            this.ToolStripMenuItemDir1.Size = new System.Drawing.Size(224, 26);
            this.ToolStripMenuItemDir1.Text = "Группы";
            this.ToolStripMenuItemDir1.Click += new System.EventHandler(this.ToolStripMenuItemDir1_Click);
            // 
            // ToolStripMenuItemDir2
            // 
            this.ToolStripMenuItemDir2.Name = "ToolStripMenuItemDir2";
            this.ToolStripMenuItemDir2.Size = new System.Drawing.Size(224, 26);
            this.ToolStripMenuItemDir2.Text = "Люди";
            this.ToolStripMenuItemDir2.Click += new System.EventHandler(this.ToolStripMenuItemDir2_Click);
            // 
            // ToolStripMenuItemDir3
            // 
            this.ToolStripMenuItemDir3.Name = "ToolStripMenuItemDir3";
            this.ToolStripMenuItemDir3.Size = new System.Drawing.Size(224, 26);
            this.ToolStripMenuItemDir3.Text = "Предметы";
            this.ToolStripMenuItemDir3.Click += new System.EventHandler(this.ToolStripMenuItemDir3_Click);
            // 
            // ToolStripMenuItemReports
            // 
            this.ToolStripMenuItemReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemReport1,
            this.ToolStripMenuItemReport3,
            this.ToolStripMenuItemReport4,
            this.ToolStripMenuItemReport2});
            this.ToolStripMenuItemReports.Name = "ToolStripMenuItemReports";
            this.ToolStripMenuItemReports.Size = new System.Drawing.Size(73, 24);
            this.ToolStripMenuItemReports.Text = "&Отчеты";
            this.ToolStripMenuItemReports.Click += new System.EventHandler(this.ToolStripMenuItemReports_Click);
            // 
            // ToolStripMenuItemReport1
            // 
            this.ToolStripMenuItemReport1.Name = "ToolStripMenuItemReport1";
            this.ToolStripMenuItemReport1.Size = new System.Drawing.Size(431, 26);
            this.ToolStripMenuItemReport1.Text = "Отчет: Средний балл по студентам";
            this.ToolStripMenuItemReport1.Click += new System.EventHandler(this.ToolStripMenuItemReport1_Click);
            // 
            // ToolStripMenuItemReport3
            // 
            this.ToolStripMenuItemReport3.Name = "ToolStripMenuItemReport3";
            this.ToolStripMenuItemReport3.Size = new System.Drawing.Size(431, 26);
            this.ToolStripMenuItemReport3.Text = "Отчет: Средний балл по группам";
            this.ToolStripMenuItemReport3.Click += new System.EventHandler(this.ToolStripMenuItemReport3_Click);
            // 
            // ToolStripMenuItemReport4
            // 
            this.ToolStripMenuItemReport4.Name = "ToolStripMenuItemReport4";
            this.ToolStripMenuItemReport4.Size = new System.Drawing.Size(431, 26);
            this.ToolStripMenuItemReport4.Text = "Отчет: Средний балл по преподавателям";
            this.ToolStripMenuItemReport4.Click += new System.EventHandler(this.ToolStripMenuItemReport4_Click);
            // 
            // ToolStripMenuItemReport2
            // 
            this.ToolStripMenuItemReport2.Name = "ToolStripMenuItemReport2";
            this.ToolStripMenuItemReport2.Size = new System.Drawing.Size(431, 26);
            this.ToolStripMenuItemReport2.Text = "Отчет: Средний балл по предметам ";
            this.ToolStripMenuItemReport2.Click += new System.EventHandler(this.ToolStripMenuItemReport2_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1683, 692);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Деканат";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemMenu;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemJournal;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDirs;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDir1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDir2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDir3;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemReports;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemReport1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemReport2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemReport3;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemReport4;
    }
}