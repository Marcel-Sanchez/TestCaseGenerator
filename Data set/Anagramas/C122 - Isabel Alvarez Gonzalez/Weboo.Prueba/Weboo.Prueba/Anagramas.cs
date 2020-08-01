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
            
            for (int i = 0; i < cadena.Length/2; i++)
            {
                string temp = "";
                
                for (int j = 0; j < cadena.Length; j++)
                {
                    if (i > 0)
                        temp = cadena[i].ToString();
                     temp +=cadena[j];
                    
                   if (Substring(cadena, temp))
                        cont++;
                    
                }
            }
            return cont;
        }
        static bool Substring(string todo, string buscar)
        {
            if (todo.Length == buscar.Length)
                return false;
            int antes = 0;
            int desp = 0;
            bool temp = false;
            for (int i = 0; i < buscar.Length; i++)
            {
                int pos = 0;
                for (int j = 0; j < todo.Length - 1; j++)
                {
                    if (buscar[i] == todo[1 + j])
                    {
                        temp = true;
                        pos = 1 + j;
                        antes = pos--;
                        desp = pos++;
                        if (todo[antes] == buscar[i])
                            temp = true;
                        

                        if (pos < todo.Length - 1 && todo[desp] == buscar[i])
                            temp = true;
                        return false;
                    }     
                }
                
                
                
            }
            return temp;
        }
        }
    }
    

