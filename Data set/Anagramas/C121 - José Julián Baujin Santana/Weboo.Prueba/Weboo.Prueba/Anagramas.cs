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
            if (cadena.Length <= 1)
                return 0;
            int c = 0;
            for (int i = 0; i < cadena.Length - 1; i++)
            {
                for (int j = 1; j < cadena.Length - i; j++)
                {
                    for (int k = 1; k < cadena.Length - i; k++)
                    {
                        if (i + k > cadena.Length - j)
                            break;
                        string a = cadena.Substring(i, j);
                        string b = cadena.Substring(i + k, j);
                        if (EsAnagrama(a, b))
                            c++;
                    }                   
                }
            }
            return c;           
        }
        public static bool EsAnagrama(string a, string b)
        {
            if (a.Length != b.Length)
                return false;
            bool ToF = false;
            bool[] Ra = new bool[a.Length];
            bool[] Rb = new bool[b.Length];
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (Rb[j] == true)
                        continue;
                    if (a[i] == b[j])
                    {
                        Ra[i] = true;
                        Rb[j] = true;
                            break;                    
                    }
                }
            }
            for (int k = 0; k < Ra.Length; k++)
            {
                if (Ra[k] == true)
                    ToF = true;
                else
                {
                    ToF = false;
                    break;
                }
            }
            return ToF;
        }
    }
}
