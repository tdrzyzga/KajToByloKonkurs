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
        public MainWindow.IndexCategory CategoryIndex { get; private set; }
        public string CategoryName { get; private set; }

        public string Question { get; private set; }
        public Tuple<bool, string> ResponseA { get; private set; }
        public Tuple<bool, string> ResponseB { get; private set; }
        public Tuple<bool, string> ResponseC { get; private set; }
        public Tuple<bool, string> ResponseD { get; private set; }

        public DateTime GeneratedData { get; private set; }
        public bool Used { get; set; }
        public bool AddedToQuizCollection { get; set; }

        public QuestionAnswers(MainWindow.IndexCategory indexCategory, string question, Tuple<bool, string> answerA, Tuple<bool, string> answerB, Tuple<bool, string> answerC, Tuple<bool, string> answerD, DateTime dateTime, bool used = false)
        {
            CategoryIndex = indexCategory;
            CategoryName = MainWindow.NameCategory[(int)CategoryIndex];
            Question = question;
   
            ResponseA = answerA;
            ResponseB = answerB;
            ResponseC = answerC;
            ResponseD = answerD;

            GeneratedData = dateTime;
            Used = used;
            AddedToQuizCollection = false;
        }

        public override string ToString()
        {
            string question ="\n" + Question + "\n" + " a) " + ResponseA + "\n" + " b) " + ResponseB + "\n" + " c) " + ResponseC + "\n" + " d) " + ResponseD;
            return question;
        }
    }
}
