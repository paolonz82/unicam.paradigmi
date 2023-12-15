using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Abstractions;
using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;
using Unicam.Paradigmi.Models.Repositories;

namespace Unicam.Paradigmi.Test.Examples
{
    public class LinqExample : IExample
    {
        public async Task RunExampleAsync()
        {

        }

        public void RunExample()
        {
            var ctx = new MyDbContext();

            Func<Dipendente, bool> queryPerCognome = 
                (dipendente) => dipendente.Cognome == "Paoloni";
            
            ctx.Dipendenti.Where(queryPerCognome);
            var maxDateNascita = ctx.Dipendenti
                .Max(m => m.DataNascita);

            var minDateNascita = ctx.Dipendenti
                .Min(m => m.DataNascita);

            var queryResult = ctx.Dipendenti.ToList()
                .GroupBy(g => g.IdAzienda);


            foreach(var item in queryResult)
            {
                Console.WriteLine($"Azienda con codice {item.Key}");
                foreach(var dipendente in item.ToList())
                {
                    Console.WriteLine($"{dipendente.Cognome} {dipendente.Nome}");
                }
            }
        }

        public void Enumerazione(MyDbContext ctx)
        {

            IQueryable<Dipendente> query = ctx.Dipendenti
                .Where(w => w.IdDipendente == 1);

            bool filterByCompany = true;
            if (filterByCompany)
            {
                query = query.Where(w => w.IdAzienda == 1);
            }

            //Restituiscimi il primo
            Dipendente dip01 = query.FirstOrDefault();
            //Restituisce tutti i dipendenti che trova nella query
            List<Dipendente> listaDipendente = query.ToList();
            //Restituiscimi il primo, assicurandosi che nella query ci sia un solo risultato
            Dipendente dip02 = query.Single();
        }

        
    }
}
