using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Abstractions;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Test.Examples
{
    public class AdoNetExample : IExample
    {
        public async Task RunExampleAsync()
        {

        }
        public void RunExample()
        {
            GetAziende();
        }

        private List<Azienda> GetAziende()
        {
            List<Azienda> list = new List<Azienda>();
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = "Server=localhost;Database=Paradigmi;User Id=paradigmi;Password=paradigmi;";
                connection.Open();

                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT IdAzienda,RagioneSociale,Cap,Citta FROM Aziende";
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var azienda = new Azienda();
                            azienda.IdAzienda = (int)reader["IdAzienda"];
                            azienda.RagioneSociale = (string)reader["RagioneSociale"];
                            azienda.Cap = (string)reader["Cap"];
                            azienda.Citta = (string)reader["Citta"];
                            list.Add(azienda);
                        }
                    }
                }
            }
            return list;
        }

        private void AddAzienda()
        {
            // STEP 1 : Inizializzo la connessione
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = "Server=localhost;Database=Paradigmi;User Id=paradigmi;Password=paradigmi;";
                connection.Open();

                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO Aziende(RagioneSociale,Citta,Cap) VALUES(@RAGIONE_SOCIALE,@CITTA,@CAP);";
                cmd.Parameters.AddWithValue("@RAGIONE_SOCIALE", "UNICAM");
                cmd.Parameters.AddWithValue("@CITTA", "Camerino");
                cmd.Parameters.AddWithValue("@CAP", "98765");
                cmd.ExecuteNonQuery();
            }
        }
    }
}
