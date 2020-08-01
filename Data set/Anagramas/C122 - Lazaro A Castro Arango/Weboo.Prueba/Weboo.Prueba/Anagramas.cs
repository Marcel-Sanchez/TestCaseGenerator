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
            string sub = "";
            string subsub = "";
            int d = 0;
            int m = 0;
            int n = 0;
            for (int i = 0; i < cadena.Length-1; i++)
            {
                for (int j = i+1; j < cadena.Length; j++)
                {
                    if (cadena[i]==cadena[j])
                    {
                        if (i==j)
                        {
                            cant++;
                            continue;
                        }
                        if (i == 0)
                        {
                            sub = cadena.Substring(i, j + 1);
                        }
                        if (i != 0)
                        {
                            sub = cadena.Substring(i, j - i +1);
                        }
                        else sub = cadena.Substring(i, j + 1);

                        cant++;
                        for (int a = 2; a <= sub.Length-1; a++)
                        {
                            subsub = sub.Substring(0, a);
                            for (int z = 0; z <subsub.Length; z++)
                            {

                                for (int v = 0; v < subsub.Length; v++)
                                {
                                    if (subsub[z]==subsub[v])
                                    {
                                        m++;
                                    }
                                }
                                if (m>1)
                                {
                                    m = (m * m - m)/m;
                                    n += m;
                                }
                                m = 0;
                            }

                            for (int c   = 0; c < subsub.Length; c++)
                            {
                                for (int b = sub.Length - 1; b >= sub.Length - subsub.Length; b--)
                                {

                                    if (subsub[c]==sub[b])
                                    {
                                        d++;
                                        
                                    }  
                                }
                              
                            }
                            if (d-n == subsub.Length)
                            {
                                cant++;
                            }
                            d = 0;
                        }
                    }
                   
                }
                sub = "";
                subsub = "";
                n = 0;
            }
              
            return cant;
        }
    }
}
