using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Setting;
using Model;
using Implementations;
using System.IO;

namespace Metaheuristic
{
    public static class Genetic_Algorithm
    {
        //public static List<UniqueModelCase> Solutions;

        public static UniqueModelCase Run(UniqueModelCase model)
        {
            var modelSplited = SplitModel(model);
            // Solo para poderle aplicar lambda.
            var solutionsList = new List<UniqueModelCase>(modelSplited);
            //ReamkeKeys(Solutions);
            var percentajes = solutionsList.Select(p => p.GetPercentajes());
            var evals = percentajes.Select(p => Sett.TargetFunc(p)).ToArray();

            int n = 0;
            while (n++ < 200 && evals.All(p => p > 1))
            {
                string p = Directory.GetCurrentDirectory() + @"\" + "GenFO1.txt";
                using (StreamWriter file = new StreamWriter(p, true))
                {
                    file.WriteLine($"Menor evaluación {evals.Min()}");
                    file.WriteLine($"Evaluación media {evals.Average()}");
                    file.WriteLine($"Iteración {n}");

                    file.WriteLine();
                }

                percentajes = solutionsList.Select(k => k.GetPercentajes());
                evals = percentajes.Select(k => Sett.TargetFunc(k)).ToArray();

                var couple1Indexs = MergeAndFind.Find2Bests(evals);
                var couple2Indexs = MergeAndFind.Find2Random(evals);

                var c1x = solutionsList[couple1Indexs.Item1];
                var c1y = solutionsList[couple1Indexs.Item2];

                var c2x = solutionsList[couple2Indexs.Item1];
                var c2y = solutionsList[couple2Indexs.Item2];

                var resultc1A = MergeAndFind.Merge1(c1x.Results, c1y.Results);
                var resultc1B = MergeAndFind.Merge2(c1x.Results, c1y.Results);
                var resultc1C = MergeAndFind.Merge3(c1x.Results, c1y.Results);
                var resultc1D = MergeAndFind.Merge4(c1x.Results, c1y.Results, (int)((float)c1x.Results.Count * 80 / 100), (int)((float)c2y.Results.Count * 20 / 100));

                var resultc2A = MergeAndFind.Merge1(c2x.Results, c2y.Results);
                var resultc2B = MergeAndFind.Merge2(c2x.Results, c2y.Results);
                var resultc2C = MergeAndFind.Merge3(c2x.Results, c2y.Results);
                var resultc2D = MergeAndFind.Merge4(c2x.Results, c2y.Results, (int)((float)c2x.Results.Count * 80 / 100), (int)((float)c2y.Results.Count * 20 / 100));

                var c1 = new UniqueModelCase(resultc1A, SolutionComparer.F);
                var c2 = new UniqueModelCase(resultc1B, SolutionComparer.F);
                var c3 = new UniqueModelCase(resultc1C, SolutionComparer.F);
                var c4 = new UniqueModelCase(resultc1D, SolutionComparer.F);

                var c5 = new UniqueModelCase(resultc2A, SolutionComparer.F);
                var c6 = new UniqueModelCase(resultc2B, SolutionComparer.F);
                var c7 = new UniqueModelCase(resultc2C, SolutionComparer.F);
                var c8 = new UniqueModelCase(resultc2D, SolutionComparer.F);

                var newSolutions = new UniqueModelCase[] { c1, c2, c3, c4, c5, c6, c7, c8 };
                solutionsList.AddRange(newSolutions);

                var newPercentajes = solutionsList.Select(k => k.GetPercentajes());
                var newEvals = newPercentajes.Select(k => Sett.TargetFunc(k)).ToList();

                for (int i = 0; i < 4; i++)
                {
                    int index = Filter(newEvals);
                    solutionsList.RemoveAt(index);
                    newEvals.RemoveAt(index);
                }
                
                //Console.WriteLine($"Menor evaluación {evals.Min()}");
                //Console.WriteLine($"Evaluación media {evals.Average()}");
                //Console.WriteLine();
            }
            var min = evals.Min();
            Console.WriteLine($"Menor evaluación {min}");
            return model = solutionsList.First(p => Sett.TargetFunc(p.GetPercentajes()) == min);
            //foreach (var item in Solutions)
            //{

            //    Console.WriteLine($"{item.GetPercentajes()}");
            //}
        }

        private static IEnumerable<UniqueModelCase> SplitModel(UniqueModelCase model)
        {
            int n = 5;
            UniqueModelCase[] modelArray = new UniqueModelCase[n];
            for (int i = 0; i < n; i++)
            {
                modelArray[i] = new UniqueModelCase(SolutionComparer.F);
            }
            foreach (var k in model.Results.Keys)
            {
                modelArray[k % n].AddCase(k, model.Results[k]);
            }
            return modelArray;
        }

        private static int Filter(List<float> solutions)
        {
            int indexMax = -1;
            float max = int.MinValue;
            for (int i = 0; i < solutions.Count; i++)
            {
                if (solutions[i] > max)
                {
                    max = solutions[i];
                    indexMax = i;
                }
            }
            return indexMax;
        }

        private static void ReamkeKeys(List<UniqueModelCase> Solutions)
        {
            for (int i = 0; i < Solutions.Count; i++)
            {
                Solutions[i].Results = Solutions[i].Results.ToDictionary(p => int.Parse(p.Key + i.ToString()), p => p.Value);
            }
        }
    }

