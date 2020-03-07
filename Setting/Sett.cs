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

        // Porcientos de acirto para las notas
        public const int excepted3 = 30;
        public const int excepted4 = 90;

        public static float TargetFunc(float obtained3, float obtained4)
        {
            return Math.Abs(excepted3 - obtained3) + Math.Abs(excepted4 - obtained4);
        }

        public static Random Rnd = new Random();
    }
}
