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
    public partial class AddMarksWindow : Form
    {
        PgsqlProcedure sql = new PgsqlProcedure();
        int id = -1;
        bool change = false;


        public AddMarksWindow()
        {
           
            InitializeComponent();
           

            DataTable dtName = sql.getStudent();
            cbName.DataSource = dtName;
            cbName.ValueMember = "id";
            cbName.DisplayMember = "first_name" + "last_name" + "pather_name";

            dtName = sql.getSubject();
            cbSub.DataSource = dtName;
            cbSub.ValueMember = "id";
            cbSub.DisplayMember = "name";

            dtName = sql.getTeacher();
            cbTeacher.DataSource = dtName;
            cbTeacher.ValueMember = "id";
            cbTeacher.DisplayMember = "first_name, last_name , pather_name";
        }

        public AddMarksWindow(DataRow row)
        {
            InitializeComponent();

            DataTable dtName = sql.getStudent();
            cbName.DataSource = dtName;
            cbName.ValueMember = "id";
            cbName.DisplayMember = "first_name" + "last_name" + "pather_name";

            dtName = sql.getSubject();
            cbSub.DataSource = dtName;
            cbSub.ValueMember = "id";
            cbSub.DisplayMember = "name";

            dtName = sql.getTeacher();
            cbTeacher.DataSource = dtName;
            cbTeacher.ValueMember = "id";
            cbTeacher.DisplayMember = "first_name, last_name , pather_name";

            setInfo(row);
            change = false;

        }
        private void setInfo(DataRow row)
        {
            id = (int)row["id"];
            cbName.Text = row["first_name"+"last_name"+"pather_name"].ToString();
            cbSub.Text = row["name"].ToString();
            cbTeacher.Text = row["first_name" + "last_name" + "pather_name"].ToString();
            tbValue.Text = row["value"].ToString();
        }


        private void save()
        {
            //добавляю оценку
            sql.setMark(id, Convert.ToInt32(cbName.SelectedValue), Convert.ToInt32(cbSub.SelectedValue), Convert.ToInt32(cbTeacher.SelectedValue), Convert.ToInt32(tbValue.Text));
        }

        private void BSave_Click_1(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbValue.Text) >= 2 && Convert.ToInt32(tbValue.Text) <= 5)
            {
                if (change)
                {
                    save();
                }
                else if (MessageBox.Show("Нет изменений.\nЗакрыть?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            } else
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

        private void CbName_SelectedIndexChanged(object sender, EventArgs e)
        {
          // string da = new da("SELECT concat(first_name, ' ', last_name, ' ', pather_name) as 'full_name' from people", cn);
        }
    }
}
