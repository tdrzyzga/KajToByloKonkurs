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


        public DialogEditQuestion(MainWindow.IndexCategory category, QuestionAnswers question)
        {
            InitializeComponent();

            Category = category;

            editQuestion.Text = question.Question;
            dialogEditQuestionAnswerA.Text = question.ResponseA.Item2;
            dialogEditQuestionAnswerB.Text = question.ResponseB.Item2;
            dialogEditQuestionAnswerC.Text = question.ResponseC.Item2;
            dialogEditQuestionAnswerD.Text = question.ResponseD.Item2;

            dialogEditQuestionA.IsChecked = question.ResponseA.Item1;
            dialogEditQuestionB.IsChecked = question.ResponseB.Item1;
            dialogEditQuestionC.IsChecked = question.ResponseC.Item1;
            dialogEditQuestionD.IsChecked = question.ResponseD.Item1;
            SetCategory();
            
        }

        private void dialogEditQuestionSave_Click(object sender, RoutedEventArgs e)
        {
            DialogEditQuestionResult = true;

            Question = new QuestionAnswers(editQuestion.Text, (Tuple.Create((bool)dialogEditQuestionA.IsChecked, dialogEditQuestionAnswerA.Text)), (Tuple.Create((bool)dialogEditQuestionB.IsChecked, dialogEditQuestionAnswerB.Text)), (Tuple.Create((bool)dialogEditQuestionC.IsChecked, dialogEditQuestionAnswerC.Text)), (Tuple.Create((bool)dialogEditQuestionD.IsChecked, dialogEditQuestionAnswerD.Text)), DateTime.Now);
         
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

        /*private void SetCorrectAnswer()
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
        }*/


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
        
        /*private MainWindow.CorrectAnswer CheckCorrectAnswer()
        {
            if (dialogEditQuestionA.IsChecked == true)
                return MainWindow.CorrectAnswer.AnswerA;
            else if (dialogEditQuestionB.IsChecked == true)
                return MainWindow.CorrectAnswer.AnswerB;
            else if (dialogEditQuestionC.IsChecked == true)
                return MainWindow.CorrectAnswer.AnswerC;
            else
                return MainWindow.CorrectAnswer.AnswerD;
        }*/

        private void dialogEditQuestionCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
