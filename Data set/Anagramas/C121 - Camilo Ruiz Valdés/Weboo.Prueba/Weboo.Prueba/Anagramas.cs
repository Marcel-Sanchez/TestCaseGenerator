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
            int frequence = 0;
            for(int i = 1; i < cadena.Length; i++)
            {
                frequence += GetQuantity(cadena, i);
            }
            return frequence;
        }
        public static int GetQuantity(string a, int f)
        {
            int counter = 0;
            for (int i = 0; i <= a.Length - f; i++)
            {
                string b = a.Substring(i, f);
                for (int j = i + 1; j <=a.Length-f; j++)
                {
                    string d = a.Substring(j, f);
                    if (SameChars(b, d)) counter++;
                }
            }
            return counter;
        }
        public static bool SameChars(string a, string b)
        {
            bool[] d = new bool[b.Length];
            int counter = a.Length;
            for(int i = 0; i < a.Length; i++)
            {
                
                for(int j = 0; j < b.Length; j++)
                {
                    if (d[j]) continue;
                    if (a[i] == b[j])
                    {
                        counter--;
                        d[j] = true;
                        break;
                    }
                }
            }
            if (counter == 0)
            {
                return true;
            }
            return false;
        }
    }
}
