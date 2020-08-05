using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Metaheuristic
{
    public static class Helper
    {
        public static void CheckCases(IEnumerable<(int, int)> values)
        {
            int cero = 0, uno = 0, dos = 0;
            foreach (var item in values)
            {
                if (item == (0, 0))
                    cero++;
                else if (item == (0, 1))
                    uno++;
                else
                    dos++;

            }
            string p = Directory.GetCurrentDirectory() + @"\" + "tipos.txt";
            using (StreamWriter file = new StreamWriter(p, true))
            {
                //file.WriteLine($"percentajes: {percentajes}");
                file.WriteLine($"cero: {cero}");
                file.WriteLine($"uno: {uno}");
                file.WriteLine($"dos: {dos}");
                file.WriteLine();
            }
        }

        public static IEnumerable<object> GetFinalCases(IEnumerable<object> cases, IEnumerable<int> keys)
        {
            var casesArray = cases.ToArray();
            return keys.Select(p => casesArray[p]);
        }

        public static void WriteFinalCases(IEnumerable<object> finalCases)
        {
            string p = Directory.GetCurrentDirectory() + @"\" + "final.txt";
            using (StreamWriter file = new StreamWriter(p, true))
            {
                foreach (var fcase in finalCases)
                {
                    file.WriteLine(fcase);
                }
            }
        }
    }
}
