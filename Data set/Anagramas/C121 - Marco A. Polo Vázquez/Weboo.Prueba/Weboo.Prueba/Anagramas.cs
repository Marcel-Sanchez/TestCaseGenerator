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
            int cont = 0;

            if (cadena == "")
                return cont;

            if (cadena.Length == 1)
                return cont;

            for (int i = 0; i < cadena.Length-1; i++)
            {
                for (int j = i+1; j < cadena.Length; j++)
                {
                    for (int inicio = 1; (inicio + i) <= cadena.Length-j; inicio++)
                    {

                        string sub1 = cadena.Substring(i, j);
                        string sub2 = cadena.Substring((i + inicio), j);
                        bool[] masc = new bool[j];

                        int temp = 0;


                        for (int a = 0; a < j; a++)
                        {
                            for (int b = 0; b < j; b++)
                            {
                                if (masc[a] == true)
                                    continue;

                                if (sub1[a] == sub2[b])
                                {
                                    masc[a] = true;
                                    temp++;
                                }
                            }
                            if (temp == j)
                                cont++;
                        }
                    }
                }
            }


            return cont;

            throw new NotImplementedException();
        }
    }
}
