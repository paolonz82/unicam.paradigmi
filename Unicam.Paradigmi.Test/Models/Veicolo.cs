using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Test.Models
{
    public abstract class Veicolo
    {
        public Veicolo(string nome, int velocita)
        {
            Nome = nome;
            Velocita = velocita;
        }
        public string Nome { get; set; }
        public int Velocita { get; set; }

        public void Accelera(int velocita) {
            Velocita += velocita;
        }

        public void Frena(int velocita)
        {
            Velocita -= velocita;
        }

        public virtual string VisualizzaVelocita()
        {
            return $"{Velocita} KM/H";
        }



    }
}
