using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace KajToBylo
{
    [Serializable]
    public class QuestionAnswers
    {
        public string Question { get; private set; }
        public KajToBylo.MainWindow.CorrectAnswer GoodAnswer { get; set; }
        public string ResponseA { get; private set; }
        public string ResponseB { get; private set; }
        public string ResponseC { get; private set; }
        public string ResponseD { get; private set; }
        public DateTime GeneratedData { get; private set; }
        public bool Used { get; set; }

        public QuestionAnswers(string question, MainWindow.CorrectAnswer correctAnswer, string answerA, string answerB, string answerC, string answerD, DateTime dateTime, bool used = false)
        {
            Question = question;

            GoodAnswer = correctAnswer;
            ResponseA = answerA;
            ResponseB = answerB;
            ResponseC = answerC;
            ResponseD = answerD;

            GeneratedData = dateTime;
            Used = used;
        }

        public override string ToString()
        {
            string[] Answers = { "a) " + ResponseA, "b) " + ResponseB, "c) " + ResponseC, "d) " + ResponseD };

            Answers[(int)GoodAnswer] = String.Format("[{0}]", Answers[(int)GoodAnswer]);

            if (Used)
                return "Było " + Question + "\n" + Answers[0] + "\t"+ Answers[1] + "\t" + Answers[2] + "\t" + Answers[3] + "  " + GoodAnswer;
            else
                return Question + "\n" + Answers[0] + "\t" + Answers[1] + "\t" + Answers[2] + "\t" + Answers[3] + "  " + GoodAnswer;
        }
    }
}