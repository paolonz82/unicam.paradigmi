using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Abstractions;
using Unicam.Paradigmi.Test.Models;

namespace Unicam.Paradigmi.Test.Examples
{
    public class EreditarietaExample : IExample
    {
        public async Task RunExampleAsync()
        {

        }
        public void RunExample()
        {
            List<Veicolo> veicoli = new List<Veicolo>();
            veicoli.Add(new Bicicletta("Graziella", 10));
            veicoli.Add(new Macchina("GOLF", 0, 1));

            foreach(var veicolo in veicoli)
            {
                
            }
        }
    }
}
