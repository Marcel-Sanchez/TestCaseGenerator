using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weboo.Prueba
{
    public class Anagramas
    {
        private static string StrSort(string cad)
        {
            char[] cadEle = cad.ToCharArray();
            Array.Sort(cadEle);
            return new string(cadEle);
        }
        public static int CantidadEnCadena(string cadena)
        {
            int pares = 0;
            for (int i = 0; i < cadena.Length - 1; i++)
            {// recorriendo el indice del pivot hasta la penultima posicion

                for (int subLength = 1; subLength < cadena.Length - i; subLength++)
                {// Por cada longitud de pivot posible,

                    string pivotStr = StrSort(cadena.Substring(i, subLength));// cadena pivote ordenada

                    for (int j = i + 1; j <= cadena.Length - subLength; j++)
                    {// analizo todas las cadenas solapadas q no sean 'pivotStr' con longitud 'subLength'.

                        string otherStr = StrSort(cadena.Substring(j, subLength));// otra cadena ordenada

                        if (pivotStr == otherStr)
                            pares++;
                    }
                }
            }
            return pares;

            /*LA TIZAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA*/
        }
    }
}
