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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace KajToBylo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum IndexCategory { MusicPL, MusicSL, Movie, Book };
        public static string[] NameCategory = { "Muzyka Polska", "Muzyka Śląska", "Film", "Książka" };

        private Base myBase;
        private Collections collections;
        private QuizCollection quizCollection;
               
        public MainWindow()
        {
            collections = new Collections();
            quizCollection = new QuizCollection();
            InitializeComponent();

            tabControl.DataContext = collections;
            listQuiz.ItemsSource = quizCollection.Quiz;
        }

        private void newBase_Click(object sender, RoutedEventArgs e)
        {
            if (myBase != null)
                saveBaseAndClear();
            
            DialogNewBase newBase = new DialogNewBase();
            newBase.ShowDialog();

            if (newBase.DialogNewBaseResult)
            {
                myBase = new Base(newBase.NameBase);

                enabledControls();
            }

            newBase.Close();
        }

        private void newQuestion_Click(object sender, RoutedEventArgs e)
        {
            DialogNewQuestion newQuestion = new DialogNewQuestion();
            newQuestion.ShowDialog();

            if (newQuestion.DialogNewQuestionResult)
            {
                myBase.SetCategory(newQuestion.Question);
                collections.AddItemsToCollections(newQuestion.Question);

                refreshListsView(newQuestion.Category);

            }
            newQuestion.Close();
        }

        private void openBase_Click(object sender, RoutedEventArgs e)
        {
            if (myBase != null)
                saveBaseAndClear();

            FolderBrowserDialog openBase = new FolderBrowserDialog();
            openBase.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\KajToBylo\";

            DialogResult result = openBase.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                int index = openBase.SelectedPath.LastIndexOf("\\");
                myBase = new Base(openBase.SelectedPath.Substring(index + 1));
                myBase.ReadALL(openBase.SelectedPath);

                setCollections();

                enabledControls();
            }
        }

        private void saveBaseAndClear()
        {
            DialogSaveBase saveBase = new DialogSaveBase();
            saveBase.ShowDialog();

            if (saveBase.DialogSaveBaseResult)
            {
                myBase.WriteAll();
                collections.Clear();
                quizCollection.Clear();
            }
            else
            {
                collections.Clear();
                quizCollection.Clear();
            }

            saveBase.Close();
        }

        private void saveBase_Click(object sender, RoutedEventArgs e)
        {
            myBase.WriteAll();
        }

        private void setCollections()
        {
            for (int i = 0; i < NameCategory.Count(); i++)
            {
                collections.SetCollections((IndexCategory)i, myBase.GetCategory((IndexCategory)i));
            }
        }

        private void enabledControls()
        {
            buttonSaveBase.IsEnabled = true;
            buttonNewQuestion.IsEnabled = true;

            menuSaveBase.IsEnabled = true;
            menuAddQuestion.IsEnabled = true;
            menuDeleteQuestion.IsEnabled = true;
        }


        private void getSelectedItem(object sender, MouseButtonEventArgs e)
        {
            //System.Windows.Controls.ListView listView = sender as System.Windows.Controls.ListView;

            QuestionAnswers question = (QuestionAnswers)listQuiz.SelectedItems[0];
            if (question.Used == true)
                question.Used = false;
            else
                question.Used = true;
            
            refreshListsView(question.CategoryIndex);
            listQuiz.Items.Refresh();
        }

        private void buttonDeleteQuestion_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button buttonDeleteQuestion = sender as System.Windows.Controls.Button;
            QuestionAnswers question = buttonDeleteQuestion.DataContext as QuestionAnswers;

            if (buttonDeleteQuestion.Name == "buttonDeleteQuiz")
            {
                quizCollection.DeleteItem(question);
                listQuiz.Items.Refresh();
            }
            else
            {
                collections.DeleteItem(question);
                myBase.DeleteQuestion(question);
            }
        }

        private void buttonEditQuestion_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button buttonEditQuestion = sender as System.Windows.Controls.Button;
            QuestionAnswers question = buttonEditQuestion.DataContext as QuestionAnswers;

            DialogEditQuestion editQuestion = new DialogEditQuestion(question);
            editQuestion.ShowDialog();

            if (editQuestion.DialogEditQuestionResult)
            {
                collections.ChangeItem(question, editQuestion.Question);
                myBase.ChangeQuestion(question, editQuestion.Question);
            }

            editQuestion.Close();
        }

        private void buttonAddToQuiz_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button buttonAddToQuiz = sender as System.Windows.Controls.Button;
            QuestionAnswers question = buttonAddToQuiz.DataContext as QuestionAnswers;

            quizCollection.AddItemsToCollections(question);
            question.AddedToQuizCollection = true;
            refreshListsView(question.CategoryIndex);
            listQuiz.Items.Refresh();
        }

        /*private IndexCategory checkCategory(string button)
        {
            if (button == "buttonDeleteMusicPL" || button == "buttonEditMusicPL" || button == "buttonAddToQuizMusicPL")
                return IndexCategory.MusicPL;
            else if (button == "buttonDeleteMusicSL" || button == "buttonEditMusicSL")
                return IndexCategory.MusicSL;
            else if (button == "buttonDeleteMovie" || button == "buttonEditMovie")
                return IndexCategory.Movie;
            else
                return IndexCategory.Book;
        }*/

        private void refreshListsView(IndexCategory indexCategory)
        {
            switch (indexCategory)
            {
                case IndexCategory.MusicPL:
                    listViewMusicPL.Items.Refresh();
                    break;
                case IndexCategory.MusicSL:
                    listViewMusicSL.Items.Refresh();
                    break;
                case IndexCategory.Movie:
                    listViewMovie.Items.Refresh();
                    break;
                case IndexCategory.Book:
                    listViewBook.Items.Refresh();
                    break;
            }
        }

        private void closeApp_Click(object sender, RoutedEventArgs e)
        {
            if (myBase != null)
                saveBaseAndClear();

            Environment.Exit(0);
        }

        private void window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (myBase != null)
                saveBaseAndClear();

            Environment.Exit(0);
        }

        private void FilterText_TextChanged(object sender, TextChangedEventArgs e)
        {
            System.Windows.Controls.TextBox filter = sender as System.Windows.Controls.TextBox;
            if (filter.Name == "filterQuiz")
                quizCollection.Refresh(filter);
            else
                collections.Refresh(filter);
            
        }
    }
}

