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
            int caract = cadena.Length;
            int cantidad = 0;
            if (caract == 0)
                return 0;
            if (cadena.Substring(0, caract) == "")
                return 0;
            for (int j = 0; j < caract; j++)
            {
                for (int i = j + 1; i < caract; i++)
                {
                    if (cadena.Substring(j, 1) == cadena.Substring(i, 1))
                        cantidad++;

                }
            }

            cantidad += ContarSubStrings(cadena);
            return cantidad;

        }
        public static int ContarSubStrings(string a)
        {
            int cantidad = 0;
            int caract = a.Length;
            for (int h = 2; h < caract; h++)
            {
                for (int i = 0; i < caract; i++)
                {
                    if (i + h > caract)
                        break;
                    for (int j = i + 1; j < caract - 1; j++)
                    {
                        if (j + h > a.Length)
                            break;
                        if (CompararSubs(a.Substring(i, h), a.Substring(j, h)))
                        {
                            cantidad++;
                        }
                    }
                }
            }
            return cantidad;
        }
        public static bool CompararSubs(string a, string b)
        {

            
            string[] a1 = new string[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                a1[i] = a.Substring(i, 1);
            }
            string[] b1 = new string[b.Length];
            for (int i = 0; i < b.Length; i++)
            {
                b1[i] = b.Substring(i, 1);
            }
         
            bool [] m1 = new bool [a1.Length];
            bool [] m2 = new bool [b1.Length];
            for (int i = 0; i < m1.Length; i++)
            {
                m1[i] = true;
            }
            for (int i = 0; i < a1.Length; i++)
            {
                for (int j = 0; j < a1.Length; j++)
                {
                    if (m2[j] != true)
                    {
                        if (a[i] == b[j])
                        {
                            m2[j] = true;
                            break;
                        }
                    }
                
                }
            }
            for (int i = 0; i < m1.Length; i++)
            {
            if (m1[i] != m2[i])
           return false;

            }

            
            return true;

        }
    }
}
