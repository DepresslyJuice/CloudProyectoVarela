using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Interfaces;
using VarelaProyectoCloud.Data;
using Microsoft.EntityFrameworkCore;

namespace VarelaProyectoCloud.Services
{
    public class PonenteSesionService : IPonenteSesionService
    {
        private readonly ApplicationDbContext _context;
        public PonenteSesionService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PonenteSesion>> GetAllPonenteSesionesAsync()
        {
            return await _context.PonenteSesiones
                .Include(ps => ps.ponente)
                .Include(ps => ps.sesion)
                .ToListAsync();
        }
        public async Task<PonenteSesion?> GetPonenteSesionByIdAsync(int id)
        {
            return await _context.PonenteSesiones
                .Include(ps => ps.ponente)
                .Include(ps => ps.sesion)
                .FirstOrDefaultAsync(ps => ps.ponente_id == id);
        }
        public async Task<PonenteSesion> CreatePonenteSesionAsync(PonenteSesion ponenteSesion)
        {
            _context.PonenteSesiones.Add(ponenteSesion);
            await _context.SaveChangesAsync();
            return ponenteSesion;
        }
        public async Task<PonenteSesion> UpdatePonenteSesionAsync(int id, PonenteSesion ponenteSesion)
        {
            var existing = await _context.PonenteSesiones.FindAsync(id);
            if (existing == null)
                return null;
            // Actualiza campos necesarios
            existing.ponente_id = ponenteSesion.ponente_id;
            existing.sesion_id = ponenteSesion.sesion_id;
            await _context.SaveChangesAsync();
            return existing;
        }
        public async Task<bool> DeletePonenteSesionAsync(int id)
        {
            var ponenteSesion = await _context.PonenteSesiones.FindAsync(id);
            if (ponenteSesion == null) return false;
            _context.PonenteSesiones.Remove(ponenteSesion);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<PonenteSesion>> GetPonentesBySesionIdAsync(int sesionId)
        {
            return await _context.PonenteSesiones
                .Include(ps => ps.ponente)
                .Where(ps => ps.sesion_id == sesionId)
                .ToListAsync();
        }
        public async Task<IEnumerable<PonenteSesion>> GetSesionesByPonenteIdAsync(int ponenteId)
        {
            return await _context.PonenteSesiones
                .Include(ps => ps.sesion)
                .Where(ps => ps.ponente_id == ponenteId)
                .ToListAsync();
        }
    }
}
