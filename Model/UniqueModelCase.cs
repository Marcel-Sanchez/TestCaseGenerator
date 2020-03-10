using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Model
{
    public class UniqueModelCase
    {
        public Dictionary<int, (int, int)> Results;
        public Func<object, object, bool> Eq;
        private int correctAns3count;
        private int correctAns4count;

        public UniqueModelCase(Func<object, object, bool> eq)
        {
            Results = new Dictionary<int, (int, int)>();
            Eq = eq;
            correctAns3count = 0;
            correctAns4count = 0;
        }

        public void SplitCases(IList<object> answers, IList<object> correctAnswers, int Item)
        {
            if (Item == 1)
            {
                for (int i = 0; i < correctAnswers.Count; i++)
                {
                    if (Eq(correctAnswers[i], answers[i]))
                    {
                        Results[i] = (1, 0);
                        correctAns3count++;
                    }
                    else
                    {
                        Results[i] = (0, 0);
                    }
                }
            }
            else
            {
                for (int j = 0; j < correctAnswers.Count; j++)
                {
                    if (Eq(correctAnswers[j], answers[j]))
                    {
                        Results[j] = (Results[j].Item1, 1);
                        correctAns4count++;
                    }
                }
            }
        }

        public void RemoveCase(int caseToRemove)
        {
            var res = Results[caseToRemove];
            correctAns3count -= res.Item1;
            correctAns4count -= res.Item2;

            Results.Remove(caseToRemove);
        }

        public (float, float) GetPercentajes()
        {
            return ((float)correctAns3count / Results.Count * 100, (float)correctAns4count / Results.Count * 100) ;
        }

        public (float, float) GetPercentajeIfRemove(int caseToRemove)
        {
            var res = Results[caseToRemove];
            float newcorrectAns3count = correctAns3count - res.Item1;
            float newcorrectAns4count = correctAns4count - res.Item2;

            return (newcorrectAns3count / (Results.Count - 1) * 100, newcorrectAns4count / (Results.Count - 1) * 100);
        }
    }
}
