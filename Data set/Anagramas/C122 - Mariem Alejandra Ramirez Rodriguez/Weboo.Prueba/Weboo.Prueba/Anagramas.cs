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
            
            int cantDeRepeticiones = 0;
            int posiciones = 0;
           // cadena.Substring(posiciones);

            for (int i = 0; i < cadena.Length; i++)
            {

                if (cadena[i] == i)
                    i ++;
                {
                    
                    posiciones += cantDeRepeticiones;
                    if (cadena == "" || cadena[i] != posiciones )
                    {
                        cantDeRepeticiones += i;

                        int cantDletras = cadena[i];
                        if (cantDletras == 1)
                        {
                            return 0;
                        }
                        else if (cadena[i] == i)
                        {
                            break;
                        }
                    }
                   
                }
            }
              return posiciones;
        }
       
    }
}
              




