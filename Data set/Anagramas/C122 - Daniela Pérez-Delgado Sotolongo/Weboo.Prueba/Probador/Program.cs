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

            //Mis Casos de Prueba
            Console.WriteLine(Anagramas.CantidadEnCadena("daniela")); // 2
            Console.WriteLine(Anagramas.CantidadEnCadena("pepe")); // 5
            Console.WriteLine(Anagramas.CantidadEnCadena("paris")); // 0
            Console.WriteLine(Anagramas.CantidadEnCadena("egipto")); // 0
            Console.WriteLine(Anagramas.CantidadEnCadena("italia")); // 4
            Console.WriteLine(Anagramas.CantidadEnCadena("iiii")); // 10
            Console.WriteLine(Anagramas.CantidadEnCadena("mouse")); // 0
            Console.WriteLine(Anagramas.CantidadEnCadena("d")); // 0
            Console.WriteLine(Anagramas.CantidadEnCadena("beatles")); //2 
            Console.WriteLine(Anagramas.CantidadEnCadena("iiiiiiiiiiiiiiiiiiiiii")); //SuperGrande
        }
    }
}
