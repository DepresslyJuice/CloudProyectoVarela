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

        public async Task<string> RegistrarPagoAsync(Pago nuevoPago)
        {
            // Obtener inscripción con su tipo de inscripción
            var inscripcion = await _context.Inscripciones
                .Include(i => i.tipo_inscripcion)
                .FirstOrDefaultAsync(i => i.inscripcion_id == nuevoPago.inscripcion_id);

            if (inscripcion == null)
                return "Inscripción no encontrada.";

            if (inscripcion.estado == "Pagado")
                return "La inscripción ya está pagada.";

            // Validar que el monto sea correcto
            var costoEsperado = inscripcion.tipo_inscripcion?.costo ?? 0;

            if (nuevoPago.monto != costoEsperado)
                return $"El monto a pagar debe ser exactamente {costoEsperado}.";

            // Guardar el pago
            nuevoPago.fecha_pago = DateTime.UtcNow;
            _context.Pagos.Add(nuevoPago);

            // Cambiar estado de inscripción
            inscripcion.estado = "Pagado";

            await _context.SaveChangesAsync();
            return "Pago registrado correctamente y estado actualizado a 'Pagado'.";
        }

    }
}
