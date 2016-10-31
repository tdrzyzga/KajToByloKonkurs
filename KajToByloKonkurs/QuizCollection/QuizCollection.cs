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

        private ObservableCollection<QuestionAnswers> dictinaryQuizCollection;
        private string filterText;

        public QuizCollection()
        {
            dictinaryQuizCollection = new ObservableCollection<QuestionAnswers>();

            Quiz = new CollectionView(dictinaryQuizCollection);
            Quiz= (CollectionView)CollectionViewSource.GetDefaultView(dictinaryQuizCollection);
            Quiz.Filter = questionSearch;

            PropertyGroupDescription groupDescription = new PropertyGroupDescription("CategoryIndex");
            Quiz.GroupDescriptions.Add(groupDescription);

        }

        public void AddItemsToCollections(QuestionAnswers question)
        {
            dictinaryQuizCollection.Add(question);
        }

        public void DeleteItem(QuestionAnswers question)
        {
            dictinaryQuizCollection.Remove(question);
           /* foreach (var i in dictinaryQuizCollection)
            {
              
                if (i.Value.Exists(x=> x == question))
                {
                    i.Value.Remove(question);
                    break;
                }
            }*/

        }

        public void Refresh(TextBox texBox)
        {
            filterText = texBox.Text;
            Quiz.Refresh();
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
