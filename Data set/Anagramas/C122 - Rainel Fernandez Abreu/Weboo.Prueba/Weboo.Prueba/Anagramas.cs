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
            if(cadena.Length == 0 || cadena.Length == 1)
               {
                return 0;
               }
            int c1 = 0;
            char p = ' ';
            string l = " ";
            string ll = " ";
            int c = 0;
            char[] caract = new char[cadena.Length];
            for (int i = 0; i < cadena.Length; i++)
            {
                caract[c] = cadena[i];
                c++;
            }
            for (int i = 0; i < cadena.Length; i++)
            {
                for (int j = i+1; j < cadena.Length; j++)
                {
                    if (cadena[i] == cadena[j])
                        c1++;
                }
            }
            int w = 0;
            int cc = 0;
            while (w < caract.Length)
            { 
                l = l + caract[cc];
                cc++;
                for (int i = l.Length - 1; i > 0; i--)
                {
                    ll = ll + l[i - 1];
                }
                for (int m = 0; m < l.Length; m++)
                {
                        if (l[m] == ll[l.Length-1 -m])
                            c1++;
                }
                w++;
            }
            c1 = c1 / 2;
            return c1;
        }
    }
}
