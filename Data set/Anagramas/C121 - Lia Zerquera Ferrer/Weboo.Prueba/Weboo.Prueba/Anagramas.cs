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
            int sols = 0;
            bool[] a = new bool [cadena.Length];
            string subs = "";
            int cont = 0;
            for (int j = 0; j < cadena.Length-1; j++)
            {  if (a[j])
                    continue;
                if(cadena.Length == 0)
                {
                    subs += 0;
                }
                else
                {
                    subs =subs + cadena[j];
                    if(cadena[j]!=cadena[cadena.Length-1])
                    subs = subs + cadena[j] + cadena[(j+1)];
                    cont++;
                }
                int rep = 0;
                int cantidadDeAnagramas = 0;
                for (int i = 0; i <subs.Length ; i++)
                { if (cont > 0)
                    {
                        if (a[j] == true)
                            rep++;
                        if (rep > 0)
                        {
                            cantidadDeAnagramas++;
                        }
                    }
                    sols = cantidadDeAnagramas;
                }
                return sols;
            }
            return sols;
        }
        
    }
}
