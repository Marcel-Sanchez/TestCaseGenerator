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
            if (cadena.Length <= 1)
                return 0;
            return Anagrams(cadena);
        }
        private static int Anagrams(string cadena)
        {
            int cont = 0;
            for (int i = 0; i < cadena.Length; i++)
            {
                for (int j = i + 1; j < cadena.Length; j++)
                {
                    if (cadena[i] == cadena[j])
                        cont++;
                }
            }
            return cont += Substrings(cadena);
        }
        private static int Substrings(string cadena)
        {
            int cont = 0;
            for (int i = 0; i < cadena.Length; i++)
            {
                string s1 = cadena.Substring(0, i);
                string s2 = cadena.Substring(i, cadena.Length - i - 1);
                cont += Subs(i, cadena, s1) + Subs(i, cadena, s2);
            }
            return cont;
        }
        private static int Subs(int i, string cadena, string s1)
        {
            if (s1.Length == cadena.Length)
                return 0;
            if (s1.Length == 1)
                return 0;
            int cont = 0;
            int contIgual = 0;
            bool separado = false;
            for (int k = 0; k < s1.Length; k++)
            {
                for (int j = i + 1; j < cadena.Length; j++)
                {
                    if (s1[k] == cadena[j])
                    {
                        cont++;
                        if (k + 1 < s1.Length && j + 1 < cadena.Length && k - 1 > 0 && j - 1 > 0)
                            if (s1[k + 1] != cadena[j + 1] && s1[k - 1] != cadena[j - 1] || s1[k + 1] == cadena[j + 1] && s1[k + 1] == cadena[j + 2])
                                separado = true;
                    }
                    if (cont == s1.Length && !separado)
                    {
                        contIgual++;
                        cont = 0;
                    }
                }
            }
            return contIgual;
        }
    }
}
