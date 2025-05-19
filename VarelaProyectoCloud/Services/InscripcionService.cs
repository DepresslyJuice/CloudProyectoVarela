using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Interfaces;
using VarelaProyectoCloud.Data;
using Microsoft.EntityFrameworkCore;

namespace VarelaProyectoCloud.Services
{
    public class InscripcionService : IInscripcionService
    {
        private readonly ApplicationDbContext _context;

        public InscripcionService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Inscripcion>> GetAllInscripcionesAsync()
        {
            return await _context.Inscripciones
                .Include(i => i.evento)
                .Include(i => i.participante)
                .Include(i => i.tipo_inscripcion)   
                .ToListAsync();
        }

        public async Task<Inscripcion?> GetInscripcionByIdAsync(int id)
        {
            return await _context.Inscripciones
                .Include(i => i.evento)
                .Include(i => i.participante)
                .Include(i => i.tipo_inscripcion)
                .FirstOrDefaultAsync(i => i.inscripcion_id == id);
        }
        public async Task<Inscripcion> CreateInscripcionAsync(Inscripcion inscripcion)
        {
            _context.Inscripciones.Add(inscripcion);
            await _context.SaveChangesAsync();
            return inscripcion;
        }
        public async Task<Inscripcion> UpdateInscripcionAsync(int id, Inscripcion inscripcion)
        {
            var existing = await _context.Inscripciones.FindAsync(id);
            if (existing == null)
                return null;

            // Actualiza campos necesarios
            existing.participante_id = inscripcion.participante_id;
            existing.evento_id = inscripcion.evento_id;
            existing.fecha_inscripcion = inscripcion.fecha_inscripcion;
            existing.estado = inscripcion.estado;
            existing.tipo_inscripcion_id = inscripcion.tipo_inscripcion_id;

            await _context.SaveChangesAsync();
            return existing;
        }
        public async Task<bool> DeleteInscripcionAsync(int id)
        {
            var inscripcion = await _context.Inscripciones.FindAsync(id);
            if (inscripcion == null) return false;
            _context.Inscripciones.Remove(inscripcion);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> CancelarInscripcionAsync(int id)
        {
            var inscripcion = await _context.Inscripciones.FindAsync(id);
            if (inscripcion == null) return false;
            inscripcion.estado = "Cancelada"; // Cambia el estado a "Cancelada"
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
