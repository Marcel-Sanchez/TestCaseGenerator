using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementations
{
    public class Anagramas
    {
        public static int Anagramas5(string s)
        {
            int cnt = 0;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    for (int k = 1; k + j <= s.Length; k++)
                    {
                        var s1 = s.Substring(i, k);
                        var s2 = s.Substring(j, k);
                        
                        if (EsAnagrama(s1, s2))
                            cnt++;
                    }
                }
            }
            return cnt;
        }

        

        public static int Anagramas4(string s)
        {
            int cnt = 0;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    for (int k = 2; k + j <= s.Length; k++)
                    {
                        var s1 = s.Substring(i, k);
                        var s2 = s.Substring(j, k);

                        if (EsAnagrama(s1, s2))
                            cnt++;
                    }
                }
            }
            return cnt;
        }

        public static int Anagramas3(string s)
        {
            if (s == "") return 1;
            int cnt = 0;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    for (int k = 2; k + j <= s.Length; k++)
                    {
                        var s1 = s.Substring(i, k);
                        var s2 = s.Substring(j, k);

                        if (EsAnagrama(s1, s2))
                            cnt++;
                    }
                }
            }
            return cnt;
        }
        private static bool EsAnagrama(string s1, string s2)
        {
            return string.Concat(s1.OrderBy(p => p)) == string.Concat(s2.OrderBy(p => p));

        }
    }
}
