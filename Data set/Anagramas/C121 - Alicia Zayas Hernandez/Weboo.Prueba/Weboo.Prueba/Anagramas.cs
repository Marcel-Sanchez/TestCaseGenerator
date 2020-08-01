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
            if (cadena == "" || cadena.Length == 1)
                return 0;

            int count = 0;
            int length = 1;

           while(length < cadena.Length)
           {
                for (int i = 0; i < cadena.Length; i++)
                {
                    for (int j = i + 1; j < cadena.Length; j++)
                    {
                        if(j + length < cadena.Length + 1)
                        {
                            string a = cadena.Substring(i, length);
                            string b = cadena.Substring(j, length);
                            if (SonAnagrama(a, b))
                                count++;
                        }
                    }
                }
                length++;
           }

            return count;
        }

        static bool SonAnagrama(string a, string b)
        {
            if (a.Length != b.Length)
                return false;

            Dictionary<char, int> letras = new Dictionary<char, int>();

            for (int i = 0; i < a.Length; i++)
            {
                if(!(letras.ContainsKey(a[i])))
                    letras.Add(a[i], ContarOcurrencias(a[i], a));
            }

            for (int i = 0; i < b.Length; i++)
            {
                if (!(letras.ContainsKey(b[i])) || ContarOcurrencias(b[i], b) != letras[b[i]])
                    return false;
            }

            return true;
        }

        static int ContarOcurrencias(char c, string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == c) count++;
            }
            return count;
        }
    }
}
