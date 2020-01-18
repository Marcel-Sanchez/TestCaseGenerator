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
            int[] case0 = { 0};
            int[] caseX = { 1, 2, 3 };
            int[][] aux = { case0, caseX };

            var generator = new Generator.Generator();
            var cases = generator.GenerateCases(500);
            //List<dynamic> results = new List<dynamic>();
            Console.WriteLine("---");

            var models = new Model.Model[Setting.MethodNames.Length];

            for (int i = 0; i < Setting.MethodNames.Length; i++)
            {
                models[i] = new Model.Model(Setting.MethodNames[i]);
            }

            // Por cada caso de prueba generado.
            foreach (var cas in cases)
            {

                // Escribo el caso de prueba actual.
                foreach (var pol in cas)
                {
                    Console.WriteLine("Polinomio: " + string.Join(" ", pol as int[]));
                }
                // Llamo a cada método que tenga con el caso de prueba actual.
                int posModel = 0;
                foreach (var methodName in Setting.MethodNames)
                {
                    dynamic result = CallDllMethod(Directory.GetCurrentDirectory(), Setting.DllName, Setting.ClassName, methodName, cas.ToArray(), new List<object>().ToArray());

                    Console.WriteLine($"Resultado vía {methodName}: " + string.Join(" ", result));

                    //results.Add(result);
                    models[posModel++].Sols.Enqueue(result);
                }
                Console.WriteLine("---");
            }
            //foreach (var pol in aux)
            //{
            //    Console.WriteLine("Polinomio: " + string.Join(" ", pol as int[]));
            //}
            //// Llamo a cada método que tenga con el caso de prueba actual.
            //int posModel2 = 0;
            //foreach (var methodName in Setting.MethodNames)
            //{
            //    dynamic result = CallDllMethod(Setting.DllImplPath, Setting.DllName, Setting.ClassName, methodName, aux.ToArray(), new List<object>().ToArray());

            //    Console.WriteLine($"Resultado vía {methodName}: " + string.Join(" ", result));

            //    //results.Add(result);
            //    models[posModel2++].Sols.Enqueue(result);
            //}
            Console.WriteLine("---");

            models[0].SplitCases(models[Setting.PosSolution5].Sols, SolutionComparer.F);
            models[1].SplitCases(models[Setting.PosSolution5].Sols, SolutionComparer.F);

            Console.WriteLine($"Model 3: {models[0].Percentaje}%");
            Console.WriteLine($"Model 4: {models[1].Percentaje}%");
            //Console.WriteLine($"Model 5: 100%");
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
