using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weboo.Prueba
{
    public class Anagramas
    {
        public static bool IsAnagrama(string cadena)
        {
            if (cadena == "")
                return false;
            if (cadena.Length == 1)
                return false;
            if (cadena.Length >= 2)
            {
                for (int i = 0; i < cadena.Length; i++)
                {
                    for (int j = 1; j < cadena.Length; j++)
                    {
                        if (cadena[i] != cadena[j++])
                            return false;
                    }
                }
                return false;
            }
            else
                return true;
        }
        public static int CantidadEnCadena(string cadena)
        {
                int cantidad = 0;// representa la cantidad de cadenas de todas las formas
                int cant1 = 0;//representa la cantidad de cadenas de la forma ['k','k']
                int cant2 = 0;//representa la cantidad de cadenas de la forma ['kk','kk']
                int cant3 = 0;//representa la cantidad de cadenas de la forma ['kkk','kkk']
              
            if (IsAnagrama(cadena) == true)
            {
                
                char[] c = new char[cadena.Length];//convertimos la palabra en un char ej: string = "mom" --char = {m o m}
                for (int i = 0; i < cadena.Length; i++)// i = posiciones en el string
                {
                    for (int j = 0; j < c.Length; j++)//j = posiciones en el char
                    {
                        c[j] = cadena[i]; // igualando posiciones 
                    }
                }
                for (int i = 0; i < c.Length; i++)
                {
                    for (int j = 1; j < c.Length; j++)
                    {
                        if (c[i] == c[j])
                            cant1++;
                        else
                            cant1 = 0;
                    }
                    return cant1; //aqui tenemos los anagramas de la forma ['k','k']

                    for (int j = 1; j < c.Length; j++)
                    {
                        if (c[i]+c[j] == c[i + 1] + c[j + 1])
                            cant2++;
                        else
                            cant2 = 0;

                    }
                    return cant2;//aqui tenemos los anagramas de la forma ['kk','kk']

                    for (int j = 1; j < c.Length; j++)
                    {
                        for (int k = 2; k < c.Length; k++)
                        {
                            if (c[i] + c[j] + c[k] == c[i + 1] + c[j + 1] + c[k + 1])
                                cant3++;
                            else
                                cant3 = 0;

                        }

                    }
                    return cant3;//aqui tenemos los anagramas de la forma ['kkk','kkk']
                    
                }
                cantidad = cant1 + cant2 + cant3;
            }
            if (IsAnagrama(cadena)==false)
                cantidad = 0;
            return cantidad;
        }
    }
}