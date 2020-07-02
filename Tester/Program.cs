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
            //IEnumerable<object> cases = null;

            // Generador de casos de prueba aleatorios.
            var list = new List<UniqueModelCase>();
            var generator = new CaseGenerator();
            //do
            //{
            //Método que me genera n casos de prueba.
            //if (generate)
            //{
            //var cases = generator.GenerateCases(Sett.CasesToGenerate);
            //SaveData(cases, "Cases.txt");
            var cases = ReadData();
            //}




            List<object> sols3 = new List<object>();
            List<object> sols4 = new List<object>();
            List<object> sols5 = new List<object>();
            List<object>[] sols = new List<object>[] { sols3, sols4, sols5 };

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
                    sols[posModel++].Add(result);
                }
                //Console.WriteLine("---");
            }
            //Console.WriteLine("---");

            UniqueModelCase model = new UniqueModelCase(SolutionComparer.F);
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

            //Console.WriteLine();
            //list.Add(model);

            //} while (Sett.MembersToGenerate-- > 0);

            //Genetic_Algorithm.Run(list);

            //var m = list[0];
            //foreach (var item in list.Skip(1))
            //{
            //    m.Merge(item);
            //}
            Console.WriteLine(model.Results.Count);
            GRASP.Run(model);


            obtained = model.GetPercentajes();
            obtained3 = obtained.Item1;
            obtained4 = obtained.Item2;

            Console.WriteLine($"Model 3: {obtained3}%");
            Console.WriteLine($"Model 4: {obtained4}%");
            //Genetic_Algorithm.Run(m);
            Console.WriteLine(model.Results.Count);

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

        private static IEnumerable<IEnumerable<object>> ReadData()
        {
            string path = Directory.GetCurrentDirectory() + @"\" + "Cases.txt";
            int i = 1;
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
