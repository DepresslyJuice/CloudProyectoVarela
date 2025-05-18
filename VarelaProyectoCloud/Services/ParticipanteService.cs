using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Interfaces;
using VarelaProyectoCloud.Data;
using Microsoft.EntityFrameworkCore;


namespace VarelaProyectoCloud.Services
{
    public class ParticipanteService : IParticipanteService
    {
        private readonly ApplicationDbContext _context;

        public ParticipanteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Participante>> GetAllParticipantesAsync()
        {
            return await _context.Participantes.ToListAsync();
        }

        public async Task<Participante?> GetParticipanteByIdAsync(int id)
        {
            return await _context.Participantes.FindAsync(id);
        }

        public async Task<Participante> CreateParticipanteAsync(Participante participante)
        {
            _context.Participantes.Add(participante);
            await _context.SaveChangesAsync();
            return participante;
        }

        public async Task<bool> UpdateParticipanteAsync(int id, Participante participante)
        {
            var existing = await _context.Participantes.FindAsync(id);
            if (existing == null) return false;
            existing.nombre = participante.nombre;
            existing.apellido = participante.apellido;
            existing.email = participante.email;
            existing.telefono = participante.telefono;
            existing.institucion = participante.institucion;
            existing.fecha_nacimiento = participante.fecha_nacimiento;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteParticipanteAsync(int id)
        {
            var participante = await _context.Participantes.FindAsync(id);
            if (participante == null) return false;
            _context.Participantes.Remove(participante);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
