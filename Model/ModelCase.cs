using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ModelCase
    {
        public string Method;
        public List<object> Sols;
        public List<object> OkSols;
        public List<object> BadSols;
        // Comparador de 2 soluciones.
        public Func<object, object, bool> Eq;
        public List<int> RemovedIndexs;
        public float Percentaje { get { return (OkSols.Count / ((float)OkSols.Count + BadSols.Count) * 100); } }

        public ModelCase(string methodName, Func<object, object, bool> eq)
        {
            Method = methodName;
            Sols = new List<object>();
            OkSols = new List<object>();
            BadSols = new List<object>();
            Eq = eq;
            RemovedIndexs = new List<int>();
        }
        // Separa en soluciones correctas y erradas.
        public void SplitCases(IEnumerable<object> correctAnswers)
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

        public void RemoveCase(object caseToRemove)
        {
            // Para eliminar de los ejemplos totales.
            for (int i = 0; i < Sols.Count; i++)
            {
                if (Eq(Sols[i], caseToRemove))
                {
                    Sols.RemoveAt(i);
                    RemovedIndexs.Add(i);
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
        public float DiferenceIfRemoveCase(object caseToRemove)
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
