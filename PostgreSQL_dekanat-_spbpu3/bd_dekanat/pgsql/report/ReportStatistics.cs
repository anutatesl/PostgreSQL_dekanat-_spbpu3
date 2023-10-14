using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Data;
using iText.IO.Font;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace pgsql.report
{
    class ReportStatistics
    {
        private PgsqlProcedure sql = new PgsqlProcedure();
        private string fileName = "";
        private PdfDocument pdfDoc;
        private Document doc;
        private PdfFont f1;

        public ReportStatistics(string fileName)
        {
            this.fileName = fileName;
            pageConfig();
        }


        public void printStudentAVG()
        {
            DataTable dtD = sql.getStudentAVGResult();
            createDocument();
            headerReport("Средний бал по студентам");
            doc.Add(new Paragraph(""));
            bodyStudentAVGStat(dtD);
            closeDocument();
        }

        public void printSubjectAVG()
        {
            DataTable dtD = sql.getSubjectsAVGResult();
            createDocument();
            headerReport("Средний бал по предметам");
            doc.Add(new Paragraph(""));
            bodySubjectAVGStat(dtD);
            closeDocument();
        }

        public void printGroupAVG()
        {
            DataTable dtD = sql.getGroupAVGResult();
            createDocument();
            headerReport("Средний бал по группам");
            doc.Add(new Paragraph(""));
            bodyGroupAVGStat(dtD);
            closeDocument();
        }

        public void printTeacherAVG()
        {
            DataTable dtD = sql.getTeachersAVGResult();
            createDocument();
            headerReport("Средний бал по учителям");
            doc.Add(new Paragraph(""));
            bodyTeacherAVGStat(dtD);
            closeDocument();
        }

        public void showReport()
        {
            Process.Start(Config.path + "\\" + fileName);
        }

        private void createDocument()
        {
            FileInfo file = new FileInfo(fileName);
            file.Directory.Create();

            pdfDoc = new PdfDocument(new PdfWriter(fileName));
            doc = new Document(pdfDoc);
        }

        private void pageConfig()
        {
            f1 = PdfFontFactory.CreateFont("arial.ttf", "Cp1251", true);
        }

        private void closeDocument()
        {
            doc.Close();
        }

        private void headerReport(string title)
        {

            doc.Add(new Paragraph(title).SetFont(f1).SetFontSize(20).SetTextAlignment(TextAlignment.CENTER));
            doc.Add(new Paragraph(DateTime.Now.ToString("yyyy-MM-dd")).SetTextAlignment(TextAlignment.RIGHT));
        }



        // шапка для запроса для отчета по среднему баллу по студентам
        private void bodyStudentAVGStat(DataTable dt)
        {
            Table table = new Table(4);

            table.SetHorizontalAlignment(HorizontalAlignment.CENTER);

            table.AddCell("Фамилия").SetFont(f1);
            table.AddCell("Имя").SetFont(f1);
            table.AddCell("Отчество").SetFont(f1);
            table.AddCell("Оценка").SetFont(f1);

            for (int j = 0; j < dt.Rows.Count; j++)
            {
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    table.AddCell((dt.Rows[j][k].ToString()));
                }
            }
            doc.Add(table);
        }

        // шапка для запроса для отчета по среднему баллу по предметам
        private void bodySubjectAVGStat(DataTable dt)
        {
            Table table = new Table(2);

            table.SetHorizontalAlignment(HorizontalAlignment.CENTER);

            table.AddCell("Предмет").SetFont(f1);
            table.AddCell("Оценка").SetFont(f1);


            for (int j = 0; j < dt.Rows.Count; j++)
            {
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    table.AddCell((dt.Rows[j][k].ToString()));
                }
            }
            doc.Add(table);
        }

        // шапка для запроса для отчета по среднему баллу по группам
        private void bodyGroupAVGStat(DataTable dt)
        {
            Table table = new Table(2);

            table.SetHorizontalAlignment(HorizontalAlignment.CENTER);

            table.AddCell("Группа").SetFont(f1);
            table.AddCell("Оценка").SetFont(f1);


            for (int j = 0; j < dt.Rows.Count; j++)
            {
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    table.AddCell((dt.Rows[j][k].ToString()));
                }
            }
            doc.Add(table);
        }

        // шапка для запроса для отчета по среднему баллу по преподавателям
        private void bodyTeacherAVGStat(DataTable dt)
        {
            Table table = new Table(4);

            table.SetHorizontalAlignment(HorizontalAlignment.CENTER);

            table.AddCell("Фамилия").SetFont(f1);
            table.AddCell("Имя").SetFont(f1);
            table.AddCell("Отчество").SetFont(f1);
            table.AddCell("Оценка").SetFont(f1);

            for (int j = 0; j < dt.Rows.Count; j++)
            {
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    table.AddCell((dt.Rows[j][k].ToString()));
                }
            }
            doc.Add(table);
        }
    }
}
