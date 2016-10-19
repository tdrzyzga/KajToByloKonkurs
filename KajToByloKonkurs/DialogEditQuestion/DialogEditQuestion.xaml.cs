using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KajToBylo
{
    /// <summary>
    /// Interaction logic for DialogEditQuestion.xaml
    /// </summary>
    public partial class DialogEditQuestion : Window
    {
        public bool DialogEditQuestionResult { get; private set; }
        public QuestionAnswers Question { get; private set; }

        private MainWindow.IndexCategory Category;
        private MainWindow.CorrectAnswer CorrectAnswer;

        public DialogEditQuestion(MainWindow.IndexCategory category, QuestionAnswers question)
        {
            InitializeComponent();

            Category = category;
            CorrectAnswer = question.GoodAnswer;

            editQuestion.Text = question.Question;
            dialogEditQuestionAnswerA.Text = question.ResponseA;
            dialogEditQuestionAnswerB.Text = question.ResponseB;
            dialogEditQuestionAnswerC.Text = question.ResponseC;
            dialogEditQuestionAnswerD.Text = question.ResponseD;
            
            SetCategory();
            SetCorrectAnswer();
        }

        private void dialogEditQuestionSave_Click(object sender, RoutedEventArgs e)
        {
            DialogEditQuestionResult = true;

            Question = new QuestionAnswers(editQuestion.Text, CheckCorrectAnswer(), dialogEditQuestionAnswerA.Text, dialogEditQuestionAnswerB.Text, dialogEditQuestionAnswerC.Text, dialogEditQuestionAnswerD.Text, DateTime.Now);
         
            this.Hide();
        }

        private void SetCategory()
        {
            switch (Category)
            {
                case MainWindow.IndexCategory.MusicPL:
                    dialogEditQuestionMusicPL.IsChecked = true;
                    break;
                case MainWindow.IndexCategory.MusicSL:
                    dialogEditQuestionMusicSL.IsChecked = true;
                    break;
                case MainWindow.IndexCategory.Movie:
                    dialogEditQuestionMovie.IsChecked = true;
                    break;
                case MainWindow.IndexCategory.Book:
                    dialogEditQuestionBook.IsChecked = true;
                    break;
            }
        }

        private void SetCorrectAnswer()
        {
            switch (CorrectAnswer)
            {
                case MainWindow.CorrectAnswer.AnswerA:
                    dialogEditQuestionA.IsChecked = true;
                    break;
                case MainWindow.CorrectAnswer.AnswerB:
                    dialogEditQuestionB.IsChecked = true;
                    break;
                case MainWindow.CorrectAnswer.AnswerC:
                    dialogEditQuestionC.IsChecked = true;
                    break;
                case MainWindow.CorrectAnswer.AnswerD:
                    dialogEditQuestionD.IsChecked = true;
                    break;
            }
        }


        private MainWindow.IndexCategory CheckCategory()
        {
            if (dialogEditQuestionMusicPL.IsChecked == true)
                return MainWindow.IndexCategory.MusicPL;
            else if (dialogEditQuestionMusicSL.IsChecked == true)
                return MainWindow.IndexCategory.MusicSL;
            else if (dialogEditQuestionMovie.IsChecked == true)
                return MainWindow.IndexCategory.Movie;
            else
                return MainWindow.IndexCategory.Book;
        }

        private MainWindow.CorrectAnswer CheckCorrectAnswer()
        {
            if (dialogEditQuestionA.IsChecked == true)
                return MainWindow.CorrectAnswer.AnswerA;
            else if (dialogEditQuestionB.IsChecked == true)
                return MainWindow.CorrectAnswer.AnswerB;
            else if (dialogEditQuestionC.IsChecked == true)
                return MainWindow.CorrectAnswer.AnswerC;
            else
                return MainWindow.CorrectAnswer.AnswerD;
        }

        private void dialogEditQuestionCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
