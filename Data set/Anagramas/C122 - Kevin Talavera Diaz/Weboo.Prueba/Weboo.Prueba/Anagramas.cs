using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weboo.Prueba
{
    public class Anagramas
    {
        public static int CantidadEnCadena(string cadena)
        {
            int cont = 0;
            if (cadena == "")
                return cont;
            for (int i = 0; i < cadena.Length; i++)
            {
                for (int j = cadena.Length - 1; j > i; j--)
                {
                    if (cadena[i] == cadena[j])
                    {
                        cont++;
                    }
                    else
                        if (cadena[i] != cadena[j])
                    {
                        char.ToString(cadena[j]);
                        string s = cadena.Substring(0, j + 1);
                        string p = cadena.Substring(j, cadena.Length - 1);
                        p.Reverse();
                        if (s == p)
                            cont++;    
                     }
                }
            }
            return cont;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Anagramas.CantidadEnCadena("mom"));
            Console.ReadLine();
        }
            //throw new NotImplementedException();
        }
       
    }    

                        