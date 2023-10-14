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
    public partial class EditMarksWindow : Form
    {
        PgsqlProcedure sql = new PgsqlProcedure();
        int id = -1;
        bool change = false;

        public EditMarksWindow()
        {
            InitializeComponent();
        }

        public EditMarksWindow(DataRow row)
        {
            InitializeComponent();

            this.Text = "Редактирование оценки";

            setInfo(row);
            change = false;
        }

        private void setInfo(DataRow row)
        {
            id = (int)row["id"];
            tbValue.Text = row["value"].ToString();
        }



        private void BSave_Click(object sender, EventArgs e)
        {
            // сохранить оценку
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
            if (Convert.ToInt32(tbValue.Text) >= 2 && Convert.ToInt32(tbValue.Text) <= 5)
            {
                if (tbValue.Text != "")
                {
                    // сохранить оценку
                    sql.setMark(id, Convert.ToInt32(tbValue.Text));
                }
                else
                {
                    MessageBox.Show("Заполните все поля", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Неверная оценка", "Оценка ставится от 2 до 5", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Close();
        }

        private void TbValue_TextChanged(object sender, EventArgs e)
        {
            change = true;
        }
    }
}
