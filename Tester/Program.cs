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
            //Helper.WriteFormatedCases();
            //// Generador de casos de prueba aleatorios.
            //var generator = new CaseGenerator();
            ////Método que me genera n casos de prueba.
            ////if (generate)
            ////{
            ////var cases = generator.GenerateCases(Sett.CasesToGenerate);
            ////SaveData(cases, "Cases.txt");

            //var cases = ReadPolData();
            var cases = ReadAnaData();
            ////}

            List<object> sols3 = new List<object>();
            List<object> sols4 = new List<object>();
            List<object> sols5 = new List<object>();
            List<object>[] sols = new List<object>[] { sols3, sols4, sols5 };

            //RunPolCases(cases, sols, Sett.MethodPolNames);
            RunAnaCases(cases, sols, Sett.MethodAnaNames);
            //Console.WriteLine("---");

            UniqueModelCase model = new UniqueModelCase(SolutionComparer.EqAna);
            //UniqueModelCase model = new UniqueModelCase(SolutionComparer.EqPol);

            // Separo en casos de acierto y en casos de error para cada implementación.
            model.SplitCases(sols3, sols5, 1);
            model.SplitCases(sols4, sols5, 2);

            // Calculo el % de acierto.
            var obtained = model.GetPercentajes();
            var obtained3 = obtained.Item1;
            var obtained4 = obtained.Item2;

            Console.WriteLine($"Model 3: {obtained3}%");
            Console.WriteLine($"Model 4: {obtained4}%");
            //Console.WriteLine($"Model 5: 100%");

            // Evaluación de la función objetivo a minimizar.
            float targetFunEvaluation = Sett.TargetFunc(obtained3, obtained4);
            Console.WriteLine($"Total diference: {targetFunEvaluation}");

            Console.WriteLine(model.Results.Count);

            //Sett.calls = 0;

            //var grasp = new GRASP();
            //model = grasp.Run(model);


            var ga = new GeneticAlgorithm();
            model = ga.Run(model);

            obtained = model.GetPercentajes();
            obtained3 = obtained.Item1;
            obtained4 = obtained.Item2;

            Console.WriteLine($"Model 3: {obtained3}%");
            Console.WriteLine($"Model 4: {obtained4}%");
            targetFunEvaluation = Sett.TargetFunc(obtained3, obtained4);


            Console.WriteLine(model.Results.Count);

            //Helper.CheckCases(model.Results.Values);

            //var finalCases = Helper.GetFinalCases(cases, model.Results.Keys);
            //Helper.WriteFinalCases(finalCases);

            //Console.WriteLine(string.Join("\n", finalCases));

            //int i = 0;
            //string p = Directory.GetCurrentDirectory() + @"\" + "3.txt";
            //using (StreamWriter file = new StreamWriter(p, false))
            //{
            //    foreach (var k in model.Results.Keys)
            //    {
            //        var s = "";
            //        if (k < 10)
            //            s = "00";
            //        else if (k < 100)
            //            s = "0";
            //        file.Write(s + k + " ");
            //        i++;
            //        if(i == 20)
            //        {
            //            i = 0;
            //            file.WriteLine();
            //        }
            //    }
            //}
        }

        private static void RunPolCases(IEnumerable<IEnumerable<object>> cases, List<object>[] sols, string[] MethodNames)
        {
            foreach (var cas in cases)
            {
                // Por cada caso de prueba generado.
                ////Escribo el caso de prueba actual.
                //foreach (var pol in cas)
                //{
                //    Console.WriteLine("Polinomio: " + string.Join(" ", pol as int[]));
                //}
                int posModel = 0;
                foreach (var methodName in MethodNames)
                //foreach (var methodName in Sett.MethodAnaNames)
                {
                    // Llamo a la dll donde se encuantran las implementaciones y corro el caso de prueba actual en cada método suministrado. En este caso, la dll debe estar en el directorio actual.
                    object result = CallDllMethod(Directory.GetCurrentDirectory(), Sett.DllName, Sett.ClassPolName, methodName, cas.ToArray(), new List<object>().ToArray());

                    //Console.WriteLine($"Resultado vía {methodName}: " + string.Join(" ", result));
                    // Añado la solución obtenida.
                    sols[posModel++].Add(result);
                }
                //Console.WriteLine("---");
            }
        }
        private static void RunAnaCases(IEnumerable<object> cases, List<object>[] sols, string[] MethodNames)
        {
            foreach (var cas in cases)
            {
                // Por cada caso de prueba generado.
                ////Escribo el caso de prueba actual.
                //foreach (var pol in cas)
                //{
                //    Console.WriteLine("Polinomio: " + string.Join(" ", pol as int[]));
                //}
                int posModel = 0;
                foreach (var methodName in MethodNames)
                //foreach (var methodName in Sett.MethodAnaNames)
                {
                    // Llamo a la dll donde se encuantran las implementaciones y corro el caso de prueba actual en cada método suministrado. En este caso, la dll debe estar en el directorio actual.
                    object result = null;
                    try
                    {
                        result = CallDllMethod(Directory.GetCurrentDirectory(), Sett.DllName, Sett.ClassAnaName, methodName, new object[] { cas }, new List<object>().ToArray());
                    }
                    catch
                    {
                        result = -1;
                    }

                    //Console.WriteLine($"Resultado vía {methodName}: " + string.Join(" ", result));
                    // Añado la solución obtenida.
                    sols[posModel++].Add(result);
                }
                //Console.WriteLine("---");
            }
        }

        private static IEnumerable<object> ReadAnaData()
        {
            HashSet<string> words = new HashSet<string>();
            string path = Directory.GetCurrentDirectory() + @"\" + "Ana.txt";
            using (StreamReader file = new StreamReader(path))
            {
                while (true)
                {
                    var readed = file.ReadLine();
                    if (readed == "")
                        continue;
                    if (readed == null)
                        yield break;

                    //foreach (var item in readed.Split())
                    //{
                    if (!words.Contains(readed))
                    {
                        words.Add(readed);
                        //Console.WriteLine(readed);
                        yield return readed;
                    }
                    //}
                }
            }
        }

        private static void SaveData(IEnumerable<IEnumerable<object>> cases, string fileName)
        {
            string path = Directory.GetCurrentDirectory() + @"\" + fileName;

            using (StreamWriter file = new StreamWriter(path, false))
            {
                foreach (var c in cases)
                {
                    foreach (dynamic pol in c)
                    {
                        foreach (var item in pol)
                        {
                            file.Write(item.ToString() + ' ');
                        }
                        file.WriteLine();
                    }
                    file.WriteLine();
                }
            }
        }

        private static IEnumerable<IEnumerable<object>> ReadPolData()
        {
            string path = Directory.GetCurrentDirectory() + @"\" + "Cases.txt";
            using (StreamReader file = new StreamReader(path))
            {
                while (true)
                {
                    var readed = file.ReadLine();
                    if (readed == "")
                        continue;
                    if (readed == null)
                        yield break;

                    //Console.WriteLine(i++);
                    object[] pols = new object[2];
                    pols[0] = readed.Trim().Split();
                    pols[1] = file.ReadLine().Trim().Split();
                    yield return pols;
                }
            }
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
