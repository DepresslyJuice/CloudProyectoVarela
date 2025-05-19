using Microsoft.EntityFrameworkCore;
using VarelaProyectoCloud.Models;

namespace VarelaProyectoCloud.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Evento> Eventos { get; set; } = null!;
        public DbSet<Participante> Participantes { get; set; } = null!;
        public DbSet<Ponente> Ponentes { get; set; } = null!;
        public DbSet<Espacio> Espacios { get; set; } = null!;
        public DbSet<Inscripcion> Inscripciones { get; set; } = null!;
    }
}