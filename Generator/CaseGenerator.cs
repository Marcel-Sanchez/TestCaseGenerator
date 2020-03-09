using System;
using System.Collections.Generic;
using System.Text;

namespace Generator
{
    public class CaseGenerator : IGenerator
    {
        public IEnumerable<IEnumerable<object>> GenerateCases(int k)
        {
            CaseGeneratorMultPol caseGen = new CaseGeneratorMultPol();
            IEnumerable<object>[] cases = new IEnumerable<object>[k];
            while(k-- > 0)
            {
                cases[k] = caseGen.GenerateCase();
            }
            return cases;
        }
    }
}
