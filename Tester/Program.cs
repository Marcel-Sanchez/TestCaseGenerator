using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Generator;
using Settings;
using Model;
using Implementations;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generador de casos de prueba aleatorios.
            var generator = new Generator.Generator();
            // Método que me genera n casos de prueba.
            var cases = generator.GenerateCases(1000);

            // Array de tamaño cantidad de implementaciones pasadas. En este caso, en la dll hay una implementación de 3, 4 y 5.
            var models = new Model.Model[Setting.MethodNames.Length];

            // Inicializo cada Modelo (clase auxiliar para guardar datos de las implementaciones).
            for (int i = 0; i < Setting.MethodNames.Length; i++)
            {
                models[i] = new Model.Model(Setting.MethodNames[i], SolutionComparer.F);
            }

            // Por cada caso de prueba generado.
            foreach (var cas in cases)
            {

                ////Escribo el caso de prueba actual.
                //foreach (var pol in cas)
                //{
                //    Console.WriteLine("Polinomio: " + string.Join(" ", pol as int[]));
                //}
                int posModel = 0;
                foreach (var methodName in Setting.MethodNames)
                {
                    // Llamo a la dll donde se encuantran las implementaciones y corro el caso de prueba actual en cada método suministrado. En este caso, la dll debe estar en el directorio actual.
                    dynamic result = CallDllMethod(Directory.GetCurrentDirectory(), Setting.DllName, Setting.ClassName, methodName, cas.ToArray(), new List<object>().ToArray());

                    //Console.WriteLine($"Resultado vía {methodName}: " + string.Join(" ", result));

                    // Añado la solución obtenida.
                    models[posModel++].Sols.Add(result);
                }
                //Console.WriteLine("---");
            }
            //Console.WriteLine("---");

            // Separo en casos de acierto y en casos de error para cada implementación.
            models[0].SplitCases(models[Setting.PosSolution5].Sols);
            models[1].SplitCases(models[Setting.PosSolution5].Sols);

            // Calculo el % de acierto.
            int obtained3 = models[0].Percentaje;
            int obtained4 = models[1].Percentaje;

            Console.WriteLine($"Model 3: {obtained3}%");
            Console.WriteLine($"Model 4: {obtained4}%");
            //Console.WriteLine($"Model 5: 100%");

            // Calculo las diferencias con los valores esperados.
            int dif3 = Setting.excepted3 - obtained3;
            int dif4 = Setting.excepted4 - obtained4;

            Console.WriteLine($"Diference 3: {dif3}");
            Console.WriteLine($"Diference 4: {dif4}");

            // Evaluación de la función objetivo a minimizar.
            int targetFunEvaluation = Setting.TargetFunc(obtained3, obtained4);
            Console.WriteLine($"Total diference: {targetFunEvaluation}");

            Console.WriteLine();

            // Aplico una versión de Greedy Randomized Adaptive Search Procedures
            GRASP(models);
        }

        private static void GRASP(Model.Model[] models)
        {
            Console.WriteLine();
            // Obtengo la lista de canditados a eliminar de los casos de prueba.
            // Un caso de prueba es candidato si mejora la evaluacíón de la función objetivo.
            var funcEval = Setting.TargetFunc(models[0].Percentaje, models[1].Percentaje);

            //var cases = models[Setting.PosSolution5].Sols.ToList();

            List<dynamic> candidates = GetCandidates(models, funcEval);
            
            Console.WriteLine($"Count candidates: {candidates.Count}");

            // Mientras pueda mejorar la evalución de la función (> 0) y tenga candidatos a eliminar.
            while (candidates.Count > 0 && funcEval != 0)
            {
                // Selecciono un candidato random a eliminar.
                var caseToDelete = candidates[Setting.Rnd.Next(candidates.Count)];
                candidates.Remove(caseToDelete);
                
                Console.WriteLine($"Antes de eliminar: {funcEval}");
                
                // Elimino el caso y actualizo la evaluación de la función objetivo.
                models[0].RemoveCase(caseToDelete);
                models[1].RemoveCase(caseToDelete);
                models[2].RemoveCase(caseToDelete);
                
                funcEval = Setting.TargetFunc(models[0].Percentaje, models[1].Percentaje);
                
                Console.WriteLine($"Después de eliminar: {Setting.TargetFunc(models[0].Percentaje, models[1].Percentaje)}");
                //Console.WriteLine($"Current diference: {Setting.TargetFunc(models[0].Percentaje, models[1].Percentaje)}");
                Console.WriteLine();
                
                // Obtengo la nueva lista de candidatos.
                candidates = GetCandidates(models, funcEval);
                Console.WriteLine($"Count candidates: {candidates.Count}");
            }
            Console.WriteLine($"Final diference: {Setting.TargetFunc(models[0].Percentaje, models[1].Percentaje)}");
        }

        private static List<dynamic> GetCandidates(Model.Model[] models, int targetFunEvaluation)
        {
            List<dynamic> candidates = new List<dynamic>();
            int obtained3 = models[0].Percentaje;
            int obtained4 = models[1].Percentaje;

            // Recorro la lista total de casos de prueba.
            foreach (var caseToRemove in models[Setting.PosSolution5].Sols.ToArray())
            {
                // Verifio si mejora la evaluación de la función objetivo.
                int ifRemove3 = models[0].DiferenceIfRemoveCase(caseToRemove);
                int ifRemove4 = models[1].DiferenceIfRemoveCase(caseToRemove);
                //Console.WriteLine($"Diference if remove case {k} in 3: {ifRemove3}");
                //Console.WriteLine($"Diference if remove case {k} in 4: {ifRemove4}");
                
                int newObtained3 = obtained3 + ifRemove3;
                int newObtained4 = obtained4 + ifRemove4;

                int newTargetFunEvaluation = Setting.TargetFunc(newObtained3, newObtained4);
                //Console.WriteLine($"New total diference = {newTargetFunEvaluation}");
                //Console.WriteLine();

                // Si la mejora entonces es candidato
                if (newTargetFunEvaluation < targetFunEvaluation)
                    candidates.Add(caseToRemove);
            }
            return candidates;
        }

        static object CallDllMethod(string dllPath, string dllName, string className, string methodName,
                                    object[] methodArgs, object[] contructorArgs)
        {
            string path = dllPath + @"\" + dllName + ".dll";
            // 1. Cargo "assembly.dll" usando el path.
            Assembly asm = Assembly.LoadFrom(path);
            Type type = asm.GetType(dllName + "." + className);

            // 2. Método a invocar
            var methodInfo = type.GetMethod(methodName, methodArgs.Select(p => p.GetType()).ToArray());
            if (methodInfo == null)
                return new NullReferenceException("No such method exists.");

            // 4. Creo la instancia.
            var instance = Activator.CreateInstance(type, contructorArgs);

            // 5. Le paso los parámetros al método y capturo la salida.
            var ret = methodInfo.Invoke(instance, methodArgs);
            return ret;
        }
    }
}
