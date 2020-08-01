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
            int cntidad = 0;            
            if (cadena == "")
                return cntidad = 0;
            if (cadena.Length == 1)
                return cntidad = 0;

            if ( cadena!="" && cadena.Length!=1)
            {
                for (int i = 0; i < cadena.Length; i++)
                    
                {
                    for (int j = 0; i!=j &&j<cadena.Length; j++)
                    {

                        if (cadena[i] == cadena[j] && cadena.Length > 2)
                            cntidad++;
                        if (cadena[i] == cadena[j])
                            cntidad++;
                        j++;    

                    }

                } 
            }
            return cntidad;

            
        }
        
    }
}
