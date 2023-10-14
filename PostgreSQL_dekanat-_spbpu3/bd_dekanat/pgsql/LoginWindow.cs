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
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (loginField.Text.Trim() == "" || passwordField.Text.Trim() == "")
            {
                MessageBox.Show("Поля логин и пароль обязательны к заполнению", "Пустые поля", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PgsqlProcedure sql = new PgsqlProcedure();
            DataTable dtData = sql.Login(loginField.Text, passwordField.Text);
            
            if (dtData != null && dtData.Rows.Count > 0)
            {
                Config.login = loginField.Text;
                Config.password = passwordField.Text;
                Config.mode = dtData.Rows[0]["mode"].ToString();
                Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Неверные поля", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (Config.mode == "С")
            {
                if (MessageBox.Show("Закрыть программу?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                    Environment.Exit(1);
                }
            }
            else
            {
                Close();
            }
        }

        //private void label2_Click(object sender, EventArgs e)
        //{
        //
        //}
    }
}
