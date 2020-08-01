using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weboo.Prueba
{
    public class Anagramas
    {
        static int combinatoria(string s)
        {
            int h = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                for (int j = 0; i + j < s.Length; j++)
                {
                    h++;    
                }
            }
            return h;
        }        
        
        static string[] combinaciones(string s)
        {
            int j = 0;
            string[] neww = new string[combinatoria(s)];            
            for (int i = 0; i < s.Length; i++)
            {
                for (; j < s.Length; j++)
                {
                    neww[i + j] = s.Substring(i, j + 1);
                }
                if (j == s.Length)
                {
                    neww[i + j] = s.Substring(i + 1 , j);
                }
            }
            return neww;
        }

        static bool letraxletra(string a, string b)
        {
            if (a.Length != b.Length)
                return false;
            int suma = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                    {
                        suma++;
                    }                    
                }
                if (suma != i + 1)
                    return false;
            }
            return true;
        }
        public static int CantidadEnCadena (string cadena)
        {
            int suma = 0;
            for (int g = 0; g <= combinatoria(cadena); g++)
            {
                for (int i = 0; i < combinaciones(cadena)[g].Length; i++)
                {
                    for (int j = 1;j + i <= combinaciones(cadena)[j + i].Length ; j++)
                    {
                        if (letraxletra(combinaciones(cadena)[i], combinaciones(cadena)[i + j]))
                            suma++;                                                                                                       
                    }
                    
                }
            }
           
               
            throw new NotImplementedException();
        }
    }
}
