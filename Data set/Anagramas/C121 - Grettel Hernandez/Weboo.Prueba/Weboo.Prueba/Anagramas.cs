using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weboo.Prueba
{
    public class Anagramas
    {
        public static int CantidadEnCadena (string cadena)
        {
            int cantDeAnagramas = 0;
           
            for(int i = 1; i <= cadena.Length - 1; i++)
            {
                string s1 = cadena.Substring(0, i);
                string s2 = cadena.Substring(cadena.Length - i, i);

                if (SonAnagrama(s1, s2))
                {
                    cantDeAnagramas++;
                }
            }

            return cantDeAnagramas;
        }

        public static bool SonAnagrama(string cadena1, string cadena2)
        {
            if (cadena1.Length != cadena2.Length) return false;

            bool[] marca = new bool[cadena1.Length];

            for (int k = 0; k < cadena1.Length; k++)
            {
                int l = 0;
                for (; l < cadena1.Length; l++)
                {
                    char c1 = cadena1[k];
                    char c2 = cadena2[l];
                    if (cadena1[k] == cadena2[l] && marca[l] == false)
                    {
                        marca[l] = true;
                        break;
                    }
                }
                if (l == cadena1.Length) return false;
            }
            return true;
        }
    }
}
