using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KajToBylo
{
    [Serializable]
    public class Category
    {
        private List<QuestionAnswers> listQuestionAnswers;
        private QuestionComparer questionComparer;

        public Category()
        {
            listQuestionAnswers = new List<QuestionAnswers>();
            questionComparer = new QuestionComparer();
        }

        public void AddQuestion(QuestionAnswers question)
        {
            listQuestionAnswers.Add(question);

            listQuestionAnswers.Sort(questionComparer);
        }

        public List<QuestionAnswers> ReturnListQuestions()
        {
            return listQuestionAnswers;
        }

        public void AddQuestionRange(Category category)
        {
            foreach (var i in category.ReturnListQuestions())
                listQuestionAnswers.Add(i);

            listQuestionAnswers.Sort(questionComparer);
        }

        public void RemoveQuestion(QuestionAnswers question)
        {
            listQuestionAnswers.Remove(question);
        }
        
        public void ChangeQuestion(QuestionAnswers questionBeforeChanges, QuestionAnswers questionAfterChanges)
        {
            listQuestionAnswers[listQuestionAnswers.IndexOf(questionBeforeChanges)] = questionAfterChanges;
        }

        public void ResetAddedToQuiz()
        {
            foreach (var question in listQuestionAnswers)
                question.AddedToQuizCollection = false;
        }
        
    }
}
