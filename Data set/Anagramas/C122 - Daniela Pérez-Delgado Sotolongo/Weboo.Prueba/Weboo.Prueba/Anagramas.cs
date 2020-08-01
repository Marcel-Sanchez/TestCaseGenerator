using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weboo.Prueba
{
    public class Anagramas
    {
        public static int CantidadEnCadena (string cadena)
        {
            if (cadena == "") return 0;
            int sumatoria = (cadena.Length * (cadena.Length + 1)) / 2;
            char[][] Conjuntos =new char[sumatoria][];
            int c = -1;
            //Para hacer los subconjuntos de tamanno <= que cadena.Lenght
            for (int i = 1; i <=cadena.Length; i++)
            {
                CrearSubconjuntos(ref Conjuntos, ref c, i,cadena);
            }
            char[][] C = new char[Conjuntos.Length - 1][];
            for (int i = 0; i < C.Length; i++)
            {
                C[i] = Conjuntos[i];
            }
            return CantidadAnagramas(C);
        }
        static void CrearSubconjuntos(ref char[][] Conjunto, ref int contador, int tamano,string elemen)
        {
            for (int i = 0; i <= elemen.Length-tamano; i++)
            {
                contador++;
                Conjunto[contador] = new char[tamano];
                for (int j = 0; j < tamano; j++)
                {
                    Conjunto[contador][j] += elemen[i+j];
                }
            }
        }
        static int CantidadAnagramas(char[][] Conjunto)
        {
            int result = 0;
            for (int i = 0; i < Conjunto.Length; i++)
            {

                for (int j = i+1; j < Conjunto.Length; j++)
                {
                    //La condicion para que sean Anagramas
                    if (Conjunto[i].Length == Conjunto[j].Length && TienenLasMismasLetras(Conjunto[i], Conjunto[j]))
                    {
                        result++;
                    }
                }
            }
            return result;
        }
        static bool TienenLasMismasLetras(char[] a, char[] b)
        {
            bool[] verdad = new bool[a.Length];
            bool[] verdad2 = new bool[b.Length];
            //Estos booleanos sirven para ver sis se marcaron todas las posiciones entre los string
            //Siempre y cuando no estuviesen maracadas antes
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (!verdad[i] && !verdad2[j] && a[i] == b[j])
                    {
                        verdad[i] = true;
                        verdad2[j] = true;
                    }
                }
            }
            for (int k = 0; k < verdad.Length; k++)
            {
                if (!verdad[k]) return false;
            }
            for (int l = 0; l < verdad2.Length; l++)
            {
                if (!verdad2[l]) return false;
            }

            return true;
        }
    }
}
