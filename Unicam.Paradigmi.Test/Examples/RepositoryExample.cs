using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Abstractions;
using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;
using Unicam.Paradigmi.Models.Repositories;

namespace Unicam.Paradigmi.Test.Examples
{
    public class RepositoryExample : IExample
    {
        public async Task RunExampleAsync()
        {

        }
        public void RunExample()
        {
            var ctx = new MyDbContext();
            var aziendaRepo = new AziendaRepository(ctx);
            var dipendenteRepo = new DipendenteRepository(ctx);

            var dipendente = dipendenteRepo.Ottieni(1);
            var azienda = aziendaRepo.Ottieni(1);
            azienda.Citta = "nuova";
            aziendaRepo.Modifica(azienda);
            aziendaRepo.Save();

            var nuovoDipendente = new Dipendente();
            nuovoDipendente.DataNascita = new DateTime(2000, 1, 1);
            nuovoDipendente.Nome = "Mario";
            nuovoDipendente.Cognome = "Bianchi";
            //nuovoDipendente.IdAzienda = 5;
            
            nuovoDipendente.AziendaDoveLavora = new Azienda();
            nuovoDipendente.AziendaDoveLavora.RagioneSociale = "Nuova Azienda";
            nuovoDipendente.AziendaDoveLavora.Cap = "0123";
            nuovoDipendente.AziendaDoveLavora.Citta = "Camerino";
            nuovoDipendente.AziendaDoveLavora.IdAzienda = 5;
            
            dipendenteRepo.Aggiungi(nuovoDipendente);
            dipendenteRepo.Save();
            
           
        }

      
    }
}
