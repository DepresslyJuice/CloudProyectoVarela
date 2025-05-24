using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Interfaces;
using VarelaProyectoCloud.Data;
using Microsoft.EntityFrameworkCore;

namespace VarelaProyectoCloud.Services
{
    public class CertificadoService : ICertificadosService
    {
        private readonly ApplicationDbContext _context;

        public CertificadoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Certificado>> GetAllCertificadosAsync()
        {
            return await _context.Certificados
                .Include(c => c.inscripcion)
                .ToListAsync();
        }

        public async Task<Certificado?> GetCertificadoByIdAsync(int id)
        {
            return await _context.Certificados
                .Include(c => c.inscripcion)
                .FirstOrDefaultAsync(c => c.certificado_id == id);
        }

        public async Task<Certificado> CreateCertificadoAsync(Certificado certificado)
        {
            _context.Certificados.Add(certificado);
            await _context.SaveChangesAsync();
            return certificado;
        }
        public async Task<Certificado> UpdateCertificadoAsync(int id, Certificado certificado)
        {
            var existing = await _context.Certificados.FindAsync(id);
            if (existing == null)
                return null;
            // Actualiza campos necesarios
            existing.inscripcion_id = certificado.inscripcion_id;
            existing.codigo_verificacion = certificado.codigo_verificacion;
            existing.fecha_emision = certificado.fecha_emision;
            existing.url_certificado = certificado.url_certificado;
            await _context.SaveChangesAsync();
            return existing;
        }
        public async Task<bool> DeleteCertificadoAsync(int id)
        {
            var certificado = await _context.Certificados.FindAsync(id);
            if (certificado == null) return false;
            _context.Certificados.Remove(certificado);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<string> GenerarCodigoVerificacionAsync()
        {
            // Genera un código de verificación único
            var codigo = Guid.NewGuid().ToString();
            return await Task.FromResult(codigo);
        }
        public async Task<string> ObtenerUrlCertificadoAsync(int inscripcionId)
        {
            // Genera una URL para el certificado
            var url = $"https://example.com/certificados/{inscripcionId}";
            return await Task.FromResult(url);
        }
        public async Task<bool> ValidarCodigoVerificacionAsync(string codigoVerificacion)
        {
            // Valida el código de verificación
            var certificado = await _context.Certificados
                .FirstOrDefaultAsync(c => c.codigo_verificacion == codigoVerificacion);
            return certificado != null;
        }
    }
}