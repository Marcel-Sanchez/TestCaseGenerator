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
            int contador = 0;
            int substring = 1;
            string prueba;
            string anagrama = "";
            
            while (substring < cadena.Length)
            {

                for (int k = 0; k < cadena.Length; k++)
                {
                    if ((k + substring) <= cadena.Length)
                        anagrama = cadena.Substring(k, substring);


                    for (int i = k + 1; i < cadena.Length; i++)
                    {
                        if ((i + substring) <= cadena.Length)
                        {
                            prueba = cadena.Substring(i, substring);

                            if (EsAnagrama(prueba, anagrama))
                                contador++;
                        }
                    }
                }
                substring++;
            }
            return contador;
        }

        public static bool EsAnagrama(string anagrama, string prueba)
        {
            int contador = 0;
            bool[] mask = new bool[anagrama.Length];


            for (int i = 0; i < prueba.Length; i++)
            {
                for (int j = 0; j < anagrama.Length; j++)
                {

                    if (prueba[i] == anagrama[j] && !mask[j])
                    {
                        mask[j] = true;
                        contador++;
                        break;
                    }
                }
            }

            return (contador == prueba.Length);
        }
    }
}
