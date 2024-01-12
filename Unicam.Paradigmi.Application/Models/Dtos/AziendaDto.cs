using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Models.Dtos
{
    public class AziendaDto
    {
        public AziendaDto()
        {
            
        }

        public AziendaDto(Azienda azienda)
        {
            //Possibile effettuare mapping automatico con libreria AutoMapper
            Id = azienda.IdAzienda;
            RagioneSociale = azienda.RagioneSociale;
            Citta = azienda.Citta;
            Cap = azienda.Cap;
        }

        public int Id { get; set; }
        public string RagioneSociale { get; set; } = string.Empty;
        public string Citta { get; set; } = string.Empty;
        public string Cap { get; set; } = string.Empty;
    }
}
