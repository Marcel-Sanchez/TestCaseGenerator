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
            if (cadena.Length == 1)
                return 0;

            int k = 0;
            int l = 0;


            for (int i = 0; i < cadena.Length; i++)
            {
                for (int j = cadena.Length - 1; j > i; i++)
                    for (int f = cadena.Length - 1; j > i; j--)


                        if (cadena[i] == cadena[j] || cadena[f] == cadena[i])
                        {
                            k++;
                        }
 
              /*  int a = cadena[i];
                int b = cadena.Length - 1;
                for (int g = a + cadena[i + 1], int h = b + cadena[b - 1]; g != h; i++)
                {
                    if (g == h)
                        l++;
                        aaaaaaaaaaaaa intentos fallidos lo deje asi 
                    
                }*/



            }
            {
                return k + l;
            }



        }
    }
}










