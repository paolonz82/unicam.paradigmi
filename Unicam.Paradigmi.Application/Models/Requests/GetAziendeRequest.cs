namespace Unicam.Paradigmi.Application.Models.Requests
{
    public class GetAziendeRequest
    {
        public int PageSize { get; set; } //Rappresenta la grandezza della pagina
        public int PageNumber { get; set; } //Identifica il numero della pagina ad indice 0

        public string? Name { get; set; }

    }
}
