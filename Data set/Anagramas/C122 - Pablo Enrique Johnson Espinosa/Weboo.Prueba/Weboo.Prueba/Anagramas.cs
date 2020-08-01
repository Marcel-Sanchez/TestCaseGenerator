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
            int cant=0;
            string[] s = new string[cadena.Length];
            for(int i= 0; i<cadena.Length; i++)
                for (int j = 1; j < s.Length; j++)
                {
                    if (s[i] == s[j])
                        cant++;
                }
            for (int i = 0; i < cadena.Length; i++)
                for (int j = cadena.Length - 1; j < cadena.Length; j--)
                {
                    if (s[i] == s[j])
                        cant++;
                }
            return cant;
                    

                    
        }
    
    }

}
