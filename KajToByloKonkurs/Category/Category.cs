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

        /*  public void Used(QuestionAnswers question)
          {
              var searchQuestion = listQuestionAnswers.Find(x => x.Question == question.Question);

              if (searchQuestion.Used == true)
                  listQuestionAnswers.Find(x => x.Question == question.Question).Used = false;
              else
                  listQuestionAnswers.Find(x => x.Question == question.Question).Used = true;
          }*/
    }
}
