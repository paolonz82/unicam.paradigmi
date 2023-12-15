using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Abstractions;
using Unicam.Paradigmi.Test.Models;

namespace Unicam.Paradigmi.Test.Examples
{
    public class RisultatoGenericoExample : IExample
    {
        public async Task RunExampleAsync()
        {

        }
        public void RunExample()
        {
            
        }

        private Result<List<Persona>> GetAlunniFromWebApi()
        {
            //TODO : Chiamata alla web api, 
            var alunni = new List<Persona>();
            alunni.Add(new Persona { Nome = "Federico"
            ,Cognome  ="Paoloni"
            , Eta = 41
            });

            return new Result<List<Persona>>()
            {
                Success = true,
                Message = string.Empty,
                Data = alunni
            };
        }

        private Result<string> GetMatricola()
        {
            return new Result<string>()
            {
                Success = true,
                Message = string.Empty,
                Data = "12345"
            };
        }
    }
}
