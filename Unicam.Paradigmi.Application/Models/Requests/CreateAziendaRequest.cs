using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests
{
    public class CreateAziendaRequest
    {
        public string RagioneSociale { get; set; } = string.Empty;
        public string Citta { get; set; } = string.Empty;
        public string Cap { get; set; } = string.Empty;

        public Azienda ToEntity()
        {
            var azienda = new Azienda();
            azienda.RagioneSociale = RagioneSociale;
            azienda.Citta = Citta;
            azienda.Cap = Cap;
            return azienda;
        }

    }
}
