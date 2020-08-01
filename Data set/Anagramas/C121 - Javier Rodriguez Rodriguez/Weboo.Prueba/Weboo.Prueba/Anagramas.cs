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
            if (cadena.Length == 0 || cadena.Length == 1) return 0;
            int count = 0;
            for(int i = 0; i < cadena.Length; i++)
                for(int j = i+1; j < cadena.Length; j++)
                    for(int k = 1; k <= cadena.Length - j; k++)
                        if (EsAnagrama(cadena.Substring(i, k), cadena.Substring(j, k)))  count++;
            return count;
        }

        public static bool EsAnagrama(string a, string b)
        {
            if (a.Length != b.Length) return false;
            bool[] revisado = new bool[b.Length];
            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < b.Length; j++)
                    if (a[i] == b[j] && !revisado[j])
                    {
                        revisado[j] = true;
                        i++;
                        if (i == a.Length) break;
                        j = -1;
                    }
            for (int i = 0; i < revisado.Length; i++)
                if (!revisado[i]) return false;
            return true;
        }

    }
}
