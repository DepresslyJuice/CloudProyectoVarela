using Microsoft.EntityFrameworkCore;
using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Services;

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
        public DbSet<TipoInscripcion> TiposInscripcion { get; set; } = null!;
        public DbSet<Pago> Pagos { get; set; } = null!;
        public DbSet<Certificado> Certificados { get; set; } = null!;
        public DbSet<Sesion> Sesiones { get; set; } = null!;
        public DbSet<Asistencia> Asistencias { get; set; } = null!;
        public DbSet<PonenteSesion> PonenteSesiones { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PonenteSesion>()
                .HasKey(ps => new { ps.ponente_id, ps.sesion_id });

            modelBuilder.Entity<PonenteSesion>()
                .HasOne(ps => ps.ponente)
                .WithMany(p => p.ponente_sesiones)
                .HasForeignKey(ps => ps.ponente_id);

            modelBuilder.Entity<PonenteSesion>()
                .HasOne(ps => ps.sesion)
                .WithMany(s => s.ponente_sesiones)
                .HasForeignKey(ps => ps.sesion_id);
            modelBuilder.Entity<Asistencia>()
                .HasOne(a => a.sesion)
                .WithMany()
                .HasForeignKey(a => a.sesion_id)
                .OnDelete(DeleteBehavior.Restrict); // o .NoAction() en EF Core 5+

        }


    }


}