using Unicam.Paradigmi.Application.Models.Dtos;

namespace Unicam.Paradigmi.Application.Models.Responses
{
    public class GetAziendeResponse
    {
        public List<AziendaDto> Aziende { get; set; } = new List<AziendaDto>();
        public int NumeroPagine { get; set; }
    }
}
