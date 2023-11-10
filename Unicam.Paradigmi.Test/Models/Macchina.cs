using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Test.Models
{
    public class Macchina : Veicolo
    {
        public Macchina(string nome
            ,int velocita
            ,int marcia
            ) : base(nome,velocita)
        {
            Marcia = marcia;
        }

        public int Marcia { get; set; }

        public override string VisualizzaVelocita()
        {
            return $"Macchina {base.VisualizzaVelocita()}";
        }
    }
}
