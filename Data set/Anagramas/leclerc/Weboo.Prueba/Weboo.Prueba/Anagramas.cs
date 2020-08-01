using System;

namespace Weboo.Prueba
{
    public class Anagramas
    {
        private static bool AreAnagrams(string a, string b)
        {
            int[] map = new int[27];
            for (int i = 0; i < a.Length; i++)
            {
                map[a[i] - 'a']++;
                map[b[i] - 'a']--;
            }

            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] != 0)
                    return false;
            }

            return true;
        }

        public static int CantidadEnCadena(string cadena)
        {
            int solution = 0;
            for (int len = 1; len < cadena.Length; len++)
            {
                for (int i = 0; i <= cadena.Length - len; i++)
                {
                    for (int j = i + 1; j <= cadena.Length - len; j++)
                    {
                        if (AreAnagrams(cadena.Substring(i, len), cadena.Substring(j, len)))
                        {
                            solution++;
                        }
                    }
                }
            }

            return solution;
        }
    }
}
