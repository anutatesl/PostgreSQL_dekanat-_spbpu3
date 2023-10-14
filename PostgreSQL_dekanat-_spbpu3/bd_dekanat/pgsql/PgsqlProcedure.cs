using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Npgsql;
using System.Windows.Forms;

namespace pgsql
{
    public class PgsqlProcedure
    {
        NpgsqlConnection conn;
        public PgsqlProcedure()
        {
            Connect();
        }

        private void Connect()
        {

            conn = new NpgsqlConnection("Host=" + Config.server + ";Port=" + Config.port + ";Username=" + Config.login + ";Password=" + Config.password + ";Database=" + Config.database + "");
        }

        private bool openConnect()
        {
            bool error = true;

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                error = false;
            }

            return error;
        }

        private bool closeConnect()
        {
            bool error = true;

            try
            {
                conn.Close();
            }
            catch
            {
                error = false;
            }

            return error;
        }

        public DataTable Login(string login, string password)
        {
            DataTable dtData = new DataTable();
            if (openConnect())
            {
                string pass;
                if (login == "director")
                {
                    pass = "SCRAM-SHA-256$4096:Ruz5sm+vV617lCKCq9ieBA==$ltitafQmnTVLjsRgqTaxu3ONmb+TI729jmJqOyVKvkc=:gOkRBAogo15IU5UFqhRdi3tW/xkqAap4G7DIMGHh728=";
                } else if(login == "viewer")
                {
                    pass = "SCRAM-SHA-256$4096:xk+ATnE/3fcJ5+e6whC1Qg==$LnWOBfgtlEzPxMQobf4MHbnXEdqQqpYoohgYb3yHCyo=:TLQAsDkMaHOYPHSEHqzYQN5vEaYeDpN21BGefDLYNWM=";
                } else
                {
                    pass = Compute_sha256_hash(password);
                }
                //string pass = "1234567";
                string commandText = $"SELECT * FROM users WHERE login = '" + login + "' and password = '" + pass + "'";
                NpgsqlCommand cmd = new NpgsqlCommand(commandText, conn);
                dtData.Load(cmd.ExecuteReader());
                closeConnect();
            }

            return dtData;
        }

        private String Compute_sha256_hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        public bool test()
        {
            bool boolfound = false;
            if (openConnect())
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("SELECT version()", conn); // **** - таблица
                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        boolfound = true;

                        Console.WriteLine("Подключение к БД создано");
                    }
                    if (boolfound == false)
                    {
                        Console.WriteLine("Подключение к БД не удалось");
                    }
                    dr.Close();

