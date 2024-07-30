using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using nexti.Domain.Models;
using nexti.Infrastructure.Persistence.Config;

namespace nexti.Infrastructure.Persistence.Context
{
    public class NTContext : DbContext
    {
        // constructor del contexto
        public NTContext(DbContextOptions<NTContext> options) : base(options) { }

        // entidades
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }

        // configuración de relaciones y entidades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new EventoConfig());
        }
    }
}
