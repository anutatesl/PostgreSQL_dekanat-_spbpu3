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
    public partial class PeopleWindow : Form
    {
        PgsqlProcedure sql = new PgsqlProcedure();
        DataTable dtData;

        public PeopleWindow()
        {
            InitializeComponent();

            enableButton();
            setData();
        }

        private void setData()
        {
            dtData = sql.getPeople(); // загрузка данных
            

            dgvData.DataSource = dtData.DefaultView;
        }

        private void enableButton()
        {
            bool access = false;
            Config.mode = Config.login;
            if (Config.mode == "director")
            {
                access = true;
                bAdd.Enabled = bEdit.Enabled = bDelete.Enabled = access;
                bAdd.Visible = bEdit.Visible = bDelete.Visible = access;
            }
            if (Config.mode == "viewer")
            {
                access = false;
                bAdd.Visible = bEdit.Enabled = bDelete.Enabled = access;
                bAdd.Visible = bEdit.Visible = bDelete.Visible = access;
            }
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            // изменить
            if (dtData != null && dgvData != null && dgvData.RowCount > 0 && dgvData.CurrentRow.Index != -1)
            {
                DataTable dtRows = dtData.DefaultView.ToTable();

                EditNameWindow frm = new EditNameWindow(dtRows.Rows[dgvData.CurrentRow.Index]);
                frm.ShowDialog();

                setData();
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            // удалить
            if (dtData != null && dgvData != null && dgvData.RowCount > 0 && dgvData.CurrentRow.Index != -1)
            {
                DataTable dtRows = dtData.DefaultView.ToTable();
                // проверка людей в таблице оценок 
                DataTable dtR = sql.getPeopleInMarks(Convert.ToInt32(dtRows.Rows[dgvData.CurrentRow.Index]["id"].ToString()));
                DataTable dtR2 = sql.getTeacherInMarks(Convert.ToInt32(dtRows.Rows[dgvData.CurrentRow.Index]["id"].ToString()));          


                string message = "Удалить ";
                message += dtRows.Rows[dgvData.CurrentRow.Index]["first_name"].ToString() + " ";
               

                if (MessageBox.Show(message, "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dtR.Rows.Count > 0 || dtR2.Rows.Count > 0)
                    {
                        MessageBox.Show("Нельзя удалить, строка связанна с другой таблицей", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // удаляю человека
                    sql.delPeople(int.Parse(dtRows.Rows[dgvData.CurrentRow.Index]["id"].ToString()));

                    setData();
                }
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            // добавить людей
            AddPeopleWindow frm = new AddPeopleWindow();
            frm.ShowDialog();

            setData();
        }

        private void DgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
