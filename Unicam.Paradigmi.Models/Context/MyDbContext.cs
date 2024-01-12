using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Models.Configurations;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Models.Context
{
    public class MyDbContext : DbContext
    {

        public MyDbContext() : base()
        {
            
        }

        public MyDbContext(DbContextOptions<MyDbContext> config) : base(config)
        {
            
        }

        public DbSet<Azienda> Aziende { get; set; }
        public DbSet<Dipendente> Dipendenti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
               //.UseLazyLoadingProxies()
               .UseSqlServer("data source=localhost;Initial catalog=paradigmi;User Id=paradigmi;Password=paradigmi;TrustServerCertificate=True");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration<Azienda>(new AziendaConfiguration());
            
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
