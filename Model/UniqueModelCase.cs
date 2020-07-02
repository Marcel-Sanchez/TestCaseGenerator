using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Setting;

namespace Model
{
    public class UniqueModelCase
    {
        // Este diccionario me representa el número del caso contra una tupla de int que funciona como bool (arreglar).
        // La tupla representa si acertó para el caso del 3 y si acertó para el caso del 4.
        public Dictionary<int, (int, int)> Results;
        private Func<object, object, bool> _eq;
        private int _correctAns3count;
        private int _correctAns4count;

        public UniqueModelCase(Func<object, object, bool> eq)
        {
            Results = new Dictionary<int, (int, int)>();
            _eq = eq;
            _correctAns3count = 0;
            _correctAns4count = 0;
        }

        public UniqueModelCase(Dictionary<int, (int, int)> results, Func<object, object, bool> eq)
        {
            Results = new Dictionary<int, (int, int)>(results);
            _eq = eq;
            _correctAns3count = 0;
            _correctAns4count = 0;
            RecalculatePercentajes();
        }

        public void SplitCases(IList<object> answers, IList<object> correctAnswers, int Item)
        {
            if (Item == 1)
            {
                for (int i = 0; i < correctAnswers.Count; i++)
                {
                    if (_eq(correctAnswers[i], answers[i]))
                    {
                        Results[i + Sett.CaseNumber + 1] = (1, 0);
                        _correctAns3count++;
                    }
                    else
                    {
                        Results[i + Sett.CaseNumber + 1] = (0, 0);
                    }
                }
            }
            else
            {
                for (int j = 0; j < correctAnswers.Count; j++)
                {
                    if (_eq(correctAnswers[j], answers[j]))
                    {
                        Results[j + Sett.CaseNumber + 1] = (Results[j + Sett.CaseNumber + 1].Item1, 1);
                        _correctAns4count++;
                    }
                }
                Sett.CaseNumber += Results.Count;
            }
        }

        public void RemoveCase(int caseToRemove)
        {
            var res = Results[caseToRemove];
            //Console.WriteLine(res);
            _correctAns3count -= res.Item1;
            _correctAns4count -= res.Item2;

            Results.Remove(caseToRemove);
        }

        public (float, float) GetPercentajes()
        {
            return ((float)_correctAns3count / Results.Count * 100, (float)_correctAns4count / Results.Count * 100);
        }

        public (float, float) GetPercentajeIfRemove(int caseToRemove)
        {
            var res = Results[caseToRemove];
            float newcorrectAns3count = _correctAns3count - res.Item1;
            float newcorrectAns4count = _correctAns4count - res.Item2;

            return (newcorrectAns3count / (Results.Count - 1) * 100, newcorrectAns4count / (Results.Count - 1) * 100);
        }

        public void RecalculatePercentajes()
        {
            _correctAns3count = Results.Count(p => p.Value.Item1 == 1);
            _correctAns4count = Results.Count(p => p.Value.Item2 == 1);
        }

        public void Merge(UniqueModelCase other)
        {
            foreach (var item in other.Results)
            {
                Results.Add(item.Key, item.Value);
            }
            _correctAns3count += other._correctAns3count;
            _correctAns4count += other._correctAns4count;
        }
    }
}
