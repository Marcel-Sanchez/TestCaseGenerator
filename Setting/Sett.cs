using System;
using System.Collections.Generic;
using System.Text;

namespace Setting
{
    public static class Sett
    {
        public const string MethodNameImpl3 = "MultPol3";
        public const string MethodNameImpl4 = "MultPol4";
        public const string MethodNameImpl5 = "MultPol5";


        public static string[] MethodNames = { MethodNameImpl3, MethodNameImpl4, MethodNameImpl5 };
        public const int PosSolution5 = 2;

        public const string DllName = "Implementations";
        public const string ClassName = "Implementation";

        // Porcientos de acierto para las notas
        public const int Excepted3 = 30;
        public const int Excepted4 = 90;

        // Número de casos de prueba agenerar
        public const int CasesToGenerate = 500;
        // Número inicial de la población a generar.
        public static int MembersToGenerate = 10;
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
