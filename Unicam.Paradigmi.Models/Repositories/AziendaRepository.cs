using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Context;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Repositories
{
    public class AziendaRepository : GenericRepository<Azienda>
    {
        
        public AziendaRepository(MyDbContext context) : base(context)
        {

        }

        public List<Azienda> GetAziende(int from, int num, string? name, out int totalNum)
        {
            var query = _ctx.Aziende.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(w => w.RagioneSociale.ToLower().Contains(name.ToLower()));
            }

            totalNum = query.Count();

            return
                query
                .OrderBy(o=>o.RagioneSociale)
                .Skip(from)
                .Take(num)
                .ToList();
        }
    }
}
