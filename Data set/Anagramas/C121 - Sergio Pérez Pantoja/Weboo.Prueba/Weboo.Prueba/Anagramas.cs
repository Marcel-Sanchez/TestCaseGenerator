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
            string a;
            string b;
            int cant = 0;
            for (int j = 1; j < cadena.Length; j++)
                for (int i = 0; i < cadena.Length - j; i++)
                {
                    a = cadena.Substring(i, j);
                    for (int k = i + 1; k <= cadena.Length - j; k++)
                    {
                        b = cadena.Substring(k, j);
                        if (SonAnagramas(a, b))
                            cant++;
                    }
                }
            return cant;
        }
        public static bool SonAnagramas(string a, string b)
        {
            char[] a1 = new char[a.Length];
            char[] b1 = new char[b.Length];

            for (int i = 0; i < a.Length; i++)
                a1[i] = a[i];
            for (int i = 0; i < b.Length; i++)
                b1[i] = b[i];
            Array.Sort(a1);
            Array.Sort(b1);

            for (int i = 0; i < a.Length; i++)
            {
                if (a1[i] != b1[i])
                    return false;
            }
            return true;
        }
    }
}
