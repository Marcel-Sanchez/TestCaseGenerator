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
            int anagramas = 0;
            if (cadena.Length < 2)
            {
                return anagramas;
            }
            char[] letras = new char[cadena.Length];
            for (int i = 0; i < cadena.Length; i++)
            {
                letras[i] = cadena[i];
            }
            for (int i = 0; i < letras.Length-1; i++)
            {
                for (int j = 1; j < letras.Length - i+1; j++)
                {
                    int[] derecho = new int[j];
                    for (int k = 0; k < j; k++)
                    {
                        derecho[k] = letras[i+k];
                    }
                    Array.Sort(derecho);
                    int[] izquierdo = new int[j];
                    for (int m = letras.Length - 1; m >= i+j; m--)
                    {


                        for (int k = 0; k < j; k++)
                        {
                            izquierdo[k] = letras[ m - k];
                        }
                        Array.Sort(izquierdo);
                        if (Evaluation(derecho, izquierdo))
                        {
                            anagramas++;
                        }

                    }
                    

                }
            }
            return anagramas;
            throw new NotImplementedException();
        }
        private static bool Evaluation(int[] a, int[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    return false;
                
            }
            return true;
        }
    }
}
