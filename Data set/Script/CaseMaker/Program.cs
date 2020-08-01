using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "casos.txt";
            string[] cases = { "mom", "a", "abcd", "cccc", "abba" };
            string path = Directory.GetCurrentDirectory() + @"\" + fileName;
            int i = 0;

            using (StreamWriter file = new StreamWriter(path, false))
            {
                foreach (var c in cases)
                {
                    string method = $"public class TestCase{i} : AnagramasTest \n" +
                                        $"{{ \n" +
                                            $"\t public void Ejemplo{i}() \n" +
                                            $"\t {{ \n" +
                                                $"\t \t string str = \"{c}\" \n" +
                                                $"\t \t Assert.That(Student(str), Is.EqualTo(CantidadEnCadena(str))) \n" +
                                            $"\t }} \n" +
                                        $"}}";
                    file.WriteLine(method);
                    i++;

                }
            }
        }
    }
}
