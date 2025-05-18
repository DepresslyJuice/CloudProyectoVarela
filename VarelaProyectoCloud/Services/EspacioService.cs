using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Interfaces;
using VarelaProyectoCloud.Data;
using Microsoft.EntityFrameworkCore;

namespace VarelaProyectoCloud.Services
{
    public class EspacioService : IEspacioService
    {
        public readonly ApplicationDbContext _context;

        public EspacioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Espacio>> GetAllEspaciosAsync()
        {
            return await _context.Espacios.ToListAsync();
        }

        public async Task<Espacio?> GetEspacioByIdAsync(int id)
        {
            return await _context.Espacios.FindAsync(id);
        }
        public async Task<Espacio> CreateEspacioAsync(Espacio espacio)
        {
            _context.Espacios.Add(espacio);
            await _context.SaveChangesAsync();
            return espacio;
        }
        public async Task<bool> UpdateEspacioAsync(int id, Espacio espacio)
        {
            var existing = await _context.Espacios.FindAsync(id);
            if (existing == null) return false;
            existing.nombre = espacio.nombre;
            existing.descripcion = espacio.descripcion;
            existing.capacidad = espacio.capacidad;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteEspacioAsync(int id)
        {
            var espacio = await _context.Espacios.FindAsync(id);
            if (espacio == null) return false;
            _context.Espacios.Remove(espacio);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
