using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Utilities
{
    public class DoubleQuoteIgnore
    {

        public static string DoubleQouteIgnore(string text)
        {
            foreach (char c in text)
            {
                if (c.Equals('"'))
                {
                    c.ToString().Replace('"', '\"');
                }
            }

            return text;
        }
    }
}
