using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Abstractions;
using Unicam.Paradigmi.Models.Context;

namespace Unicam.Paradigmi.Test.Examples
{
    public class TaskExample : IExample
    {
        public async Task RunExampleAsync()
        {
            //Prima chiamata asincrona, potrebbe essere una query
            string content = await LeggiContenutoAsync();
            await System.IO.File.WriteAllTextAsync(@"C:\tmp\test.log", content);
            Console.WriteLine("File scritto");

            var ctx = new MyDbContext();
            var dipendenti = await ctx.Dipendenti.Where(w => w.Nome == "Federico")
                .ToListAsync();

        }

        private async Task<string> LeggiContenutoAsync()
        {
            await Task.Delay(5000);
            return "Mio contenuto";
        }

        public void RunExample()
        {
            //string risultatoSomma = Somma(2, 3);
            Func<int,int, string> sommaAction = 
                (a, b) =>
                {
                    return $"La somma è {a + b}";
                    };
            Func< int,int, string> sommaActionConMetodoVero = Somma;
            string risultato1 = sommaAction(2, 3);
            string risultato2 = sommaAction(5, 8);

            CreazioneTaskConRisultato();


        }

        public void CreazioneTaskConRisultato()
        {
            int a = 2;
            int b = 5;
            var taskSomma = new Task<int>(() =>
            {
                Console.WriteLine("Sto eseguendo la somma");
                return a + b;
            });

            var taskMoltiplicazione = new Task<int>(() =>
            {
                Console.WriteLine("Sto eseguendo la moltiplicazione");
                System.Threading.Thread.Sleep(5000);
                return a * b;
            });
            Console.WriteLine("Ho finito la creazione dei task");
            Console.WriteLine("Avvio i task");
            taskSomma.Start();
            taskMoltiplicazione.Start();

            //Task.WaitAll(taskSomma, taskMoltiplicazione);

            while (taskMoltiplicazione.IsCompleted == false)
            {
                Console.WriteLine("Aspetto il completamento della moltiplicazione");
                System.Threading.Thread.Sleep(1000);
            }
            Console.WriteLine("Risultato Moltiplicazione : " + taskMoltiplicazione.Result);

            Console.WriteLine("Risultato Somma : " + taskSomma.Result);
        }

        public void CreazioneTaskSemplici()
        {
            var task1 = new Task(() =>
            {
                Console.WriteLine("Sto eseguendo il primo task");
            });

            var task2 = new Task(() =>
            {
                System.Threading.Thread.Sleep(10000);
                Console.WriteLine("Sto eseguendo il secondo task");
            });

            task1.Start();
            task2.Start();
            Console.WriteLine("Ho eseguito tutti e due i task");
        }
        public string Somma(int a,int b)
        {
            return $"La somma è {a+ b}";
        }

        
    }
}
