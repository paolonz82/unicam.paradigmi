using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Models.Entities
{
    
    public class Azienda
    {
       /*
        public Azienda()
        {
            RagioneSociale = string.Empty;
            Citta = string.Empty;
            Cap = string.Empty;
            Dipendenti = new List<Dipendente>();
        }
       */
        public int IdAzienda { get; set; }
        public string RagioneSociale { get; set; } = string.Empty;
        public string Citta { get; set; } = string.Empty;
        public string Cap { get; set; } = string.Empty;

        public virtual ICollection<Dipendente> Dipendenti { get; set; } = null!;

    }
}
