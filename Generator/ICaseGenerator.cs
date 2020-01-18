using System;
using System.Collections.Generic;
using System.Text;

namespace Generator
{
    interface ICaseGenerator
    {
        IEnumerable<object> GenerateCase();
    }
}
