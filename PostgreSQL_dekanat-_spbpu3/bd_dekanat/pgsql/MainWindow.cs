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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            LoginWindow frm = new LoginWindow();
            frm.ShowDialog();

            InitializeComponent();

            JournalWindow frmMDI = new JournalWindow();
            frmMDI.MdiParent = this;
            frmMDI.Show();
        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void closeMDI()
        {
            foreach (Form frmMDI in this.MdiChildren)
            {
                frmMDI.Close();
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeMDI();
        }

        private void ToolStripMenuItemJournal_Click(object sender, EventArgs e)
        {
            closeMDI();

            JournalWindow frmMDI = new JournalWindow();
            frmMDI.MdiParent = this;
            frmMDI.Show();
        }

        private void ToolStripMenuItemDir1_Click(object sender, EventArgs e)
        {
            //  справочник группы 
            
            GroupsWindow frm = new GroupsWindow();
          
            frm.ShowDialog();
        }


        private void ToolStripMenuItemDir2_Click(object sender, EventArgs e)
        {
            //  справочник люди
            
            PeopleWindow frm = new PeopleWindow();
            
            frm.ShowDialog();
        }

        private void ToolStripMenuItemDir3_Click(object sender, EventArgs e)
        {
            //  справочник предметы

            Subjects frm = new Subjects();

            frm.ShowDialog();
        }


        // кнопка отчет по студентам
        private void ToolStripMenuItemReport1_Click(object sender, EventArgs e)
        {
            report.ReportStatistics report = new report.ReportStatistics("report/reportStudentAVG.pdf");
            report.printStudentAVG();
            report.showReport();
        }

        // кнопка отчет по предметам
        private void ToolStripMenuItemReport2_Click(object sender, EventArgs e)
        {
            report.ReportStatistics report = new report.ReportStatistics("report/reportSubjectsAVG.pdf");
            report.printSubjectAVG();
            report.showReport();
        }

        // кнопка отчет по группам
        private void ToolStripMenuItemReport3_Click(object sender, EventArgs e)
        {
            report.ReportStatistics report = new report.ReportStatistics("report/reportGroupAVG.pdf");
            report.printGroupAVG();
            report.showReport();
        }

        // кнопка отчет по преподавателям
        private void ToolStripMenuItemReport4_Click(object sender, EventArgs e)
        {
            report.ReportStatistics report = new report.ReportStatistics("report/reportTeacherAVG.pdf");
            report.printTeacherAVG();
            report.showReport();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
        
        }

        private void ToolStripMenuItemReports_Click(object sender, EventArgs e)
        {
        
        }
    }
}
