using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementations
{
    class Implementation
    {
        public static int[] MultPol5(string[] aa, string[] bb)
        {
            var a = GetIntArray(aa);
            var b = GetIntArray(bb);

            if (a.Length == 1 && a[0] == 0 || b.Length == 1 && b[0] == 0)
                return new[] { 0 };

            int[] result = new int[a.Length + b.Length - 1];

            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < b.Length; j++)
                    result[i + j] += a[i] * b[j];

            return result;
        }
        public static int[] MultPol5(int[] a, int[] b)
        {
            if (a.Length == 1 && a[0] == 0 || b.Length == 1 && b[0] == 0)
                return new[] { 0 };

            int[] result = new int[a.Length + b.Length - 1];

            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < b.Length; j++)
                    result[i + j] += a[i] * b[j];

            return result;
        }
        public static int[] MultPol4(string[] aa, string[] bb)
        {
            var a = GetIntArray(aa);
            var b = GetIntArray(bb);

            int[] result = new int[a.Length + b.Length - 1];

            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < b.Length; j++)
                    result[i + j] += a[i] * b[j];

            return result;
        }
        public static int[] MultPol4(int[] a, int[] b)
        {
            int[] result = new int[a.Length + b.Length - 1];

            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < b.Length; j++)
                    result[i + j] += a[i] * b[j];

            return result;
        }

        public static int[] MultPol3(string[] aa, string[] bb)
        {
            var a = GetIntArray(aa);
            var b = GetIntArray(bb);

            int[] result = new int[a.Length + b.Length - 1];

            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < b.Length; j++)
                    result[i + j] = a[i] * b[j];

            return result;
        }
        public static int[] MultPol3(int[] a, int[] b)
        {
            int[] result = new int[a.Length + b.Length - 1];

            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < b.Length; j++)
                    result[i + j] = a[i] * b[j];

            return result;
        }
        private static int[] GetIntArray(string[] aa)
        {
            int[] a = new int[aa.Length];
            for (int i = 0; i < aa.Length; i++)
            {
                a[i] = int.Parse(aa[i]);
            }
            return a;
        }
    }
}