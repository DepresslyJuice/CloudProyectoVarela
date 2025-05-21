using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Interfaces;
using VarelaProyectoCloud.Data;
using Microsoft.EntityFrameworkCore;

namespace VarelaProyectoCloud.Services
{
    public class SesionService : ISesionService
    {
        private readonly ApplicationDbContext _context;
        public SesionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sesion>> GetAllSesionesAsync()
        {
            return await _context.Sesiones
                .Include(s => s.evento)
                .Include(s => s.espacio)
                .ToListAsync();
        }

        public async Task<Sesion?> GetSesionByIdAsync(int id)
        {
            return await _context.Sesiones
                .Include(s => s.evento)
                .Include(s => s.espacio)
                .FirstOrDefaultAsync(s => s.sesion_id == id);
        }
        public async Task<Sesion> CreateSesionAsync(Sesion sesion)
        {
            _context.Sesiones.Add(sesion);
            await _context.SaveChangesAsync();
            return sesion;
        }

        public async Task<Sesion> UpdateSesionAsync(int id, Sesion sesion)
        {
            var existing = await _context.Sesiones.FindAsync(id);
            if (existing == null)
                return null;
            // Actualiza campos necesarios
            existing.evento_id = sesion.evento_id;
            existing.espacio_id = sesion.espacio_id;
            existing.fecha = sesion.fecha;
            existing.hora_inicio = sesion.hora_inicio;
            existing.hora_fin = sesion.hora_fin;
            existing.descripcion = sesion.descripcion;
            existing.titulo = sesion.titulo;
            await _context.SaveChangesAsync();
            return existing;
        }
        public async Task<bool> DeleteSesionAsync(int id)
        {
            var sesion = await _context.Sesiones.FindAsync(id);
            if (sesion == null) return false;
            _context.Sesiones.Remove(sesion);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Sesion>> GetSesionesByEventoIdAsync(int eventoId)
        {
            return await _context.Sesiones
                .Where(s => s.evento_id == eventoId)
                .Include(s => s.evento)
                .Include(s => s.espacio)
                .ToListAsync();
        }
        public async Task<IEnumerable<Sesion>> GetSesionesByEspacioIdAsync(int espacioId)
        {
            return await _context.Sesiones
                .Where(s => s.espacio_id == espacioId)
                .Include(s => s.evento)
                .Include(s => s.espacio)
                .ToListAsync();
        }
    }
}
