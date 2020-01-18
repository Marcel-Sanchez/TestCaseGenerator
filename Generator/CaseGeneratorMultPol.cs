using System;
using System.Collections.Generic;
using System.Text;

namespace Generator
{
    public class CaseGeneratorMultPol : ICaseGenerator
    {
        Random r = new Random();
        public IEnumerable<object> GenerateCase()
        {

            int[] pol1 = new int[r.Next(1, 10)];
            int[] pol2 = new int[r.Next(1, 10)];

            for (int i = 0; i < pol1.Length; i++)
                pol1[i] = r.Next(5);

            for (int i = 0; i < pol2.Length; i++)
                pol2[i] = r.Next(5);

            return new int[][] { pol1, pol2 };
        }
    }
}
