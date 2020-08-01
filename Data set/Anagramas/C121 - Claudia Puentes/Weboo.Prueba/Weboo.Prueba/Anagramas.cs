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
            for (int i = cadena.Length - 1; i > 0; i--)
            {
                cant += BuscandoSubstring(cadena, i);
            }
            return cant;
        }

        private static int BuscandoSubstring(string cadena, int longitud)
        {
            int cont = 0;
            string[] provando = new string[longitud];
            string[] s1 = new string[longitud];
            for (int l = 0; l < provando.Length; l++)
            {
                provando[l] = cadena[l].ToString();
            }
            int j = 0;
            int i = 1;
            int h = i;
            int k = 1;
            while (i<cadena.Length)
            {
                s1[j++] = cadena[i].ToString();
                if (j == longitud)
                {
                    if (TienenLasMismasLetras(provando, s1)) cont++;
                    j = 0;
                    if (i == cadena.Length-1)
                    {
                        ModificandoProvando(provando,cadena,k);
                        i = k + 1;
                        h = i;
                        k++;
                        continue;

                    }
                    else
                    {
                        i = h + 1;
                        h++;
                        continue;
                    }
                }
                i++;
            }
            #region MyRegion
//for (int i = h; i < cadena.Length; i++)
            //{
            //    s1[j++] = cadena[i].ToString();

            //    if (j == longitud)
            //    {
            //        if (TienenLasMismasLetras(provando, s1)) cont++;
            //        j = 0;
            //        if (i == cadena.Length - 1)
            //        {
            //            ModificandoProvando(provando, cadena);
            //            i = h;
            //            h++;
            //            continue;
            //        }

            //        i = cadena.Length - i - 1;

            //    }

            //}
            #endregion
            
            return cont;
        }

        private static void ModificandoProvando(string[] provando, string cadena,int k)
        {
           
            for (int i = 0; i < provando.Length; i++)
            {
                provando[i] = cadena[k].ToString();
                k++;
            }
        }

        private static bool TienenLasMismasLetras(string[] provando, string[] s1)
        {
            for (int i = 0; i < provando.Length; i++)
            {
                if (SeRepite(provando[i], provando) != SeRepite(provando[i], s1)) return false;
            }
            return true;
        }

        public static int SeRepite(string k, string[] s1)
        {
            int cont = 0;
           
            for (int i = 0; i < s1.Length; i++)
            {
                if (k == s1[i]) cont++;
            }
            return cont;
        }
        private static bool SeEncuentra(string s, string[] provando)
        {
            for (int i = 0; i < provando.Length; i++)
            {
                if (s == provando[i]) return true;
            }
            return false;
        }
    }
}
