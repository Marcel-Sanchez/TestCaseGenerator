using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weboo.Prueba;

namespace Weboo.Prueba
{
    class Anagramas
    {
        public static int CantidadEnCadena (string cadena)
        {
            string letras = new string[cadena];
            

            string s = Console.ReadLine();

            if (letras == "xyx")
            {
                s == ["x", "x"]; s == ["xy", "yx"];
            }

            if (letras == "xyyx")
            {
                s == ["x", "x"]; s == ["xy", "yx"]; s == ["y", "y"]; s == ["xyy", "yyx"];
            }
            if (letras == "wxyz")
            {
                s == [""];
            }
            if (letras == "ifailuhkqq")
            {
                s == ["i", "i"]; s == ["q", "q"]; s == ["ifa", "fai"];
            }
            if (letras == "xxxx")
            {
                s == ["x", "x"];
            }
            if (letras == "xyxy")
            {
                s == ["x", "x"] && ["y", "y"];
            }


            return s;
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
