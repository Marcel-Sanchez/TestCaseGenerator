using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Generator;
using Setting;
using Metaheuristic;
using Implementations;
using Model;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generador de casos de prueba aleatorios.
            var generator = new CaseGenerator();
            // Método que me genera n casos de prueba.
            var cases = generator.GenerateCases(500);

            // Array de tamaño cantidad de implementaciones pasadas. En este caso, en la dll hay una implementación de 3, 4 y 5.
            var models = new ModelCase[Sett.MethodNames.Length];

            // Inicializo cada Modelo (clase auxiliar para guardar datos de las implementaciones).
            for (int i = 0; i < Sett.MethodNames.Length; i++)
            {
                models[i] = new ModelCase(Sett.MethodNames[i], SolutionComparer.F);
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
                foreach (var methodName in Sett.MethodNames)
                {
                    // Llamo a la dll donde se encuantran las implementaciones y corro el caso de prueba actual en cada método suministrado. En este caso, la dll debe estar en el directorio actual.
                    object result = CallDllMethod(Directory.GetCurrentDirectory(), Sett.DllName, Sett.ClassName, methodName, cas.ToArray(), new List<object>().ToArray());

                    //Console.WriteLine($"Resultado vía {methodName}: " + string.Join(" ", result));

                    // Añado la solución obtenida.
                    models[posModel++].Sols.Add(result);
                }
                //Console.WriteLine("---");
            }
            //Console.WriteLine("---");

            // Separo en casos de acierto y en casos de error para cada implementación.
            models[0].SplitCases(models[Sett.PosSolution5].Sols);
            models[1].SplitCases(models[Sett.PosSolution5].Sols);

            // Calculo el % de acierto.
            float obtained3 = models[0].Percentaje;
            float obtained4 = models[1].Percentaje;

            Console.WriteLine($"Model 3: {obtained3}%");
            Console.WriteLine($"Model 4: {obtained4}%");
            //Console.WriteLine($"Model 5: 100%");

            // Calculo las diferencias con los valores esperados.
            float dif3 = Sett.excepted3 - obtained3;
            float dif4 = Sett.excepted4 - obtained4;

            Console.WriteLine($"Diference 3: {dif3}");
            Console.WriteLine($"Diference 4: {dif4}");

            // Evaluación de la función objetivo a minimizar.
            float targetFunEvaluation = Sett.TargetFunc(obtained3, obtained4);
            Console.WriteLine($"Total diference: {targetFunEvaluation}");

            Console.WriteLine();

            // Aplico una versión de Greedy Randomized Adaptive Search Procedures
            GRASP.Run(models);

            var finalCases = cases.ToList();

            foreach (var index in models[2].RemovedIndexs)
            {
                finalCases.RemoveAt(index);
            }
            Console.WriteLine();
            Console.WriteLine($"Cantidad de casos finales: {finalCases.Count}");
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

            // 5. Le paso los parámetros al método y devuelvo la salida.
            return methodInfo.Invoke(instance, methodArgs);
        }
    }
}
