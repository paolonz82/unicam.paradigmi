using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Abstractions.Services
{
    public interface IAziendaService
    {
        List<Azienda> GetAziende();
        List<Azienda> GetAziende(int from, int num, string? name, out int totalNum);
        Task AddAziendaAsync(Azienda azienda);
    }
}
