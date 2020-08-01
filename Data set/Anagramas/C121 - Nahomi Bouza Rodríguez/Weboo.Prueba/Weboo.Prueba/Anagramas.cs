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
            if (cadena == "")
                return 0;
            int count_anagramas = 0;
            for (int i = 0; i < cadena.Length; i++)
            {
                for (int k = 1; k < (cadena.Length - i); k++)
                {
                    for (int j = 1; j <= cadena.Length; j++)
                    {
                        string prueba_1 = cadena.Substring(i, k);
                        if ((i + j) == cadena.Length)
                            break;
                        if ((i + j + k) == cadena.Length + 1)
                            break;
                        string prueba_2 = cadena.Substring(i + j, k);
                        bool[] mask_n = new bool[prueba_1.Length];
                        bool[] mask_m = new bool[prueba_2.Length];
                        for (int m = 0; m < prueba_1.Length; m++)
                        {
                            for (int n = 0; n < prueba_2.Length; n++)
                            {
                                if (!mask_n[n]&& !mask_m[m])
                                {
                                    if (prueba_1[m] == prueba_2[n])
                                    {
                                        mask_n[n] = true;
                                        mask_m[m] = true;
                                    }
                                }
                            }
                        }
                        int count_true = 0;
                        for (int p = 0; p < mask_n.Length; p++)
                        {
                            if (mask_n[p] == true)
                                count_true++;
                            else
                                break;
                        }
                        if (count_true == mask_n.Length)
                            count_anagramas++;
                    }
                }
            }
            return count_anagramas;
        }
    }
}
