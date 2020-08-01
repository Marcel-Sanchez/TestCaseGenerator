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
            // Elimine esta linea e implemente su solucion aqui.
            if (cadena == "")
                return 0;

            int result = 0;
          

            for (int cont = 1; cont < cadena.Length + 1; cont++)
            {
                for (int i = 0; i < cadena.Length - 1; i++)
                {
                    string pivot = "";
                    if (i + cont <= cadena.Length)
                        pivot = pivot + cadena.Substring(i, cont);

                    for (int j = i+1; j < cadena.Length; j++)
                    {
                        string temp = "";
                        if (j + cont <= cadena.Length)
                            temp = temp + cadena.Substring(j, cont);

                        if(temp!="")
                            if (Comparar(pivot, temp))
                            {
                                result++;
                            }
                    }



                }

            }

            return result;
        }
        public static bool Comparar(string a,string b)
        {
            bool[] amask = new bool[a.Length];
            bool[] bmask = new bool[b.Length];

            for (int i = 0; i < amask.Length; i++)
            {
                amask[i] = false;
                bmask[i] = false;
            }

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (bmask[j] == false)
                    {
                        if (a[i] == b[j])
                        {
                            amask[i] = true;
                            bmask[j] = true;
                            break;
                        }
                    }

                }
            }

            for (int x = 0; x < amask.Length; x++)
            {
                if (amask[x] == false)
                    return false;
            }

            return true;
        }

    }
}
