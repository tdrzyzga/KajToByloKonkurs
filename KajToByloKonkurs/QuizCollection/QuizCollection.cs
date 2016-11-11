using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.ComponentModel;

namespace KajToBylo
{
    class QuizCollection
    {
        public ICollectionView Quiz { get; private set; }

        private ObservableCollection<QuizQuestionAnswers> quizCollection;
        private string filterText;
        private int indexMusicPL;
        private int indexMusicSL;
        private int indexMovie;
        private int indexBook;

        public QuizCollection()
        {
            quizCollection = new ObservableCollection<QuizQuestionAnswers>();
            
            Quiz = CollectionViewSource.GetDefaultView(quizCollection);
            Quiz.Filter = questionSearch;

            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Question.CategoryName");
            Quiz.GroupDescriptions.Add(groupDescription);

            indexMusicPL = 0;
            indexMusicSL = 0;
            indexMovie = 0;
            indexBook = 0;
        }

        public void AddItem(QuestionAnswers question)
        {
            quizCollection.Add(new QuizQuestionAnswers(updateCountCategory(question),question));
        }

        public void RemoveItem(QuestionAnswers question)
        {
            //quizCollection.Remove(second.question);
        }

        public void Refresh(TextBox texBox)
        {
            filterText = texBox.Text;
            Quiz.Refresh();
        }

        public void RefreshSingleItem(QuestionAnswers question)
        {
           // int index = quizCollection.IndexOf(question);

           // quizCollection.Remove(question);
           // quizCollection.Insert(index, question);
        }

        public void Clear()
        {
            quizCollection.Clear();
        }

        private bool questionSearch(object item)
        {
            QuestionAnswers question = item as QuestionAnswers;

            if (filterText == null || question.Question.Contains(filterText))
                return true;
            else
                return false;
        }

        private int updateCountCategory(QuestionAnswers question)
        {
            int index = 0;
            switch (question.CategoryIndex)
            {
                case MainWindow.IndexCategory.MusicPL:
                    indexMusicPL++;
                    index = indexMusicPL;
                    break;
                case MainWindow.IndexCategory.MusicSL:
                    indexMusicSL++;
                    index = indexMusicSL;
                    break;
                case MainWindow.IndexCategory.Movie:
                    indexMovie++;
                    index = indexMovie;
                    break;
                case MainWindow.IndexCategory.Book:
                    indexBook++;
                    index = indexBook;
                    break;
            }
            return index;
        }
    }
}








