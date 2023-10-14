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
    public partial class AddPeopleWindow : Form
    {
        PgsqlProcedure sql = new PgsqlProcedure();
        int id = -1;
        bool change = false;

        public AddPeopleWindow()
        {
            InitializeComponent();

            DataTable dtName = sql.getListGroup();
            cbGroups.DataSource = dtName;
            cbGroups.ValueMember = "id";
            cbGroups.DisplayMember = "name";

        }


        public AddPeopleWindow(DataRow row)
        {
            InitializeComponent();

            DataTable dtName = sql.getListGroup();
            cbGroups.DataSource = dtName;
            cbGroups.ValueMember = "id";
            cbGroups.DisplayMember = "name";

            setInfo(row);
            change = false;


        }
      
        private void setInfo(DataRow row)
        {
            id = (int)row["id"];
            tbName.Text = row["last_name"].ToString();
            tbLastName.Text = row["first_name"].ToString();
            tbPatherName.Text = row["pather_name"].ToString();
            cbGroups.Text = row["name"].ToString();
            tbType.Text = row["type"].ToString();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
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
            //добавляю человека
           sql.setPeople(id, tbName.Text, tbLastName.Text, tbPatherName.Text, Convert.ToInt32(cbGroups.SelectedValue), Convert.ToChar(tbType.Text));
        }

        private void changeSave(object sender, EventArgs e)
        {
            change = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            change = true;
        }

        private void labelDepart_Click(object sender, EventArgs e)
        {

        }
    }
}
