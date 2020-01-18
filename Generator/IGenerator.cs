using System;
using System.Collections.Generic;
using System.Text;

namespace Generator
{
    interface IGenerator
    {
        IEnumerable<IEnumerable<object>> GenerateCases(int k);
    }
}
