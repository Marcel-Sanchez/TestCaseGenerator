using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weboo.Prueba
{
    public class Anagramas
    {
         static bool ComparaString (string a,string b)
        {
            bool[] evaluado= new bool [b.Length];
            for ( int n =0; n < a.Length; n++)
            {
                for( int m =0; m<b.Length; m++)
                {
                    if (!evaluado[m])
                        if (a[n] == b[m])
                        {
                            evaluado[m]= true;
                            break;
                        }
                    if (m + 1 == b.Length)
                        return false;                    
                }
            }
            return true;
        }
        public static int CantidadEnCadena (string cadena)
        {
            int r = 0;
            for ( int i =0; i< cadena.Length;i++)
            {
                for(int j=1; j < cadena.Length; j++)
                {
                    for (int k = i + 1; k + j <= cadena.Length; k++)
                        if (cadena.Substring(i, j) == cadena.Substring(k, j))
                            r++;
                    else
                    if (ComparaString(cadena.Substring(i, j) , cadena.Substring(k, j)))
                        r++;
                }
            }
            return r;
        } 
    }
}
