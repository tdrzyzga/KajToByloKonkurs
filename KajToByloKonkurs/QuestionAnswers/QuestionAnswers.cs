﻿using System;
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
        public Tuple<bool, string> ResponseA { get; private set; }
        public Tuple<bool, string> ResponseB { get; private set; }
        public Tuple<bool, string> ResponseC { get; private set; }
        public Tuple<bool, string> ResponseD { get; private set; }
        public DateTime GeneratedData { get; private set; }
        public bool Used { get; set; }

        public QuestionAnswers(string question, Tuple<bool, string> answerA, Tuple<bool, string> answerB, Tuple<bool, string> answerC, Tuple<bool, string> answerD, DateTime dateTime, bool used = false)
        {
            Question = question;
   
            ResponseA = answerA;
            ResponseB = answerB;
            ResponseC = answerC;
            ResponseD = answerD;

            GeneratedData = dateTime;
            Used = used;
        }
    }
}
