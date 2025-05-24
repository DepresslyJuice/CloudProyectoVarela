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

        public async Task<string> CrearCertificadoAsync(int inscripcionId)
        {
            var inscripcion = await _context.Inscripciones
                .Include(i => i.evento)
                .FirstOrDefaultAsync(i => i.inscripcion_id == inscripcionId);

            if (inscripcion == null)
                return "Inscripción no encontrada.";

            if (inscripcion.estado != "Pagado")
                return "La inscripción aún no ha sido pagada.";

            // Obtener todas las sesiones del evento
            var sesionesEvento = await _context.Sesiones
                .Where(s => s.evento_id == inscripcion.evento_id)
                .ToListAsync();

            if (sesionesEvento.Count == 0)
                return "El evento no tiene sesiones registradas.";

            // Verificar asistencia completa
            var sesionesAsistidas = await _context.Asistencias
                .Where(a => a.inscripcion_id == inscripcionId && a.asistio)
                .Select(a => a.sesion_id)
                .Distinct()
                .ToListAsync();

            var idsSesionesEvento = sesionesEvento.Select(s => s.sesion_id).OrderBy(x => x).ToList();
            var idsSesionesAsistidas = sesionesAsistidas.OrderBy(x => x).ToList();

            if (!idsSesionesEvento.SequenceEqual(idsSesionesAsistidas))
                return "El participante no ha asistido a todas las sesiones del evento.";

            // Validar si ya existe un certificado
            var certificadoExistente = await _context.Certificados
                .FirstOrDefaultAsync(c => c.inscripcion_id == inscripcionId);

            if (certificadoExistente != null)
                return "El certificado ya ha sido generado.";

            // Generar código único y URL simulada
            var codigoVerificacion = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            var urlCertificado = $"https://tusitio.com/certificados/{codigoVerificacion}";

            var nuevoCertificado = new Certificado
            {
                inscripcion_id = inscripcionId,
                fecha_emision = DateTime.UtcNow,
                codigo_verificacion = codigoVerificacion,
                url_certificado = urlCertificado
            };

            _context.Certificados.Add(nuevoCertificado);
            await _context.SaveChangesAsync();

            return $"Certificado generado exitosamente. Código de verificación: {codigoVerificacion}";
        }



    }
}
