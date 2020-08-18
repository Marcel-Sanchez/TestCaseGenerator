using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Metaheuristic
{
    public static class Helper
    {
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

        public static IEnumerable<object> GetFinalCases(IEnumerable<object> cases, IEnumerable<int> keys)
        {
            var casesArray = cases.ToArray();
            return keys.Select(p => casesArray[p]);
        }

        public static void WriteFinalCases(IEnumerable<object> finalCases)
        {
            string p = Directory.GetCurrentDirectory() + @"\" + "final.txt";
            using (StreamWriter file = new StreamWriter(p, true))
            {
                foreach (var fcase in finalCases)
                {
                    file.WriteLine(fcase);
                }
            }
        }

        public static void WriteFormatedCases()
        {
            string writePath = Directory.GetCurrentDirectory() + @"\" + "Formated Cases.txt";
            string readPath = Directory.GetCurrentDirectory() + @"\" + "final.txt";
            int i = 0;

            using (StreamWriter writeFile = new StreamWriter(writePath, false))
            {
                using (StreamReader readFile = new StreamReader(readPath))
                {
                    var readed = readFile.ReadLine();
                    while (readed != null)
                    {
                        string method = $"public class TestCase{i} : AnagramasTest \n" +
                                        $"{{ \n" +
                                            $"\t public void Ejemplo{i}() \n" +
                                            $"\t {{ \n" +
                                                $"\t \t string str = \"{readed}\"; \n" +
                                                $"\t \t Assert.That(Student(str), Is.EqualTo(CantidadEnCadena(str))); \n" +
                                            $"\t }} \n" +
                                        $"}}";
                        writeFile.WriteLine(method);
                        i++;
                        readed = readFile.ReadLine();
                    }
                }
            }
        }
    }
}
