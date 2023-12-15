using Microsoft.EntityFrameworkCore;
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
    public class EntityFrameworkExample : IExample
    {
        public EntityFrameworkExample()
        {
            DbContext = new MyDbContext();
        }

        public MyDbContext DbContext { get; set; }
        public async Task RunExampleAsync()
        {
            var dipendente = await GetDipendenteByCognomeAsync("Paoloni");
            var azienda = await GetAziendaByIdAsync(1);
            var nuovaAzienda = new Azienda()
            {
                Cap = "12345",
                Citta = "Macerata",
                RagioneSociale = "Prova Inserimento"
            };
            await AddAziendaAsync(nuovaAzienda);
        }

        public async Task<Dipendente> GetDipendenteByCognomeAsync(string cognome)
        {
            return await DbContext
                .Dipendenti
                .Where(w => w.Cognome == cognome).FirstAsync();
            
        }

        public async Task<Azienda> GetAziendaByIdAsync(int id)
        {
            return await DbContext
                .Aziende
                .Where(w=>w.IdAzienda==id).FirstAsync();
        }

        public async Task AddAziendaAsync(Azienda azienda)
        {
            await DbContext.Aziende.AddAsync(azienda);
            await DbContext.SaveChangesAsync();
        }


        public void RunExample()
        {
            var ctx = new MyDbContext();
            
            LoadWithExplicitLoading(ctx);
            LoadWithEeagerLoading(ctx);
            LoadWithLazyLoading(ctx);
            //var aziende = ctx.Aziende.AsNoTracking().ToList();
            //QueryDiFiltro(ctx);
            //AddAzienda(ctx);
            //EditAziendaCompleta(ctx);
            EditProprietaAzienda(ctx);
            //DeleteAzienda(ctx);
           // UpdateConLettura(ctx);
        }

        public void LoadWithLazyLoading(MyDbContext ctx)
        {
            var dipendente = ctx.Dipendenti
             .Where(w => w.IdDipendente == 1).First();

            var nomeCittaAzienda = dipendente.AziendaDoveLavora.Citta;
        }

        public void LoadWithExplicitLoading(MyDbContext ctx)
        {
            var dipendente = ctx.Dipendenti
                .Where(w => w.IdDipendente == 1).First();

            ctx.Entry(dipendente)
                .Reference(i => i.AziendaDoveLavora)
                .Load();
        }

        public void LoadWithEeagerLoading(MyDbContext ctx)
        {
            var dipendente = ctx.Dipendenti
                .Include(i => i.AziendaDoveLavora)
                .Where(w => w.IdDipendente == 1).First();
        }

        private void UpdateConLettura(MyDbContext ctx)
        {
            var azienda = ctx.Aziende.Where(w => w.IdAzienda == 1).FirstOrDefault();
            azienda.RagioneSociale = "PCSNET MODIFICATA 3";
            ctx.SaveChanges();
        }

        private void DeleteAzienda(MyDbContext ctx)
        {
            var deleteAzienda = new Azienda();
            deleteAzienda.IdAzienda = 3;
            var entry = ctx.Entry(deleteAzienda);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            ctx.SaveChanges();
        }

        private void EditProprietaAzienda(MyDbContext ctx)
        {
            var editAzienda = new Azienda();
            editAzienda.IdAzienda = 1;
            editAzienda.RagioneSociale = "PCSNET MODIFICATA 2";
            var entry = ctx.Entry(editAzienda);
            entry.Property(p => p.RagioneSociale).IsModified = true;
            ctx.SaveChanges();
        }

        private void EditAziendaCompleta(MyDbContext ctx)
        {

            var editAzienda = new Azienda();
            editAzienda.IdAzienda = 1;
            editAzienda.RagioneSociale = "PCSNET MODIFICATA";
            editAzienda.Citta = "TOLENTINO";
            editAzienda.Cap = "12345";
            ctx.Entry(editAzienda).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            ctx.SaveChanges();
        }
        private void AddAzienda(MyDbContext ctx)
        {
            var newAzienda = new Azienda();
            newAzienda.Citta = "Civitanova Marche";
            newAzienda.Cap = "11111";
            newAzienda.RagioneSociale = "AZIENDA TEST";

            ctx.Aziende.Add(newAzienda);

            ctx.SaveChanges();

            Console.WriteLine($"Creata azienda con id {newAzienda.IdAzienda}");
        }

        private void QueryDiFiltro(MyDbContext ctx)
        {
            //Aziende che iniziano con la lettera p
            var aziendeConPSintassiSqlLite = from a in ctx.Aziende
                                             where a.RagioneSociale.StartsWith("p")
                                             select a;

            var aziendeConPSintassiFluida = ctx.Aziende
                .Where(w => w.RagioneSociale.StartsWith("p"));


            foreach (var azienda in aziendeConPSintassiFluida)
            {
                Console.WriteLine(azienda);
            }
        }
    }
}
