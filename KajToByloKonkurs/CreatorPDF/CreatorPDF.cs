using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Drawing;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace KajToBylo
{
    class CreatorPDF
    {
        private System.Windows.Controls.ListView listQuiz;

        public CreatorPDF(System.Windows.Controls.ListView listView)
        {
            listQuiz = listView;
 
        }

        public void CreatePDFDocument()
        {
            PdfDocument pdfDoc = new PdfDocument();

            string groupName = "";
            List<QuestionAnswers> listQuestion = new List<QuestionAnswers>();
            bool firstRound = true;

            foreach (QuestionAnswers question in listQuiz.Items)
            {
                if (firstRound)
                {
                    groupName = question.CategoryName;
                    firstRound = false;
                }

                if (groupName == question.CategoryName)
                {
                    listQuestion.Add(question);
                }
                else if (groupName != question.CategoryName)
                {
                    createPDFPage(pdfDoc, listQuestion);
                    groupName = question.CategoryName;
                    listQuestion.Clear();
                    listQuestion.Add(question);
                }
            }
            createPDFPage(pdfDoc, listQuestion);

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveDialog.Filter = "PDF file (*.pdf)|*.pdf";

            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pdfDoc.SaveToFile(saveDialog.FileName);
                System.Diagnostics.Process.Start(saveDialog.FileName);
            } 
        }

        private void createPDFPage(PdfDocument pdfDoc, List<QuestionAnswers> listQuestion)
        {
            int countItems = 0;
            int point = 20;

            PdfPageBase page = pdfDoc.Pages.Add();
            PdfTrueTypeFont fontTrue = new PdfTrueTypeFont(new Font("Courier", 12f, FontStyle.Bold),true);
            PdfTrueTypeFont fontFalse = new PdfTrueTypeFont(new Font("Courier", 11f), true);
            PdfSolidBrush brushTrue = new PdfSolidBrush(System.Drawing.Color.Green);
            PdfSolidBrush brushFalse = new PdfSolidBrush(System.Drawing.Color.Black);

            page.Canvas.DrawString(listQuestion[0].CategoryName, new PdfTrueTypeFont(new Font("Courier", 13f, FontStyle.Bold),true), PdfBrushes.Black, new System.Drawing.PointF(150, point));

            foreach (QuestionAnswers question in listQuestion)
            {
                countItems++;
                page.Canvas.DrawString(countItems + ") " + question.Question, new PdfTrueTypeFont(new Font("Courier", 12f, FontStyle.Bold), true), PdfBrushes.Black, new System.Drawing.PointF(0, point += 13));
                page.Canvas.DrawString("a) " + question.ResponseA.Item2, question.ResponseA.Item1 ? fontTrue : fontFalse, question.ResponseA.Item1 ? brushTrue : brushFalse, new System.Drawing.PointF(10, point += 15));
                page.Canvas.DrawString("b) " + question.ResponseB.Item2, question.ResponseB.Item1 ? fontTrue : fontFalse, question.ResponseB.Item1 ? brushTrue : brushFalse, new System.Drawing.PointF(10, point += 14));
                page.Canvas.DrawString("c) " + question.ResponseC.Item2, question.ResponseC.Item1 ? fontTrue : fontFalse, question.ResponseC.Item1 ? brushTrue : brushFalse, new System.Drawing.PointF(10, point += 14));
                page.Canvas.DrawString("d) " + question.ResponseD.Item2, question.ResponseD.Item1 ? fontTrue : fontFalse, question.ResponseD.Item1 ? brushTrue : brushFalse, new System.Drawing.PointF(10, point += 14));
            }
        }
    }
}
