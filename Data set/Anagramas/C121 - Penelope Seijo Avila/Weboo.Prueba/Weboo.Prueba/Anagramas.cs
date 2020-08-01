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
            if (cadena.Length == 0)
                return 0;
            int count = 0;
            //for (int k = 0; k < cadena.Length; k++)
            //{
            //    for (int i = k; i < cadena.Length; i++)
            //    {                                //i
            //        string sub = cadena.Substring(k, k==0?i+1:i);//inicio y length
            //        int Length = i + 1;
            //        for (int j = i+1; j < cadena.Length - i; j++)
            //        {
            //            string aComparar = cadena.Substring(j, Length);
            //            if (SonAnangramas(sub, aComparar))
            //            {
            //                count++;
            //            }
            //        }
            //    }
            //}

            int j = 1;
            while(j<cadena.Length)
            {
                for (int k = 0; k < cadena.Length; k++)
                {     if (k > cadena.Length - j)
                        break;            //k+j//deberia poner la terna
                    string sub = cadena.Substring(k, j);
                    for (int l = k + 1; l <= cadena.Length-j; l++)
                    {
                        if (SonAnangramas(cadena.Substring(l, j), sub)) count++;
                    }
                }
                j++;
            }

            return count;

        }
        public static bool SonAnangramas(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;
           
            bool[] marca = new bool[s2.Length];

            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j < s2.Length; j++)
                {
                    if (s1[i] == s2[j] && !marca[j])
                    { marca[j] = true;
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
