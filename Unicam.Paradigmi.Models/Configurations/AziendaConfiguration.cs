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
    public class AziendaConfiguration : IEntityTypeConfiguration<Azienda>
    {
        public void Configure(EntityTypeBuilder<Azienda> builder)
        {
            builder.ToTable("Aziende");
            builder.HasKey(p => p.IdAzienda);
            builder.Property(p => p.RagioneSociale)
                .HasMaxLength(100);

            builder.Property(p => p.Tipo)
                .HasColumnName("TipoAzienda")
                .HasConversion<int>();
        }
    }
}
