using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Model;
using Setting;

namespace Metaheuristic
{
    public static class GRASP
    {
        public static void Run(UniqueModelCase model)
        {
            CheckCases(model.Results.Values);
            //Console.WriteLine();
            // Obtengo la lista de canditados a eliminar de los casos de prueba.
            // Un caso de prueba es candidato si mejora la evaluacíón de la función objetivo.
            var percentajes = model.GetPercentajes();
            float funcEval = Sett.TargetFunc(percentajes.Item1, percentajes.Item2);

            //var cases = models[Setting.PosSolution5].Sols.ToList();

            List<int> candidates = GetCandidates(model, funcEval);

            //Console.WriteLine($"Count candidates: {candidates.Count}");

            // Mientras pueda mejorar la evalución de la función (> 0) y tenga candidatos a eliminar.
            //int i = 0;
            while (candidates.Count > 0 && funcEval != 0)
            {
                // Selecciono un candidato random a eliminar.
                var caseToDelete = candidates[Sett.Rnd.Next(candidates.Count)];
                model.RemoveCase(caseToDelete);

                //Console.WriteLine($"Antes de eliminar: {funcEval}");

                // Elimino el caso y actualizo la evaluación de la función objetivo.
                //models[0].RemoveCase(caseToDelete);
                //models[1].RemoveCase(caseToDelete);
                //models[2].RemoveCase(caseToDelete);
                percentajes = model.GetPercentajes();
                funcEval = Sett.TargetFunc(percentajes.Item1, percentajes.Item2);
                //Console.WriteLine(funcEval);

                //var s = "";

                //string p = Directory.GetCurrentDirectory() + @"\" + "f3.txt";
                //using (StreamWriter file = new StreamWriter(p, true))
                //{
                //    //file.WriteLine($"percentajes: {percentajes}");
                //    file.Write($"{funcEval.ToString("00.00")}  ");
                //    i++;
                //    if (i == 20)
                //    {
                //        i = 0;
                //        file.WriteLine();
                //    }
                //    //file.WriteLine($"caseToDelete: {caseToDelete}");
                //}

                //Console.WriteLine($"Después de eliminar: {funcEval}");
                //Console.WriteLine($"Current diference: {Setting.TargetFunc(models[0].Percentaje, models[1].Percentaje)}");
                //Console.WriteLine();

                // Obtengo la nueva lista de candidatos.
                candidates = GetCandidates(model, funcEval);
                //Console.WriteLine($"Count candidates: {candidates.Count}");
            }
            percentajes = model.GetPercentajes();
            funcEval = Sett.TargetFunc(percentajes.Item1, percentajes.Item2);
            Console.WriteLine($"Final diference: {funcEval}");
            CheckCases(model.Results.Values);
        }

        public static List<int> GetCandidates(UniqueModelCase model, float targetFunEvaluation)
        {
            //Lista de los casos candidatos a remover (un índice del caso).
            List<int> candidates = new List<int>();
            var percentajes = model.GetPercentajes();
            var obtained3 = percentajes.Item1;
            var obtained4 = percentajes.Item2;

            // Recorro la lista total de casos de prueba.
            foreach (var caseToRemove in model.Results.Keys)
            {
                // Verifio si mejora la evaluación de la función objetivo.
                percentajes = model.GetPercentajeIfRemove(caseToRemove);
                float ifRemove3 = percentajes.Item1;
                float ifRemove4 = percentajes.Item2;
                //Console.WriteLine($"Diference if remove case {k} in 3: {ifRemove3}");
                //Console.WriteLine($"Diference if remove case {k} in 4: {ifRemove4}");

                //var newObtained3 = obtained3 + ifRemove3;
                //var newObtained4 = obtained4 + ifRemove4;

                float newTargetFunEvaluation = Sett.TargetFunc(ifRemove3, ifRemove4);
                //Console.WriteLine($"New total diference = {newTargetFunEvaluation}");
                //Console.WriteLine();

                // Si la mejora entonces es candidato
                if (newTargetFunEvaluation < targetFunEvaluation)
                    candidates.Add(caseToRemove);
            }
            return candidates;
        }

        private static void CheckCases(IEnumerable<(int, int)> values)
        {
            int cero = 0, uno = 0, dos = 0;
            foreach (var item in values)
            {
                if (item == (0, 0))
                    cero++;
                else if (item == (0, 1))
                    uno++;
                else
                    dos++;

            }
            string p = Directory.GetCurrentDirectory() + @"\" + "tipos.txt";
            using (StreamWriter file = new StreamWriter(p, true))
            {
                //file.WriteLine($"percentajes: {percentajes}");
                file.WriteLine($"cero: {cero}");
                file.WriteLine($"uno: {uno}");
                file.WriteLine($"dos: {dos}");
                file.WriteLine();
            }
        }
    }
}
