using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Abstractions;
using Unicam.Paradigmi.Test.Extensions;

namespace Unicam.Paradigmi.Test.Examples
{
    public class ExtensionMethodExample : IExample
    {
        public void RunExample()
        {
            string cognome = "paoloni";
            bool isValid = cognome.PiuCortaDi(40);
        }
    }
}
