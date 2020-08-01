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
            int cant = 0;
            if (cadena.Length == 0 || cadena.Length == 1 || !SeRepitenLetras(cadena)) return 0;
            string[] subcadenas = CadenasSub(cadena);
            for (int i = 0; i < subcadenas.Length; i++)
            {
                for (int j = i+1; j < subcadenas.Length; j++)
                {
                    if (EsAnagrama(subcadenas[i], subcadenas[j]))
                        cant++;
                }
            }
            return cant;
        }
        static bool SeRepitenLetras(string cadena)
        {
            for (int i = 0; i < cadena.Length; i++)
            {
                for (int j = i + 1; j < cadena.Length; j++)
                {
                    if (cadena[i] == cadena[j])
                        return true;
                }
            }
            return false;
        }
        static bool EsAnagrama(string a,string b)
        {
            if (a.Length != b.Length)
                return false;
            bool resp = true;
            for (int i = 0; i < a.Length; i++)
            {
                if (resp == false)
                    return resp;
                for (int j = 0; j < b.Length; j++)
                {
                    resp = false;
                    if (a[i] == b[j])
                    {
                        if (CantidadDeVeces(a[i], a) != CantidadDeVeces(b[j], b))
                            return false;
                        else
                        {
                            resp = true;
                            break;
                        }
                    }    
                }
            }
            return resp; 
        }
        static int CantidadDeVeces(char a, string subcadena)
        {
            int count = 0;
            for (int i = 0; i < subcadena.Length; i++)
            {
                if (subcadena[i] == a)
                    count++;
            }
            return count;
        }
        static string[] CadenasSub(string cadena)
        {
            List<string> subcadenas = new List<string>();
            for (int i = 0; i < cadena.Length; i++)
            {
                for (int j = 1; j <= cadena.Length-i; j++)
                {
                    subcadenas.Add(cadena.Substring(i, j));
                }
            }
            return subcadenas.ToArray();
        }

    }
}
