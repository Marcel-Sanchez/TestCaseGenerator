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
            int a = 0;
            char[] b = new char[cadena.Length];
            for (int i = 0; i < b.Length; i++)
            {
                for (int j = i+1 ; j < b.Length; j++)

                {
                    if (b.Length<=1)
                        return a;
                    while (b[i] == b[j])
                    {
                        return a++;

                    }
                }
            }
            throw new NotImplementedException();
        }
    }
}
