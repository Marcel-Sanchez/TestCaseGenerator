using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weboo.Prueba
{
    public class Anagramas
    {
        public static bool IsHere(string sub, string cadena)
        {
            int countt = 0;
            int countf = 0;
            int k = cadena.Length;
            for (int i = 0; i < cadena.Length; i++)
            { 
                for (int j = 0; j < sub.Length; j++)
                {
                    if (sub.Substring(j, 1) != sub.Substring(i, 1)) countf++;

                    else countt++;
                }
                if (countf == sub.Length) return false;
                
                countf = 0;
            }
                if (countt <= 1) return false; 
                else return true;
        }
    
       public static int CantidadEnCadena (string cadena)
        {
            int count = 0;
            if (cadena == "" || cadena.Length == 1) return 0;
            else
            {
                for (int i = 0, k = 1; i < cadena.Length && k <= cadena.Length - k; i++)
                    for (int j = 0; j < cadena.Length - k; j++)
                    {
                        if (IsHere(cadena/*.Substring(i, (cadena.Length - i))*/, cadena.Substring(j, k)))
                        {
                            k++;
                            count++;
                        }
                    }
            }
            if (cadena.Substring(0, 1) == cadena.Substring(cadena.Length - 1)) count++;
            if (cadena.Length % 2 == 0 && cadena.Length>2 && cadena.Substring((cadena.Length / 2) - 1, 1) == cadena.Substring(cadena.Length / 2, 1)) count++;
           return count;
        }
    }

}
