using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Setting;

namespace Metaheuristic
{
    public static class GRASP
    {
        public static void Run(ModelCase[] models)
        {
            Console.WriteLine();
            // Obtengo la lista de canditados a eliminar de los casos de prueba.
            // Un caso de prueba es candidato si mejora la evaluacíón de la función objetivo.
            float funcEval = Sett.TargetFunc(models[0].Percentaje, models[1].Percentaje);

            //var cases = models[Setting.PosSolution5].Sols.ToList();

            List<dynamic> candidates = GetCandidates(models, funcEval);

            Console.WriteLine($"Count candidates: {candidates.Count}");

            // Mientras pueda mejorar la evalución de la función (> 0) y tenga candidatos a eliminar.
            while (candidates.Count > 0 && funcEval != 0)
            {
                // Selecciono un candidato random a eliminar.
                var caseToDelete = candidates[Sett.Rnd.Next(candidates.Count)];
                candidates.Remove(caseToDelete);

                Console.WriteLine($"Antes de eliminar: {funcEval}");

                // Elimino el caso y actualizo la evaluación de la función objetivo.
                models[0].RemoveCase(caseToDelete);
                models[1].RemoveCase(caseToDelete);
                models[2].RemoveCase(caseToDelete);

                funcEval = Sett.TargetFunc(models[0].Percentaje, models[1].Percentaje);

                Console.WriteLine($"Después de eliminar: {Sett.TargetFunc(models[0].Percentaje, models[1].Percentaje)}");
                //Console.WriteLine($"Current diference: {Setting.TargetFunc(models[0].Percentaje, models[1].Percentaje)}");
                Console.WriteLine();

                // Obtengo la nueva lista de candidatos.
                candidates = GetCandidates(models, funcEval);
                Console.WriteLine($"Count candidates: {candidates.Count}");
            }
            Console.WriteLine($"Final diference: {Sett.TargetFunc(models[0].Percentaje, models[1].Percentaje)}");
        }

        public static List<dynamic> GetCandidates(ModelCase[] models, float targetFunEvaluation)
        {
            List<dynamic> candidates = new List<dynamic>();
            var obtained3 = models[0].Percentaje;
            var obtained4 = models[1].Percentaje;

            // Recorro la lista total de casos de prueba.
            foreach (var caseToRemove in models[Sett.PosSolution5].Sols.ToArray())
            {
                // Verifio si mejora la evaluación de la función objetivo.
                float ifRemove3 = models[0].DiferenceIfRemoveCase(caseToRemove);
                float ifRemove4 = models[1].DiferenceIfRemoveCase(caseToRemove);
                //Console.WriteLine($"Diference if remove case {k} in 3: {ifRemove3}");
                //Console.WriteLine($"Diference if remove case {k} in 4: {ifRemove4}");

                var newObtained3 = obtained3 + ifRemove3;
                var newObtained4 = obtained4 + ifRemove4;

                float newTargetFunEvaluation = Sett.TargetFunc(newObtained3, newObtained4);
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
