using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Configurations
{
    public class DipendenteConfiguration : IEntityTypeConfiguration<Dipendente>
    {
        public void Configure(EntityTypeBuilder<Dipendente> builder)
        {
            builder.ToTable("Dipendenti");
            builder.HasKey(k => k.IdDipendente);
        }
    }
}
