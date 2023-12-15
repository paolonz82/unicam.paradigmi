using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Abstractions;
using Unicam.Paradigmi.Test.Models;

namespace Unicam.Paradigmi.Test.Examples
{
    public class JsonSerializerExample : IExample
    {
        public async Task RunExampleAsync()
        {

        }
        public void RunExample()
        {
            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                DateFormatString = "dd/MM/yyyy",
                ContractResolver = new CamelCasePropertyNamesContractResolver()
                {

                }

            };
            string destinationPath = "Content\\alunni.json";
            var list = GetAlunni();
            SaveAsJson(destinationPath, list, jsonSerializerSettings);
            //Rileggo il json da file system
            string jsonValue = System.IO.File.ReadAllText(destinationPath);
            var listReadedFromDisk = JsonConvert.DeserializeObject<List<Alunno>>(jsonValue,jsonSerializerSettings);
            Console.ReadLine();
        }

        private List<Alunno> GetAlunni()
        {
            List<Alunno> list = new List<Alunno>();
            for (int i = 0; i < 20; i++)
            {
                var alunno = new Alunno();
                alunno.Nome = $"Nome_{i:00}";
                alunno.Cognome = $"Cognome_{i:00}";
                alunno.Matricola = $"{i:00000}";
                alunno.DataNascita = new DateTime(1990, 10, 10);

                if (i % 2 == 0)
                {
                    alunno.IndirizzoResidenza = new Indirizzo()
                    {
                        Cap = "62100",
                        Via = "VIA ROMA",
                        Citta = "MACERATA"
                    };
                }
                list.Add(alunno);
            }
            return list;
        }

        private void SaveAsJson(string path, List<Alunno> list, JsonSerializerSettings settings)
        {
            string jsonValue = JsonConvert.SerializeObject(list
                ,settings
                );

            System.IO.File.WriteAllText(path, jsonValue);
        }
    }
}
