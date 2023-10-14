namespace pgsql
{
    partial class EditMarksWindow
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
            this.labelName = new System.Windows.Forms.Label();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.bSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(48, 22);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(45, 13);
            this.labelName.TabIndex = 15;
            this.labelName.Text = "Оценка";
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(51, 54);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(52, 20);
            this.tbValue.TabIndex = 21;
            this.tbValue.TextChanged += new System.EventHandler(this.TbValue_TextChanged);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(130, 54);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 22;
            this.bSave.Text = "Сохранить";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.BSave_Click);
            // 
            // EditMarksWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 111);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.labelName);
            this.Name = "EditMarksWindow";
            this.Text = "Изменение оценки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.Button bSave;
    }
}