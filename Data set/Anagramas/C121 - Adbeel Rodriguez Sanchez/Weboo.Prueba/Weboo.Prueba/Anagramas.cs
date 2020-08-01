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
            int result = 0;
            int tamano = 1;
            int index = 0;
            int countaux = 0;
            int poscant = 0;
            string aux = "";
            string[] anagramas = new string[cadena.Length];
            bool[] mask = new bool[cadena.Length];
            while (tamano<cadena.Length)
            {
                while (index<cadena.Length)
                {
                    poscant = 0;
                    aux = cadena.Substring(index, tamano);
                    anagramas[index] = aux;
                    index++;
                    for (int i = index; i < cadena.Length; i++)
                    {
                        poscant++;
                    }
                    if (poscant < tamano)
                        break;
                }
                bool[] maskaux = new bool[cadena.Length];
                bool[] maskaux1 = new bool[cadena.Length];
                for (int i = 0; i < anagramas.Length; i++)
                {
                    for (int j = i; j < anagramas.Length; j++)
                    {
                        for (int k = 0; k < anagramas[i].Length; k++)
                        {
                            for (int g = 0; g < anagramas[j].Length; g++)
                            {
                                if (i == j)
                                {
                                    break;
                                }
                                if (anagramas[j] == "" || anagramas[i] == "")
                                {
                                    break;
                                }
                                if (anagramas[i][k] == anagramas[j][g] && !maskaux[k] && !maskaux1[g])
                                {
                                    countaux++;
                                    maskaux[k] = true;
                                    maskaux1[g] = true;
                                }
                            }
                        }
                        for (int r = 0; r < maskaux.Length; r++)
                        {
                            maskaux[r] = false;
                            maskaux1[r] = false;
                        }
                        if (countaux == anagramas[i].Length)
                        {
                            result++;
                            mask[i] = true;
                        }
                        countaux = 0;
                    }
                }
                for (int i = 0; i < mask.Length; i++)
                {
                    mask[i] = false;
                }
                index = 0;
                tamano++;
            }
            return result;
        }
    }
}
