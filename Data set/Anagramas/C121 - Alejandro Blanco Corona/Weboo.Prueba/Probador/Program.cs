using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weboo.Prueba;

namespace Probador
{
    class Program
    {
        public static int CantidadEnCadena(string cadena)
        {
            int a = 0;
            char[] b = new char[cadena.Length];
            for (int i = 0; i < b.Length; i++)
            {
                for (int j = i+1; j < b.Length; j++)
                {

                    if (b.Length <= 1)
                        return a;

                    while (b[i] == b[j])
                    {
                        return a++;
                    }
                    i++;
                    
                   
                }

            }
            throw new NotImplementedException();
        }
        static void Main(string[] args)
{
    Console.WriteLine(Anagramas.CantidadEnCadena("mom")); // 2
    Console.WriteLine(Anagramas.CantidadEnCadena("abba")); // 4
    Console.WriteLine(Anagramas.CantidadEnCadena("abcd")); // 0
    Console.WriteLine(Anagramas.CantidadEnCadena("ifailuhkqq")); // 3
    Console.WriteLine(Anagramas.CantidadEnCadena("kkkk")); // 10
    Console.WriteLine(Anagramas.CantidadEnCadena("cdcd")); // 5
    Console.WriteLine(Anagramas.CantidadEnCadena("z")); // 0
    Console.WriteLine(Anagramas.CantidadEnCadena("")); // 0
}
    }
}
