using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace KajToBylo
{
    class QuizCollection
    {
        public CollectionView Quiz { get; private set; }

        private ObservableCollection<QuestionAnswers> quizCollection;
        private string filterText;

        public QuizCollection()
        {
            quizCollection = new ObservableCollection<QuestionAnswers>();

            Quiz = new CollectionView(quizCollection);
            Quiz = (CollectionView)CollectionViewSource.GetDefaultView(quizCollection);
            Quiz.Filter = questionSearch;

            PropertyGroupDescription groupDescription = new PropertyGroupDescription("CategoryName");
            Quiz.GroupDescriptions.Add(groupDescription);
        }

        public void AddItemsToCollections(QuestionAnswers question)
        {
            quizCollection.Add(question);
        }

        public void DeleteItem(QuestionAnswers question)
        {
            quizCollection.Remove(question);
        }

        public void Refresh(TextBox texBox)
        {
            filterText = texBox.Text;
            Quiz.Refresh();
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






    }
}
