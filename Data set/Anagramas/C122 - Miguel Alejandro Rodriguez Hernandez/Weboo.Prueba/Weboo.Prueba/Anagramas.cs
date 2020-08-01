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
            return Picar(cadena);
            throw new NotImplementedException();
        }
        static int Picar(string cadena)
        {
            int cont = 0;
            for (int i = 0; i < cadena.Length; i++)
            {
                string[] perm = new string[cadena.Length - i];
                for (int j = 0; j < perm.Length; j++)
                {
                    perm[j] = cadena.Substring(j, i + 1);
                }
                for (int k = 0; k < perm.Length - 1; k++)
                {
                    for (int l = k + 1; l < perm.Length; l++)
                    {
                        if (Comp(perm[k], perm[l])) cont++;
                    }
                }
            }
            return cont;
        }
        static bool Comp(string sub, string cad)
        {
            bool[] marca = new bool[cad.Length];
            for (int i = 0; i < sub.Length; i++)
            {
                for (int j = 0; j < cad.Length; j++)
                {
                    if (!marca[j] && sub[i] == cad[j]) {
                        marca[j] = true;
                        break;
                    }
                }
            }
            for (int i = 0; i < marca.Length; i++)
            {
                if (!marca[i]) return false;
            }
            return true;
        }
    }
}
