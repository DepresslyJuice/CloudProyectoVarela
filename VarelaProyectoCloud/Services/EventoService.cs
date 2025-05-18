using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Interfaces;
using VarelaProyectoCloud.Data;
using Microsoft.EntityFrameworkCore;

namespace VarelaProyectoCloud.Services
{
    public class EventoService : IEventoService
    {
        private readonly ApplicationDbContext _context;

        public EventoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evento>> GetAllEventosAsync()
        {
            return await _context.Eventos.ToListAsync();
        }

        public async Task<Evento?> GetEventoByIdAsync(int id)
        {
            return await _context.Eventos.FindAsync(id);
        }

        public async Task<Evento> CreateEventoAsync(Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();
            return evento;
        }

        public async Task<bool> UpdateEventoAsync(int id, Evento evento)
        {
            var existing = await _context.Eventos.FindAsync(id);
            if (existing == null) return false;

            existing.nombre = evento.nombre;
            existing.descripcion = evento.descripcion;
            existing.fecha_inicio = evento.fecha_inicio;
            existing.fecha_fin = evento.fecha_fin;
            existing.tipo_evento = evento.tipo_evento;
            existing.lugar = evento.lugar;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEventoAsync(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null) return false;

            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
