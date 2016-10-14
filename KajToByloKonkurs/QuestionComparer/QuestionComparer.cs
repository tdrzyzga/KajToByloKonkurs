using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KajToBylo
{
    [Serializable]
    class QuestionComparer: IComparer<QuestionAnswers>
    {
        public int Compare(QuestionAnswers a, QuestionAnswers b)
        {
            if (!a.Used && !b.Used)
            {
                if (a.GeneratedData < b.GeneratedData)
                    return 1;
                else
                    return -1;
            }

            else if (a.Used && !b.Used)
                return 1;
            else if (!a.Used && b.Used)
                return -1;
            else if (a.Used && b.Used)
            {
                if (a.GeneratedData < b.GeneratedData)
                    return -1;
                else
                    return 1;
            }

            return 0;
        }
    }
}
