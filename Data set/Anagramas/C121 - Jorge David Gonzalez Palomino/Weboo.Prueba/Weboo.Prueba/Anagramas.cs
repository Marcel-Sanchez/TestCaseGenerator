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
            string temp = "";
            int cont = 0;
            for (int i = 0; i < cadena.Length; i++)
            {


                temp = temp+cadena[i];
                cont =cont+ Contains(cadena, temp);



            }
            return cont;
        }
        public static int Contains(string cadena, string temp)
        {

            int cont = 0;
            string temporal2 = "";
            int i = 0;
            int contj = 0;
            int j = 1;


           
            

                while (j+contj < cadena.Length && i < temp.Length)
                { if (temp[i] == cadena[j])
                    {
                        temporal2 += cadena[j];
                        i++; j++;
                        if (i == temp.Length)
                        {
                            if (temp == temporal2)
                        {
                                cont++;
                                temporal2 = "";
                                j = 1;
                                contj++;


                            }
                            else if (Inverso(temp) == temporal2)
                            {
                                cont++;
                                temporal2 = "";
                                j = 1;
                                contj++;
                                continue;

                            }
                        }
                    }
                    else
                    {
                        temporal2 += cadena[j];
                        j++;
                    }

                }

                
            


            return cont;
        }
        public static string Inverso(string temp)
        {
            string inverso = "";
            for (int i = 0; i < temp.Length; i++)
            {
                inverso += temp[temp.Length - 1 - i];
            }
            return inverso;
        }
        public static bool Letras(string temp,string temp2)
        {
            int cont = 0;
            for(int i=0;i<temp.Length;)
            {
                for(int j = 0; j < temp2.Length; j++)
                {
                    if (temp[i] != temp2[j]) { i++;if (temp[i] == temp2[j]) { cont++; i = 0;i=i + cont; } }

                        
                }
               
            }
        }
    }
      
    
}
