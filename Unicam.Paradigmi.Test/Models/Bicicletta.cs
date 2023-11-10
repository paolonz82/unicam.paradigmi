using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Test.Models
{
    public class Bicicletta : Veicolo
    {
        public Bicicletta(string nome, int velocita)
            : base(nome,velocita)
        {
            
        }

        public override string VisualizzaVelocita()
        {
            return $"Bicicletta :  {base.VisualizzaVelocita()}";
        }

    }
}
