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
            int cont = 0;
            for (int i = 0; i < cadena.Length; i++)
            {
                for (int j = 1; j <= cadena.Length - i; j++)
                {
                    for (int k = i + 1; k < cadena.Length; k++)
                    {
                        {
                            if (k + j <= cadena.Length && Anagrama(cadena.Substring(i, j), cadena.Substring(k, j)))
                                cont++;
                        }
                    }
                }
            }
            return cont;
        }
        public static bool Anagrama(string a, string b)
        {
            bool[] mask = new bool[b.Length];
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (mask[j]) continue;
                    if (a[i] == b[j])
                    {
                        mask[j] = true;
                        break;
                    }
                }
            }
            for (int i = 0; i < mask.Length; i++)
            {
                if (!mask[i]) return false;
            }
            return true;
        }
    }
}
