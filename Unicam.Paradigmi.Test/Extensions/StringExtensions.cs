using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Test.Extensions
{
    public static class StringExtensions
    {
        public static bool PiuCortaDi(this string str, int numChar)
        {
            return str.Length < numChar;
        }
    }
}
