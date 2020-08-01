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
            int substring = 0;
            for (int i = 0; i < cadena.Length; i++)
            {
                for (int j = i; j < cadena.Length - 1; j++)
                {
                    if (cadena == "")
                        return 0;
                    if (cadena[i] == cadena[j])
                        substring++;
                    if (cadena[i] == i)
                        return 0 ;
                    if (cadena[j] == i +j )
                        substring++;
                    

                }
                
                    
            }
            return substring;
        }
    }
}