    public static class MergeAndFind
    {
        // Mezcla alternado. En la primera iteración no, pero en las demás puede que a y b tengan elementos iguales entre sí.
        public static Dictionary<int, (int, int)> Merge1(Dictionary<int, (int, int)> a, Dictionary<int, (int, int)> b)
        {
            Dictionary<int, (int, int)> result = new Dictionary<int, (int, int)>();
            var aArray = a.ToArray();
            var bArray = b.ToArray();
            for (int i = 0; i < aArray.Length; i += 2)
            {
                var keyVal = aArray[i];
                result.Add(keyVal.Key, keyVal.Value);
            }
            for (int i = 1; i < bArray.Length; i += 2)
            {
                var keyVal = bArray[i];
                if (!result.ContainsKey(keyVal.Key))
                    result.Add(keyVal.Key, keyVal.Value);
            }
            return result;
        }
        // Mezcla n/2 de 'a' y m/2 de 'b'. 
        public static Dictionary<int, (int, int)> Merge2(Dictionary<int, (int, int)> a, Dictionary<int, (int, int)> b)
        {
            Dictionary<int, (int, int)> result = new Dictionary<int, (int, int)>();
            var aArray = a.ToArray();
            var bArray = b.ToArray();
            for (int i = 0; i < a.Count / 2; i++)
            {
                var keyVal = aArray[i];
                result.Add(keyVal.Key, keyVal.Value);
            }
            for (int i = b.Count / 2; i < b.Count; i++)
            {
                var keyVal = bArray[i];
                if (!result.ContainsKey(keyVal.Key))
                    result.Add(keyVal.Key, keyVal.Value);
            }
            return result;
        }
        // Unión random de miembros de a y b .
        public static Dictionary<int, (int, int)> Merge3(Dictionary<int, (int, int)> a, Dictionary<int, (int, int)> b)
        {
            Dictionary<int, (int, int)> result = new Dictionary<int, (int, int)>();
            var aArray = a.ToArray();
            var bArray = b.ToArray();
            bool[] maskA = new bool[aArray.Length];
            bool[] maskB = new bool[bArray.Length];
            int iter = 0;
            while (result.Count < (aArray.Length + bArray.Length) / 2 && iter++ < a.Count + b.Count)
            {
                int indexA = Sett.Rnd.Next(aArray.Length);
                int indexB = Sett.Rnd.Next(bArray.Length);
                if (!maskA[indexA])
                {
                    var keyVal = aArray[indexA];
                    if (!result.ContainsKey(keyVal.Key))
                        result.Add(keyVal.Key, keyVal.Value);
                    maskA[indexA] = true;
                }
                if (!maskB[indexB])
                {
                    var keyVal = bArray[indexB];
                    if (!result.ContainsKey(keyVal.Key))
                        result.Add(keyVal.Key, keyVal.Value);
                    maskB[indexB] = true;
                }
            }
            return result;
        }
        // Mezcla a*aClonateCount y b*bClonateCount.
        public static Dictionary<int, (int, int)> Merge4(Dictionary<int, (int, int)> a, Dictionary<int, (int, int)> b, int aClonateCount, int bClonateCount)
        {
            Dictionary<int, (int, int)> result = new Dictionary<int, (int, int)>();
            var aArray = a.ToArray();
            var bArray = b.ToArray();

            List<(int, (int, int))> temp1 = new List<(int, (int, int))>();
            bool[] maskA = new bool[a.Count];
            bool[] maskB = new bool[b.Count];

            while (temp1.Count < aClonateCount)
            {
                int indexA = Sett.Rnd.Next(a.Count);
                if (!maskA[indexA])
                {
                    var keyVal = aArray[indexA];
                    temp1.Add((keyVal.Key, keyVal.Value));
                    maskA[indexA] = true;
                }
            }
            List<(int, (int, int))> temp2 = new List<(int, (int, int))>();
            while (temp2.Count < bClonateCount)
            {
                int indexB = Sett.Rnd.Next(b.Count);
                if (!maskB[indexB])
                {
                    var keyVal = bArray[indexB];
                    temp2.Add((keyVal.Key, keyVal.Value));
                    maskB[indexB] = true;
                }
            }
            temp1.AddRange(temp2);

            foreach (var item in temp1)
            {
                if (!result.ContainsKey(item.Item1))
                    result.Add(item.Item1, item.Item2);
            }

            return result;
        }

        public static (int, int) Find2Bests(float[] a)
        {
            float max = -1, max2 = -1;
            int posMax = -1, posMax2 = -1;


            for (int i = 0; i < a.Length; i++)
            {
                var item = a[i];
                if (item > max)
                {
                    max2 = max;
                    posMax2 = posMax;
                    max = item;
                    posMax = i;
                }
                else if (item > max2)
                {
                    max2 = item;
                    posMax2 = i;
                }
            }
            return (posMax, posMax2);
        }

        public static (int, int) Find2Random(float[] a)
        {
            int i = -1, j = -1;
            while (i == j || i == -1 || j == -1)
            {
                i = Sett.Rnd.Next(a.Length);
                j = Sett.Rnd.Next(a.Length);
            }
            return (i, j);
        }
    }
}
