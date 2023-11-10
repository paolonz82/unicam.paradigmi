using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Test.Models
{
    public class Persona
    {
        /*
        private string _nome;
        public string Nome
        {
            get
            {
                return _nome;
            }
            set
            {
                _nome = value;
            }
        }*/
        public string Nome { get;  set; }
        public string Cognome { get; set; }
        public int Eta { get; set; }
    }
}
