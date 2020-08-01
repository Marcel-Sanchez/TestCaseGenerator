using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementations
{
    public class Anagramas
    {
        public static int Anagramas5(string s)
        {
            int cnt = 0;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    for (int k = 1; k + j <= s.Length; k++)
                    {
                        var s1 = s.Substring(i, k);
                        var s2 = s.Substring(j, k);

                        if (EsAnagrama(s1, s2))
                            cnt++;
                    }
                }
            }
            return cnt;
        }



        public static int Anagramas4(string cadena)
        {
            int count = 0;
            if (cadena.Length <= 1) return count;
            string[] posibilidades = PosiblesSubstrings(cadena);
            Array.Sort(posibilidades);
            int k = 0;
            for (int i = 0; i < posibilidades.Length; i++)
            {

                for (int j = i + 1; j < posibilidades.Length; j++)
                {
                    if (posibilidades[i].Length > posibilidades[j].Length) continue;
                    k = 0;
                    bool[] mas = new bool[posibilidades[j].Length];
                    for (int m = 0; m < posibilidades[i].Length; m++)
                    {
                        for (int n = 0; n < posibilidades[j].Length; n++)
                        {
                            if (mas[n]) continue;
                            if (posibilidades[i][m] == posibilidades[j][n])
                            {
                                k++;
                                mas[n] = true;
                                break;
                            }
                        }
                        if (k == posibilidades[j].Length)
                        {
                            count++;
                            break;
                        }
                    }
                }

            }
            return count;
        }

        public static int Anagramas3(string s)
        {
            var c = s[0];
            int cnt = 1;
            for (int i = 1; i < s.Length; i++)
            {
                if (c == s[i])
                {
                    cnt++;
                    if (cnt == 2)
                    {
                        //Console.WriteLine(s);
                        return -1;
                    }
                }
                else
                {
                    cnt = 1;
                    c = s[i];
                }
            }
            return Anagramas5(s);
        }
        private static bool EsAnagrama(string s1, string s2)
        {
            return string.Concat(s1.OrderBy(p => p)) == string.Concat(s2.OrderBy(p => p));

        }
        // Para el 4.
        public static string[] PosiblesSubstrings(string cadena)
        {

            double cardinalidad = Math.Pow(2, cadena.Length);
            int car = (int)cardinalidad;
            string[] allposibilities = new string[car - 2];

            int j = 0, k = 0;

            for (int i = 0; i < cadena.Length; i++)

            {
                for (j = i + 1; j <= cadena.Length; j++, k++)
                {
                    allposibilities[k] = cadena.Substring(i, j - i);
                }
                if (j + 1 >= cadena.Length) continue;
            }
            int y = 0;
            for (int g = 0; g < allposibilities.Length; g++)
            {
                if (allposibilities[g] == null) y++;
            }
            string[] nulos = new string[allposibilities.Length - y];
            for (int s = 0, r = 0; s < nulos.Length; s++)
            {
                if (allposibilities[s] != null)
                {
                    nulos[r] = allposibilities[s];
                    r++;
                }
            }
            return nulos;
        }
    }
}
