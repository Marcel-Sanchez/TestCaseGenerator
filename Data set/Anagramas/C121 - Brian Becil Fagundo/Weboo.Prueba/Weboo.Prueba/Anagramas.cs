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
            // Elimine esta linea e implemente su solucion aqui.
            return Conteo(cadena);
        }


//_______________________________________________________________________________________________
        public static int Conteo (string c)
        {

            // if(c != c.ToLower(...))     || Exception ||
            // else
            //     ||
            //    \||/
            //     \/

            int count1 = 0;
            int distancia = 0;

            for (int i = 0; i < c.Length; i++)
            {
                for (int j = i + 1; j < c.Length - 1; j++)
                {
                    if (c[i] == c[j])
                    {
                        count1++;
                        distancia = Math.Abs(i - j);
                        if (distancia > 2)
                        {
                            count1 ++;

                            while (distancia > 2)
                            {
                                count1 ++;
                                for (int n = i + 1; n < j - 1; n++)
                                {
                                    for(int m = n+1; m<n-1; m++)
                                    {
                                        if (c[n] == c[m])
                                        {
                                            count1++;
                                        }
                                    }
                                }
                                distancia--;
                            }
                        }
                    }   
                }
            }
            return count1;
        }
//_______________________________________________________________________________________________
    }
}
