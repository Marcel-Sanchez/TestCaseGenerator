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
            int count = 0;
            char[] a = new char[cadena.Length+ cadena.Length];
            for (int i = 0; i < cadena.Length - 1; i++)
            {
                
                for (int j = i + 1; j < cadena.Length; j++)
                {

                    if (Anagrama(cadena[i].ToString(), cadena[j].ToString()))
                    {
                        a[count] = cadena[j];
                        count++;
                    }

                }
                
            }
            char[] b = new char[count];
            b = Agregar(a, b);
            for (int i = 0; i < b.Length; i++)
            {
                count += FindMatch(b[i].ToString(), cadena, FindPosition(b[i], cadena) + 1);

            }



            return count;
        }
        static int FindMatch(string a, string cadena,int index)
        {
            a = a + cadena[index];
            string b = "";
            int count = 0;
            if(index == cadena.Length - 1)
            {
                return 0;
            }
            for (int i = index,j=index; i < cadena.Length && j<cadena.Length; i++)
            {
                j = i;
                while (b.Length < a.Length)
                {
                    b = b + cadena[j];
                    j++;
                }

                if (Anagrama(a, b))
                {
                    count++;
                    b = "";
                }
                else
                    continue;

            }
            return count;
           
        }
        static bool Anagrama( string a, string b)
        {
            int count = a.Length;
            bool [] mask = new bool[b.Length];
            for (int i = 0; i <a.Length; i++)
            {
                for (int j = 0; j <b.Length; j++)
                {
                    if (a[i] == b[j]  && !mask[j])
                    {
                        mask[j] = true;
                        count--;
                    }
                }
            }
            if (count == 0)
                return true;
            return false;
        }
        static char [] Agregar ( char [] a, char [] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                if (a[i] != ' ')
                    b[i] = a[i];
            }
            return b;
        }
        static int FindPosition(char a,string cadena)
        {
            for (int i = 0; i < cadena.Length; i++)
            {
                if (cadena[i] == a)
                    return i;
            }
            return -1;
        }
      
        
    }
}
