using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Model
    {
        public string Method;
        public Queue<dynamic> Sols;
        public List<dynamic> OkSols;
        public List<dynamic> BadSols;
        public int Percentaje { get { return (int)(OkSols.Count / ((float)OkSols.Count + BadSols.Count) * 100); } }

        public Model(string methodName)
        {
            Method = methodName;
            Sols = new Queue<dynamic>();
            OkSols = new List<dynamic>();
            BadSols = new List<dynamic>();
        }

        public void SplitCases(IEnumerable<dynamic> correctAnswers, Func<dynamic, dynamic, bool> eq)
        {
            foreach (var answer in correctAnswers)
            {
                var solution = Sols.Dequeue();
                if (eq(solution, answer))
                    OkSols.Add(solution);
                else
                    BadSols.Add(solution);
            }
        }
    }
}
