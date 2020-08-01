using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weboo.Prueba
{
    public class Anagramas
    {
        public static int[] Substring(int[] posiciones)
        {
            string cadena = "";
            if (Convert.ToDouble(cadena) == 0) throw new Exception("La cadena esta vacia");
            if (cadena == null) throw new Exception("La cadena no puede ser null");
            for (int i = 0; i < posiciones.Length; i++)
            {
                for (int j = i + 1; j < posiciones.Length; j++)
                {
                    if (posiciones[i] != posiciones[j + 1]) throw new Exception("No hay pares de substring");
                    if (posiciones[i] == posiciones[j + 1]) return posiciones;
                }
            }
            return posiciones;
        }
        public static int CantidadEnCadena(string cadena)
        {
            int[] posiciones = new int[0];
            int pares = 0;
            if (cadena == "") return 0;
            if (cadena == null) throw new Exception("La cadena no puede ser null");
            for (int i = 0; i < posiciones.Length; i++)
            {
                for (int j = i + 1; j < posiciones.Length; j++)
                {
                    if (posiciones[i] != posiciones[j + 1]) throw new Exception("No hay pares de substring");
                    if (posiciones[i] == posiciones[j + 1]) return pares;
                }
            }
            return pares;
        }

    }

}