                    closeConnect();
                }
                catch
                {
                    closeConnect();
                }

            }

            return boolfound;
        }

        public DataTable getJournal() // загружаем людей
        {
            DataTable dtData = new DataTable();
            if (openConnect())
            {
                string query;
                query = "SELECT marks.id, people.first_name, people.last_name, people.pather_name, groups.name, subjects.name,  marks.value  FROM people";
                query += " INNER JOIN groups on groups.id = people.group_id";
                query += " INNER JOIN marks on marks.student_id = people.id";
                query += " INNER JOIN subjects on subjects.id = marks.subject_id";

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                dtData.Load(cmd.ExecuteReader());

                closeConnect();
            }

            return dtData;
        }

        //добавляю человека в журнал
        public void setPeople(int id, string first_name, string last_name, string pather_name, int g_num, char type)
        {
            if (openConnect())
            {
                string query = "";

                if (id == -1)
                {
                    query = "INSERT INTO people (first_name, last_name, pather_name, group_id, type) VALUES ('" + first_name + "', '" + last_name + "', '" + pather_name + "', " + g_num + ", '" + type + "')";
                }
                else
                {
                    query = "UPDATE people SET first_name = '" + first_name + "', last_name = '" + last_name + "', pather_name = '" + pather_name + "', group_id = " + g_num + ", type = " + type + "";
                    query += " WHERE id = " + id + "";
                }
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    closeConnect();
                }
                catch (Npgsql.PostgresException e)
                {
                    MessageBox.Show(e.MessageText, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    closeConnect();
                }
            }
        }

        public DataTable getListGroup() // выводим список групп
        {
            DataTable dtData = new DataTable();
            if (openConnect())
            {
                string query;
                query = "SELECT id, name FROM groups";
                query += " ORDER BY name";

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                dtData.Load(cmd.ExecuteReader());

                closeConnect();
            }

            return dtData;
        }


        public DataTable getPeople() // выводим список людей
        {
            DataTable dtData = new DataTable();
            if (openConnect())
            {
                string query;
                query = "SELECT id, first_name, last_name, pather_name, group_id, type FROM people";
                query += " ORDER BY first_name";

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                dtData.Load(cmd.ExecuteReader());

                closeConnect();
            }

            return dtData;
        }

        public DataTable getStudent() // выводим список студентов
        {
            char type = 'S';
            DataTable dtData = new DataTable();
            if (openConnect())
            {
                string query;
                query = "SELECT id, first_name, last_name, pather_name FROM people";
                query += " WHERE type = '" + type + "'";


                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                dtData.Load(cmd.ExecuteReader());

                closeConnect();
            }

            return dtData;
        }

        public DataTable getSubject() // выводим список предметов
        {
            DataTable dtData = new DataTable();
            if (openConnect())
            {
                string query;
                query = "SELECT id, name FROM subjects";


                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                dtData.Load(cmd.ExecuteReader());

                closeConnect();
            }

            return dtData;
        }

        public DataTable getTeacher() // выводим список преподавателей
        {
            char type = 'P';
            DataTable dtData = new DataTable();
            if (openConnect())
            {
                string query;
                query = "SELECT id, first_name, last_name, pather_name FROM people";
                query += " WHERE type = '" + type + "'";


                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                dtData.Load(cmd.ExecuteReader());

                closeConnect();
            }

            return dtData;
        }


        // проверка групп в таблице людей 
        public DataTable getGroupInPeople(int id)
        {
            DataTable dtData = new DataTable();
            if (openConnect())
            {
                string query;
                query = "SELECT group_id FROM people";
                query += " WHERE group_id = " + id;

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                dtData.Load(cmd.ExecuteReader());

                closeConnect();
            }

            return dtData;
        }

        // проверка людей в оценках 
        public DataTable getPeopleInMarks(int id)
        {
            DataTable dtData = new DataTable();
            if (openConnect())
            {
                string query;
                query = "SELECT student_id FROM marks";
                query += " WHERE student_id = " + id;

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                dtData.Load(cmd.ExecuteReader());

                closeConnect();
            }

            return dtData;
        }

        // проверка предмета в оценках 
        public DataTable getSubjectInMarks(int id)
        {
            DataTable dtData = new DataTable();
            if (openConnect())
            {
                string query;
                query = "SELECT subject_id FROM marks";
                query += " WHERE subject_id = " + id;

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                dtData.Load(cmd.ExecuteReader());

                closeConnect();
            }

            return dtData;
        }

        public DataTable getTeacherInMarks(int id)
        {
            DataTable dtData = new DataTable();
            if (openConnect())
            {
                string query;
                query = "SELECT teacher_id FROM marks";
                query += " WHERE student_id = " + id;

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                dtData.Load(cmd.ExecuteReader());

                closeConnect();
            }

            return dtData;
        }


        // удаляю группу
        public void delGroup(int id)
        {
            if (openConnect())
            {
                string query = "";

                query = "DELETE FROM groups WHERE id = " + id;

                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    closeConnect();
                }
                catch (Npgsql.PostgresException e)
                {
                    MessageBox.Show(e.MessageText, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    closeConnect();
                }
            }
        }


        // удалить оценку
        public void delMark(int id)
        {
            if (openConnect())
            {
                string query = "";

                query = "DELETE FROM marks where id =" + id;
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    closeConnect();
                }
                catch (Npgsql.PostgresException e)
                {
                    MessageBox.Show(e.MessageText, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    closeConnect();
                }
            }
        }


        //удаляю предмет
        public void delSubject(int id)
        {
            if (openConnect())
            {
                string query = "";

                query = "DELETE FROM subjects WHERE id = " + id;

                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    closeConnect();
                }
                catch (Npgsql.PostgresException e)
                {
                    MessageBox.Show(e.MessageText, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    closeConnect();
                }
            }
        }

        // удаляю человека
        public void delPeople(int id)
        {
            if (openConnect())
            {
                string query = "";

                query = "DELETE FROM people WHERE id = " + id;

                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    closeConnect();
                }
                catch (Npgsql.PostgresException e)
                {
                    MessageBox.Show(e.MessageText, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    closeConnect();
                }
            }
        }

        //изменить оценку
        public void setMark(int id, int stu, int sub, int teach, int value)
        {
            if (openConnect())
            {
                string query = "";

                if (id == -1)
                    query = "INSERT INTO marks (student_id, subject_id, teacher_id, value) VALUES (" + stu + ", " + sub + ", " + teach + ", " + value + ")";
                else
                    query = "UPDATE INTO marks (student_id, subject_id, teacher_id, value) VALUES (" + stu + ", " + sub + ", " + teach + ", " + value + ")";

                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    closeConnect();
                }
                catch (Npgsql.PostgresException e)
                {
                    MessageBox.Show(e.MessageText, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    closeConnect();
                }
            }
        }



        // изменить название группы
        public void setNameGroup(int id, string name)
        {
            if (openConnect())
            {
                string query = "";

                if (id == -1)
                    query = "INSERT INTO groups (name) VALUES ('" + name + "')";
                else
                    query = "UPDATE groups SET name = '" + name + "' where id = " + id + "";

                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    closeConnect();
                }
                catch (Npgsql.PostgresException e)
                {
                    MessageBox.Show(e.MessageText, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    closeConnect();
                }
            }
        }

        //изменить название предмета
        public void setNameSubject(int id, string name)
        {
            if (openConnect())
            {
                string query = "";

                if (id == -1)
                    query = "INSERT INTO subjects (name) VALUES ('" + name + "')";
                else
                    query = "UPDATE subjects SET name = '" + name + "' where id = " + id + "";

                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    closeConnect();
                }
                catch (Npgsql.PostgresException e)
                {
                    MessageBox.Show(e.MessageText, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    closeConnect();
                }
            }
        }

        // изменить оценку
        public void setMark(int id, int value)
        {
            if (openConnect())
            {
                string query = "";

                if (id == -1)
                    query = "INSERT INTO marks (value) VALUES (" + value + ")";
                else
                    query = "UPDATE marks SET value = " + value + " where id = " + id + "";

                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    closeConnect();
                }
                catch (Npgsql.PostgresException e)
                {
                    MessageBox.Show(e.MessageText, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    closeConnect();
                }
            }
        }

        // изменить имя
        public void setNamePeople(int id, string first_name, string last_name, string pather_name)
        {
            if (openConnect())
            {
                string query = "";

                if (id == -1)
                {
                    query = "INSERT INTO people (first_name) VALUES ('" + first_name + "')";
                    query += "INSERT INTO people (last_name) VALUES ('" + last_name + "')";
                    query += "INSERT INTO people (pather_name) VALUES ('" + pather_name + "')";
                }
                else
                {
                    query = "UPDATE people";
                    query += " SET first_name = '" + first_name + "', last_name= '" + last_name + "', pather_name = '" + pather_name + "'";
                    query += " where id = " + id + "";
                }
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    closeConnect();
                }
                catch (Npgsql.PostgresException e)
                {
                    MessageBox.Show(e.MessageText, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    closeConnect();
                }
            }
        }


        // добавление группы
        public void setGroups(int id, string name)
        {
            if (openConnect())
            {
                string query = "";

                if (id == -1)
                {
                    query = "INSERT INTO groups (name) VALUES ('" + name + "')";
                }
                else
                {
                    query = "UPDATE groups";
                    query += " SET name = '" + name + "";
                    query += " where id = " + id + "";
                }

                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    closeConnect();
                }
                catch (Npgsql.PostgresException e)
                {
                    MessageBox.Show(e.MessageText, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    closeConnect();
                }

            }
        }


        //создания запроса для отчета по среднему баллу по студентам
        public DataTable getStudentAVGResult()
        {

            DataTable dtData = new DataTable();

            if (openConnect())
            {

                string query;
                query = "SELECT public.people.first_name, public.people.last_name, public.people.pather_name, AVG(public.marks.value) FROM public.marks";
                query += " JOIN public.people ON public.marks.student_id = public.people.id";
                query += " WHERE public.marks.year >= '2021' AND public.marks.year <= '2023'";
                query += " GROUP BY public.people.first_name, public.people.last_name, public.people.pather_name";

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                dtData.Load(cmd.ExecuteReader());

                closeConnect();
            }

            return (dtData);
        }

        //создания запроса для отчета по среднему баллу по группам
        public DataTable getGroupAVGResult()
        {

            DataTable dtData = new DataTable();

            if (openConnect())
            {

                string query;
                query = "SELECT public.groups.name, AVG(public.marks.value) FROM public.marks";
                query += " JOIN public.people ON public.marks.student_id = public.people.id";
                query += " FULL JOIN public.groups ON public.people.group_id = public.groups.id";
                query += " WHERE public.marks.year >= '2021' AND public.marks.year <= '2023'";
                query += " GROUP BY public.groups.name";

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                dtData.Load(cmd.ExecuteReader());

                closeConnect();
            }

            return (dtData);
        }

        //создания запроса для отчета по среднему баллу по предметам
        public DataTable getSubjectsAVGResult()
        {

            DataTable dtData = new DataTable();

            if (openConnect())
            {

                string query;
                query = "SELECT public.subjects.name, AVG(public.marks.value) FROM public.marks";
                query += " JOIN public.subjects ON public.marks.subject_id = public.subjects.id";
                query += " WHERE public.marks.year >= '2021' AND public.marks.year <= '2023'";
                query += " GROUP BY public.subjects.name";

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                dtData.Load(cmd.ExecuteReader());

                closeConnect();
            }

            return (dtData);
        }

        //создания запроса для отчета по среднему баллу по преподавателям
        public DataTable getTeachersAVGResult()
        {

            DataTable dtData = new DataTable();

            if (openConnect())
            {

                string query;
                query = "SELECT public.people.first_name, public.people.last_name, public.people.pather_name, AVG(public.marks.value) FROM public.marks";
                query += " JOIN public.people ON public.marks.teacher_id = public.people.id";
                query += " WHERE public.marks.year >= '2021' AND public.marks.year <= '2023'";
                query += " GROUP BY public.people.first_name, public.people.last_name, public.people.pather_name";

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                dtData.Load(cmd.ExecuteReader());

                closeConnect();
            }

            return (dtData);
        }
    }
}