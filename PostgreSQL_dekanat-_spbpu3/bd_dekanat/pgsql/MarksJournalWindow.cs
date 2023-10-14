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
    public partial class JournalWindow : Form
    {
        PgsqlProcedure sql = new PgsqlProcedure();
        PgsqlProcedure sqlBw = new PgsqlProcedure();
        DataTable dtData;
        

        public JournalWindow()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

         
            enableButton();

            bw.RunWorkerAsync();
        }

        private void setData()
        {
            dtData = sql.getJournal(); // загрузка данных


            dataGridViewJournal.DataSource = dtData.DefaultView;
        }

        private void enableButton()
        {
            bool access = false;
            if (Config.mode == "adm")
            {
                access = true;
                buttonAddInJournal.Visible = bEdit.Visible = bDelete.Visible = access;
            }
            if (Config.mode == "doc")
            {
                access = false;
                buttonAddInJournal.Visible = bEdit.Visible = bDelete.Visible = access;
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            dtData = sqlBw.getJournal(); // Загружаем людей
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridViewJournal.DataSource = dtData;
           
        }

       
        //кнопка добавить
        private void buttonAddInJournal_Click(object sender, EventArgs e)
        {
            AddMarksWindow frm = new AddMarksWindow();
            frm.ShowDialog();

            bw.RunWorkerAsync();
        }

       
        private void bDelete_Click(object sender, EventArgs e)
        {
            // удалить 

            if (dtData != null & dataGridViewJournal != null && dataGridViewJournal.RowCount > 0 && dataGridViewJournal.CurrentRow.Index != -1)
            {
                DataTable dtRows = dtData.DefaultView.ToTable();
                string message = "Удалить ";


                message += dtRows.Rows[dataGridViewJournal.CurrentRow.Index]["first_name"].ToString() + " ";
                message += dtRows.Rows[dataGridViewJournal.CurrentRow.Index]["last_name"].ToString() + " ";
                message += dtRows.Rows[dataGridViewJournal.CurrentRow.Index]["pather_name"].ToString() + " ";
                message += dtRows.Rows[dataGridViewJournal.CurrentRow.Index]["name1"].ToString() + " ";
                message += dtRows.Rows[dataGridViewJournal.CurrentRow.Index]["value"].ToString() + " ";

                if (MessageBox.Show(message, "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //удаляем оценку
                    sql.delMark(int.Parse(dtRows.Rows[dataGridViewJournal.CurrentRow.Index]["id"].ToString()));
                    setData();
                }

            }
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            // кнопка изменить 
            if (dtData != null && dataGridViewJournal != null && dataGridViewJournal.RowCount > 0 && dataGridViewJournal.CurrentRow.Index != -1)
            {
                DataTable dtRows = dtData.DefaultView.ToTable();

                EditMarksWindow frm = new EditMarksWindow(dtRows.Rows[dataGridViewJournal.CurrentRow.Index]);
                frm.ShowDialog();

                bw.RunWorkerAsync();
            }
        }

        private void PatientsWindow_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewJournal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dataGridViewJournal_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Config.mode == "director") {
                if (dtData != null && dataGridViewJournal != null && dataGridViewJournal.RowCount > 0 && dataGridViewJournal.CurrentRow.Index != -1)
                {
                    DataTable dtRows = dtData.DefaultView.ToTable();

                    AddPeopleWindow frm = new AddPeopleWindow(dtRows.Rows[dataGridViewJournal.CurrentRow.Index]);
                    frm.ShowDialog();

                    bw.RunWorkerAsync();
                }
            }
        }
    }
}
