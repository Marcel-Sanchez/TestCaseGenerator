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
            int count = 0;
            int posInicial = 0;
            int count2 = 0;
            string s = "";
            string s2 = "";
            
            
            for (int i = 0; i < cadena.Length; i++)
            {
                for (int j = 1; j < cadena.Length; j++)
                {
                    if ((cadena[i]==cadena[j]) && (i<j))
                        count++;
                }
            }
            if (count == 0)
                return count;

            for (int i = 2; i < cadena.Length; i++)
            {
                s = cadena.Substring(posInicial, i);
                for (int j = 2; j < cadena.Length; j++)
                {
                    
                     s2 = cadena.Substring(i -1, j);
                    
                    
                       

                    if (s.Length != s2.Length)
                        s2 = cadena.Substring(i , j-1);

                    for (int x = 0; x < s.Length; x++)
                        for (int y = 0; y < s2.Length; y++)
                        {
                            if ((s[x] == s2[y]) && (x!=y))
                                count2++;
                        }
                        
                    
                    if (count2==s.Length)
                        count++;
                }
                posInicial++;
            }
            return count;
        }
    }
}
