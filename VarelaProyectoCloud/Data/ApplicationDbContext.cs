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

        // Aquí puedes agregar el resto de modelos (Sesiones, Ponentes, etc.)
    }
}