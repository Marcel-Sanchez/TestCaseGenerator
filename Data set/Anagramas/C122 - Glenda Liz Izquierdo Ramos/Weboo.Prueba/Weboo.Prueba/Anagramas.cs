using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weboo.Prueba
{
    public class Anagramas
    {
        static void Main(String[] args)
        {
            Console.WriteLine(Anagramas.CantidadEnCadena("mom")); // 2 Console.WriteLine(Anagramas.CantidadEnCadena("abba")); // 4 Console.WriteLine(Anagramas.CantidadEnCadena("abcd")); // 0 Console.WriteLine(Anagramas.CantidadEnCadena("ifailuhkqq")); // 3 Console.WriteLine(Anagramas.CantidadEnCadena("kkkk")); // 10 Console.WriteLine(Anagramas.CantidadEnCadena("cdcd")); // 5 Console.WriteLine(Anagramas.CantidadEnCadena("z")); // 0 Console.WriteLine(Anagramas.CantidadEnCadena("")); // 0
        }
        public static int CantidadEnCadena(string cadena)
        {

            string[] enlace;


            for (int i = 0; i < enlace.Length - 1; i++)
            {
                string cadenita = enlace[0] + enlace[i - 1];
                for (int j = 0; j <= enlace.Length - 1; j++)
                {
                    for (int k = 0; k <= enlace.Length - 1; k++)
                    {
                        if (j == k)
                        {
                           string[] cadeneta = k;
                            return cadeneta;
                            string cadena = cadenita[i] + cadenita[k];
                        }
                        return cadena;
  


                    }
                }


            





               
                }
         


          
           
          
            throw new NotImplementedException();
        }
    }
}
