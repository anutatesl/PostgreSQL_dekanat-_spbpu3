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
    public partial class EditNameWindow : Form
    {
        PgsqlProcedure sql = new PgsqlProcedure();
        int id = -1;
        bool change = false;

        public EditNameWindow()
        {
            InitializeComponent();
        }

        public EditNameWindow(DataRow row)
        {
            InitializeComponent();

            this.Text = "Редактирование человека";

            setInfo(row);
            change = false;
        }

        private void setInfo(DataRow row)
        {
            id = (int)row["id"];
            tbFirst_name.Text = row["first_name"].ToString();
            tbLast_name.Text = row["last_name"].ToString();
            tbPather_name.Text = row["pather_name"].ToString();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            // сохранить человека
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
            if ((tbFirst_name.Text != "") && (tbLast_name.Text != "") && (tbPather_name.Text != ""))
            {
                // сохранить человека
                sql.setNamePeople(id, tbFirst_name.Text, tbLast_name.Text, tbPather_name.Text);
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        private void TbFirst_name_TextChanged(object sender, EventArgs e)
        {
            change = true;
        }

        private void TbLast_name_TextChanged(object sender, EventArgs e)
        {
            change = true;
        }

        private void TbPather_name_TextChanged(object sender, EventArgs e)
        {
            change = true;
        }
    }
}
