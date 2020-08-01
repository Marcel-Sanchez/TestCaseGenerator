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
            int cont = 0;
            char letra = ' ';
                     string subcadena = " ";
            //if (Charequals(cadena) == false) return 0;
            if (cadena == "  ") return 0;
            for (int i = 0; i < cadena.Length; i++)
            {
                for (int j = 1; j <cadena.Length; j++)
                {
                    char c = cadena[i];
                    if (cadena[i]==cadena[j])
                    {
                        cont++;
                    


                    }
                    
                }
                for (int k= 0; k < cadena.Length / 2; k++)
                {
                    for (int j = cadena.Length - 1; j > cadena.Length / 2; j--)
                    {

                        if (cadena[k]+)
                    }
                }

            }

            return cont;
        }






        public static int Subequals(string cadena)
        {
            int luk = 0;
           
            
        }

    }
}
