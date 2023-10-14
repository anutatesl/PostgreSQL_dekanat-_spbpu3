﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pgsql
{
    public partial class EditGroupWindow : Form
    {
        PgsqlProcedure sql = new PgsqlProcedure();
        int id = -1;
        bool change = false;

        public EditGroupWindow()
        {
            InitializeComponent();
        }

        public EditGroupWindow(DataRow row)
        {
            InitializeComponent();

            this.Text = "Редактирование группы";

            setInfo(row);
            change = false;
        }

        private void setInfo(DataRow row)
        {
            id = (int)row["id"];
            tbName.Text = row["name"].ToString();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            // сохранить группу
            if (change)
            {
                save();
            }
            else if (MessageBox.Show("Нет изменений.\nЗакрыть?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            this.Close();
        }

        private void save()
        {
            if (tbName.Text != "")
            {
                // сохранить группу
                sql.setNameGroup(id, tbName.Text);
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void changeSave(object sender, EventArgs e)
        {
            change = true;
        }

        private void lName_Click(object sender, EventArgs e)
        {

        }
    }
}
