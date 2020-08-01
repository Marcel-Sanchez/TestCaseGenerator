using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weboo.Prueba
{
    public class Anagramas
    {
        private string s = "mom";
      
        public static int CantidadEnCadena (string cadena)
        {
            int cont = 0;//para ir llevando la cantidad de anagramas que se han podido construir

             if (cadena == "") return cont;
             if (cadena.Length == 1) return cont;
             if (!CaracterRepetido(cadena)) return cont+1;
             if(CaracterRepetido(cadena))return cont = cont+1+Formando(cadena);

             return cont;

        }

        public static int Formando(string cadena)
        {
            int cont = 0;
            string s = "";
            for (int i = 0; i < cadena.Length; i++)
            {
                if (cadena[i] != cadena[i+1])
                {
                    cadena.Substring(i, cadena.Length -( i + 1));
                    cont++;
                }
            }

            return cont;
        }

        public static bool CaracterRepetido(string cadena)
        {
            bool marc = false;
           
           

            for (int i = 0; i < cadena.Length; i++)
            {
                if (cadena[0] ==cadena[i] )
                {
                    marc = true;
                    

                }
                
            }
            return marc;
        }

       }
}
