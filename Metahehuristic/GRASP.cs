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
            Helper.CheckCases(result.Results.Values);
            //Console.WriteLine();
            // Obtengo la lista de canditados a eliminar de los casos de prueba.
            // Un caso de prueba es candidato si mejora la evaluacíón de la función objetivo.
            var percentajes = result.GetPercentajes();
            float funcEval = Sett.TargetFunc(percentajes.Item1, percentajes.Item2);

            //var cases = models[Setting.PosSolution5].Sols.ToList();

            List<int> candidates = GetCandidates(result, funcEval);

            //Console.WriteLine($"Count candidates: {candidates.Count}");

            // Mientras pueda mejorar la evalución de la función (> 0) y tenga candidatos a eliminar.
            int n = 500;
            while (candidates.Count > 0 && n-- > 0)
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

                
                

                //Console.WriteLine($"Después de eliminar: {funcEval}");
                //Console.WriteLine($"Current diference: {Setting.TargetFunc(models[0].Percentaje, models[1].Percentaje)}");
                //Console.WriteLine();

                // Obtengo la nueva lista de candidatos.
                candidates = GetCandidates(result, funcEval);
                //Console.WriteLine($"Count candidates: {candidates.Count}");

                //string p = Directory.GetCurrentDirectory() + @"\" + "Calls GRASP.txt";
                //using (StreamWriter file = new StreamWriter(p, true))
                //{
                //    file.Write($"{Sett.calls - Sett.callsAux}, ");
                //    Sett.callsAux = Sett.calls;
                //}
                //p = Directory.GetCurrentDirectory() + @"\" + "Evals f GRASP.txt";
                //using (StreamWriter file = new StreamWriter(p, true))
                //{
                //    file.Write($"{funcEval}, ");
                //}
            }
            percentajes = result.GetPercentajes();
            funcEval = Sett.TargetFunc(percentajes.Item1, percentajes.Item2);
            Console.WriteLine($"Final diference: {funcEval}");
            //Sett.calls = Sett.callsAux;

            string px = Directory.GetCurrentDirectory() + @"\" + "Calls GRASP.txt";
            string py = Directory.GetCurrentDirectory() + @"\" + "Evals f GRASP.txt";
            //while (n-- > 0)
            //{

            //    using (StreamWriter file = new StreamWriter(px, true))
            //    {
            //        file.Write($"{0}, ");
            //    }


            //    using (StreamWriter file = new StreamWriter(py, true))
            //    {
            //        file.Write($"{funcEval}, ");
            //    }
            //}

            Helper.CheckCases(result.Results.Values);
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
    }
}
