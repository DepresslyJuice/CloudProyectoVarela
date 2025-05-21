using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Interfaces;
using VarelaProyectoCloud.Data;
using Microsoft.EntityFrameworkCore;

namespace VarelaProyectoCloud.Services
{
    public class AsistenciaService : IAsistenciaService
    {
        private readonly ApplicationDbContext _context;

        public AsistenciaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Asistencia>> GetAllAsistenciasAsync()
        {
            return await _context.Asistencias
                .Include(a => a.inscripcion)
                .Include(a => a.sesion)
                .ToListAsync();
        }

        public async Task<Asistencia?> GetAsistenciaByIdAsync(int id)
        {
            return await _context.Asistencias
                .Include(a => a.inscripcion)
                .Include(a => a.sesion)
                .FirstOrDefaultAsync(a => a.asistencia_id == id);
        }

        public async Task<Asistencia> CreateAsistenciaAsync(Asistencia asistencia)
        {
            _context.Asistencias.Add(asistencia);
            await _context.SaveChangesAsync();
            return asistencia;
        }

        public async Task<Asistencia> UpdateAsistenciaAsync(int id, Asistencia asistencia)
        {
            var existing = await _context.Asistencias.FindAsync(id);
            if (existing == null)
                return null;
            // Actualiza campos necesarios
            existing.inscripcion_id = asistencia.inscripcion_id;
            existing.sesion_id = asistencia.sesion_id;
            existing.fecha_hora = asistencia.fecha_hora;
            existing.asistio = asistencia.asistio;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsistenciaAsync(int id)
        {
            var asistencia = await _context.Asistencias.FindAsync(id);
            if (asistencia == null) return false;
            _context.Asistencias.Remove(asistencia);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Asistencia>> GetAsistenciasByInscripcionIdAsync(int inscripcionId)
        {
            return await _context.Asistencias
                .Where(a => a.inscripcion_id == inscripcionId)
                .Include(a => a.inscripcion)
                .Include(a => a.sesion)
                .ToListAsync();
        }

        public async Task<IEnumerable<Asistencia>> GetAsistenciasBySesionIdAsync(int sesionId)
        {
            return await _context.Asistencias
                .Where(a => a.sesion_id == sesionId)
                .Include(a => a.inscripcion)
                .Include(a => a.sesion)
                .ToListAsync();
        }
    }
}
