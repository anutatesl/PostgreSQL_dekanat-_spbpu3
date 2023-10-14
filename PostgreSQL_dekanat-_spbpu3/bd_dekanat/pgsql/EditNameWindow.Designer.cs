namespace pgsql
{
    partial class EditNameWindow
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
            this.lName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFirst_name = new System.Windows.Forms.TextBox();
            this.tbLast_name = new System.Windows.Forms.TextBox();
            this.tbPather_name = new System.Windows.Forms.TextBox();
            this.bSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lName.Location = new System.Drawing.Point(22, 24);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(73, 19);
            this.lName.TabIndex = 2;
            this.lName.Text = "Фамилия";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(22, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(22, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Отчество";
            // 
            // tbFirst_name
            // 
            this.tbFirst_name.Location = new System.Drawing.Point(26, 46);
            this.tbFirst_name.Name = "tbFirst_name";
            this.tbFirst_name.Size = new System.Drawing.Size(251, 20);
            this.tbFirst_name.TabIndex = 5;
            this.tbFirst_name.TextChanged += new System.EventHandler(this.TbFirst_name_TextChanged);
            // 
            // tbLast_name
            // 
            this.tbLast_name.Location = new System.Drawing.Point(26, 102);
            this.tbLast_name.Name = "tbLast_name";
            this.tbLast_name.Size = new System.Drawing.Size(251, 20);
            this.tbLast_name.TabIndex = 6;
            this.tbLast_name.TextChanged += new System.EventHandler(this.TbLast_name_TextChanged);
            // 
            // tbPather_name
            // 
            this.tbPather_name.Location = new System.Drawing.Point(26, 161);
            this.tbPather_name.Name = "tbPather_name";
            this.tbPather_name.Size = new System.Drawing.Size(251, 20);
            this.tbPather_name.TabIndex = 7;
            this.tbPather_name.TextChanged += new System.EventHandler(this.TbPather_name_TextChanged);
            // 
            // bSave
            // 
            this.bSave.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bSave.Location = new System.Drawing.Point(298, 142);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(93, 60);
            this.bSave.TabIndex = 0;
            this.bSave.Text = "Внести";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // EditNameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 214);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.tbPather_name);
            this.Controls.Add(this.tbLast_name);
            this.Controls.Add(this.tbFirst_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lName);
            this.Name = "EditNameWindow";
            this.Text = "Редактирование имени";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFirst_name;
        private System.Windows.Forms.TextBox tbLast_name;
        private System.Windows.Forms.TextBox tbPather_name;
        private System.Windows.Forms.Button bSave;
    }
}