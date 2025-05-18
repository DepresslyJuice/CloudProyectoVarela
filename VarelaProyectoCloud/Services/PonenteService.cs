using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Interfaces;
using VarelaProyectoCloud.Data;
using Microsoft.EntityFrameworkCore;


namespace VarelaProyectoCloud.Services
{
    
    public class PonenteService : IPonenteService
    {
        private readonly ApplicationDbContext _context;
        public PonenteService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Ponente>> GetAllPonentesAsync()
        {
            return await _context.Ponentes.ToListAsync();
        }

        public async Task<Ponente?> GetPonenteByIdAsync(int id)
        {
            return await _context.Ponentes.FindAsync(id);
        }

        public async Task<Ponente> CreatePonenteAsync(Ponente ponente)
        {
            _context.Ponentes.Add(ponente);
            await _context.SaveChangesAsync();
            return ponente;
        }

        public async Task<bool> UpdatePonenteAsync(int id, Ponente ponente)
        {
            var existing = await _context.Ponentes.FindAsync(id);
            if (existing == null) return false;
            existing.nombre = ponente.nombre;
            existing.apellido = ponente.apellido;
            existing.email = ponente.email;
            existing.telefono = ponente.telefono;
            existing.institucion = ponente.institucion;
            existing.bio = ponente.bio;
            existing.fecha_nacimiento = ponente.fecha_nacimiento;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePonenteAsync(int id)
        {
            var ponente = await _context.Ponentes.FindAsync(id);
            if (ponente == null) return false;
            _context.Ponentes.Remove(ponente);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
