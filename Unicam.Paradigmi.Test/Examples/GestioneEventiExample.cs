using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Abstractions;
using Unicam.Paradigmi.Test.Models;

namespace Unicam.Paradigmi.Test.Examples
{
    public class GestioneEventiExample : IExample
    {
        public async Task RunExampleAsync()
        {

        }
        public void RunExample()
        {
            //*************************************//

            //GESTIONE DI EVENTI//

            ArrayList listaArticoli = CreaListaArticoli();

            foreach (Articolo articolo in listaArticoli)
            {
                articolo.QtaMagazzino -= 8;
            }

            ArrayList CreaListaArticoli()
            {
                var lista = new ArrayList();
                for (int i = 0; i < 10; i++)
                {
                    var articolo = new Articolo();
                    articolo.CodiceArticolo = $"CODART{i:000}";
                    articolo.Descrizione = $"DESCART{i:000}";
                    Random rdm = new Random();
                    articolo.QtaMagazzino = rdm.Next(10, 20);
                    articolo.LivelloScortaMinima = articolo.QtaMagazzino / 2;
                    articolo.SottoScortaEvent += Articolo_SottoScortaEvent;
                    lista.Add(articolo);
                }
                return lista;
            }

            void Articolo_SottoScortaEvent(Articolo art, DateTime data)
            {
                Console.WriteLine($"L'articolo {art.CodiceArticolo} è andato sotto scorta. Qta Magazzino : {art.QtaMagazzino} Livello Scorta Minimo : {art.LivelloScortaMinima}");
            }

        }
    }
}
