using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Services;

namespace VarelaProyectoCloud.Interfaces
{
    public interface ICertificadosService
    {
        Task<IEnumerable<Certificado>> GetAllCertificadosAsync();
        Task<Certificado?> GetCertificadoByIdAsync(int id);
        Task<Certificado> CreateCertificadoAsync(Certificado certificado);
        Task<Certificado> UpdateCertificadoAsync(int id, Certificado certificado);
        Task<bool> DeleteCertificadoAsync(int id);
        Task<string> GenerarCodigoVerificacionAsync();
        Task<string> ObtenerUrlCertificadoAsync(int inscripcionId);
        Task<bool> ValidarCodigoVerificacionAsync(string codigoVerificacion);
       
    }
}
