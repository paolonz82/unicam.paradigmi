using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Models.Entities;
using Unicam.Paradigmi.Models.Repositories;

namespace Unicam.Paradigmi.Application.Services
{
    public class AziendaService : IAziendaService
    {
        private readonly AziendaRepository _aziendaRepository;
        public AziendaService(AziendaRepository aziendaRepository)
        {
            _aziendaRepository = aziendaRepository;
        }
        public void AddAzienda(Azienda azienda)
        {
            _aziendaRepository.Aggiungi(azienda);
            _aziendaRepository.Save();
        }

        public List<Azienda> GetAziende()
        {
            return new List<Azienda>();
        }


    }
}
