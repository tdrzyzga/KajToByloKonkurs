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
    /// Interaction logic for DialogNewQuestion.xaml
    /// </summary>
    public partial class DialogNewQuestion : Window
    {
        public bool DialogNewQuestionResult { get; private set; }
        public MainWindow.IndexCategory Category { get; private set; }
        public QuestionAnswers Question { get; private set; }

        public DialogNewQuestion()
        {
            InitializeComponent();
        }

        private void dialogNewQuestionSave_Click(object sender, RoutedEventArgs e)
        {
            DialogNewQuestionResult = true;

            Question = new QuestionAnswers(newQuestion.Text, CheckCorrectAnswer(), dialogNewQuestionAnswerA.Text, dialogNewQuestionAnswerB.Text, dialogNewQuestionAnswerC.Text, dialogNewQuestionAnswerD.Text, DateTime.Now);
            Category = CheckCategory();

            this.Hide();
        }

        private MainWindow.IndexCategory CheckCategory()
        {
            if (dialogNewQuestionMusicPL.IsChecked == true)
                return MainWindow.IndexCategory.MusicPL;
            else if (dialogNewQuestionMusicSL.IsChecked == true)
                return MainWindow.IndexCategory.MusicSL;
            else if (dialogNewQuestionFilm.IsChecked == true)
                return MainWindow.IndexCategory.Movie;
            else
                return MainWindow.IndexCategory.Book;
        }

        private MainWindow.CorrectAnswer CheckCorrectAnswer()
        {
            if (dialogNewQuestionA.IsChecked == true)
                return MainWindow.CorrectAnswer.AnswerA;
            else if (dialogNewQuestionB.IsChecked == true)
                return MainWindow.CorrectAnswer.AnswerB;
            else if (dialogNewQuestionC.IsChecked == true)
                return MainWindow.CorrectAnswer.AnswerC;
            else
                return MainWindow.CorrectAnswer.AnswerD;
        }

        private void dialogNewQuestionCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
