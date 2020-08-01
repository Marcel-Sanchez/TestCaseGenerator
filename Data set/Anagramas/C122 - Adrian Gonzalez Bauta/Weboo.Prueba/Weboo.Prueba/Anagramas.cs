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
            int count = 0;
            for (int i = 0; i < cadena.Length - 1; i++)
            {
                for (int k = 1; k <= cadena.Length - 1 - i; k++)
                {
                    for (int j = i + 1; j < cadena.Length; j++)
                    {
                        if (j + k > cadena.Length)
                            break;
                        if (EsAnagrama(cadena.Substring(i, k), cadena.Substring(j, k)))
                            count++;
                    }
                }
            }
            return count;
        }
        public static bool EsAnagrama(string a, string b)
        {
            bool[] mapDeA = new bool[a.Length];
            bool[] mapDeB = new bool[b.Length];
            for (int i = 0; i < a.Length; i++)
            {
                while (a[i] == ' ')
                {
                    mapDeA[i] = true;
                    i++;
                }
                for (int j = 0; j < b.Length; j++)
                {
                    while (b[j] == ' ')
                    {
                        mapDeB[j] = true;
                        j++;
                    }
                    if (a[i] == b[j] && mapDeB[j] != true)
                    {
                        mapDeA[i] = true;
                        mapDeB[j] = true;
                        break;
                    }
                }
            }
            for (int k = 0; k < mapDeA.Length; k++)
            {
                if (mapDeA[k] == false)
                    return false;
            }
            for (int k = 0; k < mapDeB.Length; k++)
            {
                if (mapDeB[k] == false)
                    return false;
            }
            return true;
        }
    }
}
