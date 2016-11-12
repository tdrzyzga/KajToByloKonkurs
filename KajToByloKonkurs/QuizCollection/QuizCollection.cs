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

        private ObservableCollection<QuestionAnswers> quizCollection;
        private string filterText;

        public QuizCollection()
        {
            quizCollection = new ObservableCollection<QuestionAnswers>();
            
            Quiz = CollectionViewSource.GetDefaultView(quizCollection);
            Quiz.Filter = questionSearch;

            PropertyGroupDescription groupDescription = new PropertyGroupDescription("CategoryName");
            Quiz.GroupDescriptions.Add(groupDescription);
        }

        public void AddItem(QuestionAnswers question)
        {
            quizCollection.Add(question);
        }

        public void RemoveItem(QuestionAnswers question)
        {
            quizCollection.Remove(question);
        }

        public void Refresh(TextBox texBox)
        {
            filterText = texBox.Text;
            Quiz.Refresh();
        }

        public void RefreshSingleItem(QuestionAnswers question)
        {
           int index = quizCollection.IndexOf(question);
           quizCollection.Insert(index, question);
        }

        public void Clear()
        {
            quizCollection.Clear();
        }

        private bool questionSearch(object item)
        {
            QuizQuestionAnswers question = item as QuizQuestionAnswers;

            if (filterText == null || question.Question.Question.Contains(filterText))
                return true;
            else
                return false;
        }
    }
}








