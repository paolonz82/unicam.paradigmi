using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Abstractions.Services
{
    public interface IAziendaService
    {
        List<Azienda> GetAziende();
        void AddAzienda(Azienda azienda);
    }
}
