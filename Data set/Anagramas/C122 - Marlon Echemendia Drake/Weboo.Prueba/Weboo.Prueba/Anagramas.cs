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
            /*
             *Tomo un substring de cadena desde la posicion i de tamaño j,
             *luego genero todos los substring de cadena de tamaño j desde i + 1,
             *verifico que sean anagramas y aumento contador
             */
            
            //esto no hace falta creo pero bueno
            if (cadena.Equals(string.Empty))
                return 0;

            int result = 0;

            //este me dice a partir de que posicion del array voy a crear el string principal
            for (int main_index = 0; main_index < cadena.Length; main_index++)
            {
                //este me dice el tamaño que va a tener mi string principal a partir de la posicion del for anterior
                for (int size = 1; main_index + size - 1 < cadena.Length; size++)
                {
                    //el string con el que voy a comparar todo lo que venga 
                    string main_word = cadena.Substring(main_index, size);

                    //este es el que me dice a partir de que posicion  voy a comparar con el string principal, pivote
                    for (int sec_index = main_index + 1; sec_index + size - 1 < cadena.Length; sec_index++)
                    {
                        //el string que voy a comparar al principal
                        string sec_word = cadena.Substring(sec_index, size);

                        //el punchline
                        if (SonAnagramas(main_word, sec_word))
                            result++;
                    }
                }
            }

            return result;
        }

        public static bool SonAnagramas(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;

            char[] _s1 = s1.ToCharArray(), _s2 = s2.ToCharArray();
            Array.Sort<char>(_s1);
            Array.Sort<char>(_s2);

            for (int i = 0; i < _s1.Length; i++)
                if (_s1[i] != _s2[i])
                    return false;

            return true;
        }
    }
}
