using System;
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
    public partial class AddSubjectWindow : Form
    {
        PgsqlProcedure sql = new PgsqlProcedure();
        int id = -1;
        bool change = false;

        public AddSubjectWindow()
        {
            InitializeComponent();
        }

        private void setInfo(DataRow row)
        {
            id = (int)row["id"];
            tbName.Text = row["name"].ToString();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            // сохранить предмет

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
                sql.setNameSubject(id, tbName.Text);
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

    }
}
