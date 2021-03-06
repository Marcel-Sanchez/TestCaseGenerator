﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementations
{
    public static class SolutionComparer
    {
        public static Func<object, object, bool> EqPol = (aa, bb) => 
        {
            var a = aa as int[];
            var b = bb as int[];
            //if(a == null || b == null)

            if(a.Length != b.Length)
                return false;
            for (int i = 0; i < a.Length; i++)
                if (a[i] != b[i])
                    return false;
            return true;
        };

        public static Func<object, object, bool> EqAna = (aa, bb) =>
        {
            return (int)aa == (int)bb;
        };
    }
}
