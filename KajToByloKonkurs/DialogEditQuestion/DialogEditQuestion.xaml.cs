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
        private QuestionAnswers questionBeforeEdit;


        public DialogEditQuestion(QuestionAnswers question)
        {
            InitializeComponent();

            Category = question.CategoryIndex;
            questionBeforeEdit = question;

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

            Question = new QuestionAnswers(Category, editQuestion.Text, (Tuple.Create((bool)dialogEditQuestionA.IsChecked, dialogEditQuestionAnswerA.Text)), (Tuple.Create((bool)dialogEditQuestionB.IsChecked, dialogEditQuestionAnswerB.Text)), (Tuple.Create((bool)dialogEditQuestionC.IsChecked, dialogEditQuestionAnswerC.Text)), (Tuple.Create((bool)dialogEditQuestionD.IsChecked, dialogEditQuestionAnswerD.Text)), questionBeforeEdit.GeneratedData, questionBeforeEdit.Used, questionBeforeEdit.AddedToQuizCollection);
         
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

        private void dialogEditQuestionCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
