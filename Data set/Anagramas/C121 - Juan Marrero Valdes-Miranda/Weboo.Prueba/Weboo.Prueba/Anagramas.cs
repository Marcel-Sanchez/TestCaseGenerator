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
            if (string.IsNullOrEmpty(cadena))
                return 0;
            char[] temp = new char[0];
            int count = 0;
            int longitud = 1;
            for (int i = 0; i!=0 || longitud+i-1<cadena.Length; i++)
            {
                if (i == cadena.Length || i+longitud>cadena.Length )
                {
                    i = -1;
                    longitud++;
                    continue;
                }
                string Main = cadena.Substring(i, longitud);
                char[] Main2=Main.ToCharArray(0,longitud);
                for (int j = i+1; (longitud+j-1) < cadena.Length; j++)
                {
                    string aux = cadena.Substring(j, longitud);
                    char[] aux2 = aux.ToCharArray(0, longitud);
                    if (Compara(Main2, aux2)) 
                    {
                        count++;
                    }
                }
            }
            return count;
        }
      
        static bool Compara(char[] a,char[] b) 
        {
           
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j]) 
                    {
                        b[j] = '-';
                        break;
                    }
                    if (j == (b.Length - 1)) return false;  
                }
            }
            return true;
        }
    }
}
