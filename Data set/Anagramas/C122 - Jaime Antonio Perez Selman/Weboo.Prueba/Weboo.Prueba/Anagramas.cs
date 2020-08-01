using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weboo.Prueba
{
    public class Anagramas
    {
        public static bool ComparaString(string a, string b)
        {
            bool result = false;
            if (a.Length == b.Length)
            {
                bool[] value1 = new bool[a.Length];
                bool[] value2 = new bool[b.Length];
                result = true;

                for (int i = 0; i < a.Length; i++)
                {
                    for (int j = 0; j < b.Length; j++)
                    {
                        if (a[i] == b[j])
                            value1[i] = true;
                        if (b[i] == a[j])
                            value2[i] = true;
                    }
                }
                for (int i = 0; i < value1.Length; i++)
                {
                    if (value1[i] == false)
                    {
                        result = false;
                        break;
                    }
                    if (value2[i] == false)
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;

        }
        public static int CantidadEnCadena(string cadena)
        {

            int pares = 0;
            for (int i = 0; i < cadena.Length - 1; i++)
            {

                for (int j = 1; j <= cadena.Length - i; j++)
                {
                    for (int k = i+1; k < cadena.Length; k++)
                    {
                      
                        if (ComparaString(cadena.Substring(i, j), cadena.Substring(k)))
                        {
                            pares++;
                        }
                    }



                }



            }


            return pares;
        }
    }
}
