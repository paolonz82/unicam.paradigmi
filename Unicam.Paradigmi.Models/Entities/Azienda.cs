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
        public int IdAzienda { get; set; }
        public string RagioneSociale { get; set; }
        public string Citta { get; set; }
        public string Cap { get; set; }

        public virtual ICollection<Dipendente> Dipendenti { get; set; }

    }
}
