using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using IFace;
using Model;
using Setting;

namespace Metaheuristic
{
    public class GRASP : CaseSolver
    {
        public override UniqueModelCase Run(UniqueModelCase model)
        {
            var result = new UniqueModelCase(model.Results, model._eq);
            CheckCases(result.Results.Values);
            //Console.WriteLine();
            // Obtengo la lista de canditados a eliminar de los casos de prueba.
            // Un caso de prueba es candidato si mejora la evaluacíón de la función objetivo.
            var percentajes = result.GetPercentajes();
            float funcEval = Sett.TargetFunc(percentajes.Item1, percentajes.Item2);

            //var cases = models[Setting.PosSolution5].Sols.ToList();

            List<int> candidates = GetCandidates(result, funcEval);

            //Console.WriteLine($"Count candidates: {candidates.Count}");

            // Mientras pueda mejorar la evalución de la función (> 0) y tenga candidatos a eliminar.
            //int i = 0;
            while (candidates.Count > 0 && funcEval != 0)
            {
                // Selecciono un candidato random a eliminar.
                var caseToDelete = candidates[Sett.Rnd.Next(candidates.Count)];
                result.RemoveCase(caseToDelete);

                //Console.WriteLine($"Antes de eliminar: {funcEval}");

                // Elimino el caso y actualizo la evaluación de la función objetivo.
                percentajes = result.GetPercentajes();
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
                candidates = GetCandidates(result, funcEval);
                //Console.WriteLine($"Count candidates: {candidates.Count}");
            }
            percentajes = result.GetPercentajes();
            funcEval = Sett.TargetFunc(percentajes.Item1, percentajes.Item2);
            Console.WriteLine($"Final diference: {funcEval}");
            CheckCases(result.Results.Values);
            return result;
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

        public static void CheckCases(IEnumerable<(int, int)> values)
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
