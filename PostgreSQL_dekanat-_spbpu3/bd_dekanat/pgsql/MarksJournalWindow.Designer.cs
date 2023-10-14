namespace pgsql
{
    partial class JournalWindow
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
            this.dataGridViewJournal = new System.Windows.Forms.DataGridView();
            this.buttonAddInJournal = new System.Windows.Forms.Button();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.bEdit = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.first_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.last_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pather_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJournal)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewJournal
            // 
            this.dataGridViewJournal.AllowUserToAddRows = false;
            this.dataGridViewJournal.AllowUserToDeleteRows = false;
            this.dataGridViewJournal.AllowUserToResizeRows = false;
            this.dataGridViewJournal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJournal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.first_name,
            this.last_name,
            this.pather_name,
            this.name_group,
            this.name_subject,
            this.value,
            this.year});
            this.dataGridViewJournal.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewJournal.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewJournal.MultiSelect = false;
            this.dataGridViewJournal.Name = "dataGridViewJournal";
            this.dataGridViewJournal.ReadOnly = true;
            this.dataGridViewJournal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewJournal.Size = new System.Drawing.Size(768, 438);
            this.dataGridViewJournal.TabIndex = 1;
            this.dataGridViewJournal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewJournal_CellContentClick);
            this.dataGridViewJournal.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewJournal_CellMouseDoubleClick);
            // 
            // buttonAddInJournal
            // 
            this.buttonAddInJournal.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddInJournal.Location = new System.Drawing.Point(828, 53);
            this.buttonAddInJournal.Name = "buttonAddInJournal";
            this.buttonAddInJournal.Size = new System.Drawing.Size(254, 49);
            this.buttonAddInJournal.TabIndex = 2;
            this.buttonAddInJournal.Text = "Добавить оценку";
            this.buttonAddInJournal.UseVisualStyleBackColor = true;
            this.buttonAddInJournal.Click += new System.EventHandler(this.buttonAddInJournal_Click);
            // 
            // bw
            // 
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            // 
            // bEdit
            // 
            this.bEdit.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bEdit.Location = new System.Drawing.Point(828, 137);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(254, 46);
            this.bEdit.TabIndex = 18;
            this.bEdit.Text = "Внести изменения";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // bDelete
            // 
            this.bDelete.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bDelete.Location = new System.Drawing.Point(828, 368);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(254, 47);
            this.bDelete.TabIndex = 19;
            this.bDelete.Text = "Удалить оценку";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 5;
            // 
            // first_name
            // 
            this.first_name.DataPropertyName = "first_name";
            this.first_name.HeaderText = "Фамилия";
            this.first_name.Name = "first_name";
            this.first_name.ReadOnly = true;
            // 
            // last_name
            // 
            this.last_name.DataPropertyName = "last_name";
            this.last_name.HeaderText = "Имя";
            this.last_name.Name = "last_name";
            this.last_name.ReadOnly = true;
            // 
            // pather_name
            // 
            this.pather_name.DataPropertyName = "pather_name";
            this.pather_name.HeaderText = "Отчество";
            this.pather_name.Name = "pather_name";
            this.pather_name.ReadOnly = true;
            this.pather_name.Width = 150;
            // 
            // name_group
            // 
            this.name_group.DataPropertyName = "name";
            this.name_group.HeaderText = "Номер группы";
            this.name_group.Name = "name";
            this.name_group.ReadOnly = true;
            this.name_group.Width = 150;
            // 
            // name_subject
            // 
            this.name_subject.DataPropertyName = "name1";
            this.name_subject.HeaderText = "Предмет";
            this.name_subject.Name = "name1";
            this.name_subject.ReadOnly = true;
            // 
            // value
            // 
            this.value.DataPropertyName = "value";
            this.value.HeaderText = "Оценка";
            this.value.Name = "value";
            this.value.ReadOnly = true;
            this.value.Width = 150;
            // 
            // year
            // 
            this.year.DataPropertyName = "year";
            this.year.HeaderText = "Год";
            this.year.Name = "year";
            this.year.ReadOnly = true;
            this.year.Width = 150;
            // 
            // JournalWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 438);
            this.Controls.Add(this.buttonAddInJournal);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.bEdit);
            this.Controls.Add(this.dataGridViewJournal);
            this.Name = "JournalWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Журнал - Оценки";
            this.Load += new System.EventHandler(this.PatientsWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJournal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewJournal;
        private System.Windows.Forms.Button buttonAddInJournal;
        private System.ComponentModel.BackgroundWorker bw;
        private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn first_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn last_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn pather_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_group;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.DataGridViewTextBoxColumn year;
    }
}