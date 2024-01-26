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
        private readonly IEmailService _emailService;
        public AziendaService(AziendaRepository aziendaRepository
            ,IEmailService emailService
            )
        {
            _aziendaRepository = aziendaRepository;
            _emailService = emailService;
        }
        public async Task AddAziendaAsync(Azienda azienda)
        {
            _aziendaRepository.Aggiungi(azienda);
            _aziendaRepository.Save();

            await _emailService.SendEmailAsync("Creata nuova azienda"
                ,$"Nuova azienda creata. Nome : {azienda.RagioneSociale}"
                );

        }

        public List<Azienda> GetAziende()
        {
            return new List<Azienda>();
        }

        public List<Azienda> GetAziende(int from, int num, string? name, out int totalNum)
        {
            return _aziendaRepository.GetAziende(from, num, name, out totalNum);
        }
    }
}
