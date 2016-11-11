using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KajToBylo
{
    class QuizQuestionAnswers
    {
        public int Index { get; private set; }
        public QuestionAnswers Question { get; private set; }

        public QuizQuestionAnswers(int index, QuestionAnswers question)
        {
            Index = index;
            Question = question;
        }
    }
}
