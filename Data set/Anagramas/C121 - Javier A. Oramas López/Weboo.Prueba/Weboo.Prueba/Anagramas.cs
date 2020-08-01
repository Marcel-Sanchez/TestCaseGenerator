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
            
            if (cadena.Length <= 1)
            {
                return 0;
            }

            int sol = 0;
            
            for(int i = 1; i < cadena.Length; i++)
            {
                int piv = 0;
                while(piv + i < cadena.Length)
                {
                    string cad1 = cadena.Substring(piv, i);

                    for(int j = 1; (piv+j+i) <= cadena.Length; j++)
                    {
                        string cad2 = cadena.Substring(piv + j, i);
                        if(CheckAnagram(cad1, cad2))
                        {
                            sol++;
                        }
                    }
                    piv++;
                }
                
            }
            return sol;
        }

        private static bool CheckAnagram(string cad1, string cad2)
        {
            char[] A1 = cad1.ToArray<char>();
            char[] A2 = cad2.ToArray<char>();

            Array.Sort(A1);
            Array.Sort(A2);

            for(int i = 0; i < cad1.Length; i++)
            {
                if (A1[i] != A2[i]) return false;
            }

            return true;

        }
    }
}
