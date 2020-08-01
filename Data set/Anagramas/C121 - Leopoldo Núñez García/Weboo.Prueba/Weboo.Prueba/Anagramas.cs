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
            
            int cadena1=Convert.ToInt32(cadena);
            int[] c = { cadena1 };
            int[] ct = {};
            int cont = 0;
            for (int i = 0; i < c.Length-1; i++)
            {
                for (int j = 1; j < c.Length;j++)
                {
                    if (c[i] == c[j])
                    {
                        cont++;
                        
                        break;
                    }
                       
                }
                
            }
            
            throw new NotImplementedException();
        }
    }
}
