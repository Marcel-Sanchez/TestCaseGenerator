using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weboo.Prueba
{
    public class Anagramas
    {
        static bool IsAnagram(string a, string b)
        {
            bool v = false;
            if (a == b)
                v = true;
            else
            {
            for(int i=0; i<a.Length;i++)
                for(int j=0; j<b.Length;j++)
                    if(a.Substring(i,1)==b.Substring(j,1))
                    {
                        b=b.Remove(j, 1);
                        break;
                    }
            if (b=="")
                v = true;
            }
            return v;
        }
        public static int CantidadEnCadena (string cadena)
        {
            int r = 0;
            for (int d = 1; d < cadena.Length; d++)
                for (int i1 = 0; i1+d < cadena.Length; i1++)
                    for (int i2 = i1+1; i2+d < cadena.Length+1; i2++)
                        if(IsAnagram(cadena.Substring(i1, d), cadena.Substring(i2, d)))
                        {
                            r++;
                        }
            return r;
        }
    }
}
