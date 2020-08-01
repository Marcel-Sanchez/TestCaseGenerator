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
            int cant = 0;

            if (cadena.Length<=1)
            {
                return cant;
            }
            for (int lsub = 1; lsub < cadena.Length; lsub++)
            {
               string[] subStrings=new string[cadena.Length-(lsub-1)];
                for (int i = 0; i < subStrings.Length; i++)
                {
                    subStrings[i] = cadena.Substring(i, lsub);
                }

                for (int i = 0; i < subStrings.Length; i++)
                {
                    for (int j = i+1; j < subStrings.Length; j++)
                    {
                        if (EsAnagrama(subStrings[i], subStrings[j]))
                        {
                            cant++;
                        }
                    }
                }
            }
            return cant;
        }

        public static bool EsAnagrama(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }
            bool[] mask=new bool[s2.Length];
            for (int i = 0; i < s1.Length; i++)
            {
                if (!EstaContenida(s1[i],s2,mask))
                {
                    return false;
                }
            }
            return true;

        }

        public static bool EstaContenida(char c, string s,bool[] mask)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (c==s[i]&&!mask[i])
                {
                    mask[i] = true;
                    return true;
                }
            }
            return false;
        }
    }
}
