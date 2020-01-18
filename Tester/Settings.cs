using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settings
{
    public static class Setting
    {
        public const string MethodNameImpl3 = "MultPol3";
        public const string MethodNameImpl4 = "MultPol4";
        public const string MethodNameImpl5 = "MultPol5";


        public static string[] MethodNames = { MethodNameImpl3, MethodNameImpl4, MethodNameImpl5 };
        public const int PosSolution5 = 2;

        public const string DllName = "Implementations";
        public const string ClassName = "Implementation";
    }
}
