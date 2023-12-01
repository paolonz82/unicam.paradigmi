using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Repositories
{
    public class DipendenteRepository : GenericRepository<Dipendente>
    {
        
        public DipendenteRepository(MyDbContext ctx) : base(ctx)
        {
        }
       
        
        public List<Dipendente> GetDipendentiByCodiceAzienda(int idAzienda)
        {
            return _ctx.Dipendenti
                .Where(w => w.IdAzienda == idAzienda)
                .ToList();
        }

        
    }
}
