using System;
using System.Collections.Generic;
using System.Text;

namespace Setting
{
    public static class Sett
    {
        public const string MethodPolImpl3 = "MultPol3";
        public const string MethodPolImpl4 = "MultPol4";
        public const string MethodPolImpl5 = "MultPol5";
        public static string[] MethodPolNames = { MethodPolImpl3, MethodPolImpl4, MethodPolImpl5 };

        public const string MethodAnaImpl3 = "Anagramas3";
        public const string MethodAnaImpl4 = "Anagramas4";
        public const string MethodAnaImpl5 = "Anagramas5";
        public static string[] MethodAnaNames = { MethodAnaImpl3, MethodAnaImpl4, MethodAnaImpl5 };


        public const int PosSolution5 = 2;

        public const string DllName = "Implementations";
        public const string ClassPolName = "Implementation";
        public const string ClassAnaName = "Anagramas";

        // Porcientos de acierto para las notas
        public const int Excepted3 = 80;
        public const int Excepted4 = 95;

        // Número de casos de prueba agenerar
        public const int CasesToGenerate = 250;
        // Número inicial de la población a generar.
        //public static int MembersToGenerate = 10;
        // Número de casos Totales
        public static int CaseNumber = 0;

        public static float TargetFunc(float obtained3, float obtained4)
        {
            return Math.Abs(Excepted3 - obtained3) + Math.Abs(Excepted4 - obtained4);
        }
        public static float TargetFunc(ValueTuple<float, float> percentajes)
        {
            return Math.Abs(Excepted3 - percentajes.Item1) + Math.Abs(Excepted4 - percentajes.Item2);
        }

        public static Random Rnd = new Random();
    }
}
