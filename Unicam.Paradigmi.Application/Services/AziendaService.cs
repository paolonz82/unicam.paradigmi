using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Application.Services
{
    public class AziendaService : IAziendaService
    {
        public List<Azienda> GetAziende()
        {
            return new List<Azienda>();
        }
    }
}
