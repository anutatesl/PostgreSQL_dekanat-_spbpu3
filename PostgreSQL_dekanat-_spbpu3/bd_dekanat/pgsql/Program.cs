using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;


namespace pgsql
{
    static class Program
    {
        
        [STAThread]
        static void Main()
        {
            try
            {
                var parser = new FileIniDataParser();
                IniData f = parser.ReadFile("config.ini");  // connect .ini
                Config.login = f["config"]["login"];
                Config.password = f["config"]["password"];
                Config.database = f["config"]["database"];
                Config.server = f["config"]["server"];
                Config.port = f["config"]["port"];
                Config.mode = "С";
                Config.path = Application.StartupPath;
            }
            catch
            {
                MessageBox.Show("Ошибка чтения конфигурационного файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //pgsql test
            PgsqlProcedure sql = new PgsqlProcedure();
            if (sql.test())
            {
                try { 
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
                }
                catch (Exception ex)
                {
                    //btn_login.Enabled = true;
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Ошибка подключения к БД.ырф", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            
        }
    }
}
