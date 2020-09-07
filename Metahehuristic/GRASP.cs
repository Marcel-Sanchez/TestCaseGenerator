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
            // Obtengo la lista de canditados a eliminar de los casos de prueba.
            // Un caso de prueba es candidato si mejora la evaluacíón de la función objetivo.
            var percentajes = result.GetPercentajes();
            float funcEval = Sett.TargetFunc(percentajes.Item1, percentajes.Item2);

            List<int> candidates = GetCandidates(result, funcEval);

            // Mientras pueda mejorar la evalución de la función (> 0) y tenga candidatos a eliminar.
            int n = 500;
            while (candidates.Count > 0 && n-- > 0)
            {
                // Selecciono un candidato random a eliminar.
                var caseToDelete = candidates[Sett.Rnd.Next(candidates.Count)];
                result.RemoveCase(caseToDelete);

                // Elimino el caso y actualizo la evaluación de la función objetivo.
                percentajes = result.GetPercentajes();
                funcEval = Sett.TargetFunc(percentajes.Item1, percentajes.Item2);

                // Obtengo la nueva lista de candidatos.
                candidates = GetCandidates(result, funcEval);
                //Console.WriteLine($"Count candidates: {candidates.Count}");
            }
            percentajes = result.GetPercentajes();
            funcEval = Sett.TargetFunc(percentajes.Item1, percentajes.Item2);
            Console.WriteLine($"Final diference: {funcEval}");

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
