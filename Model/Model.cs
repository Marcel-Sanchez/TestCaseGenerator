using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Model
    {
        public string Method;
        public List<dynamic> Sols;
        public List<dynamic> OkSols;
        public List<dynamic> BadSols;
        // Comparador de 2 soluciones.
        public Func<dynamic, dynamic, bool> Eq;
        public float Percentaje { get { return (OkSols.Count / ((float)OkSols.Count + BadSols.Count) * 100); } }

        public Model(string methodName, Func<dynamic, dynamic, bool> eq)
        {
            Method = methodName;
            Sols = new List<dynamic>();
            OkSols = new List<dynamic>();
            BadSols = new List<dynamic>();
            Eq = eq;
        }
        // Separa en soluciones correctas y erradas.
        public void SplitCases(IEnumerable<dynamic> correctAnswers)
        {
            int i = 0;
            foreach (var answer in correctAnswers)
            {
                var solution = Sols[i++];
                if (Eq(solution, answer))
                    OkSols.Add(solution);
                else
                    BadSols.Add(solution);
            }
        }

        public void RemoveCase(dynamic caseToRemove)
        {
            // Para eliminar de los ejemplos totales.
            for (int i = 0; i < Sols.Count; i++)
            {
                if (Eq(Sols[i], caseToRemove))
                {
                    Sols.RemoveAt(i);
                }
            }
            // Para eliminar de las listas de acierto o error.
            for (int i = 0; i < OkSols.Count; i++)
            {
                if (Eq(OkSols[i], caseToRemove))
                {
                    OkSols.RemoveAt(i);
                    return;
                }
            }
            for (int i = 0; i < BadSols.Count; i++)
            {
                if (Eq(BadSols[i], caseToRemove))
                {
                    BadSols.RemoveAt(i);
                    return;
                }
            }

        }
        public float DiferenceIfRemoveCase(dynamic caseToRemove)
        {
            int ok = OkSols.Count;
            int bad = BadSols.Count;

            for(int i = 0; i < OkSols.Count; i++)
            {
                if (Eq(OkSols[i], caseToRemove))
                {
                    ok--;
                    break;
                }
            }
            for (int i = 0; i < BadSols.Count; i++)
            {
                if (Eq(BadSols[i], caseToRemove))
                {
                    bad--;
                    break;
                }
            }
            return (ok / ((float)ok + bad) * 100) - Percentaje;
        }
    }
}
