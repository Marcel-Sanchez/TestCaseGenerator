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
            int contador = 0;
            

            for (int i = 0; i < cadena.Length-1; i++)
            {
                if (cadena == "")
                    return contador;
                for (int j = cadena.Length-1; j > 0 ; j--)
                {
                   if (cadena[i]==cadena[j])
                   {
                       if (i != j)
                       {
                           if (cadena[i + 1] == cadena[j - 1])
                                 contador++;
                           if (cadena[i] == cadena[j] && i == j)
                           {
                               if (cadena[i - 1] == cadena[j + 1])
                                   contador++;
                           }

                           contador++;
                       }
                       
                   }
                    
                }
            }
            return contador;
        }
    }
}
