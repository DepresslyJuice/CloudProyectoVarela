using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Services;
namespace VarelaProyectoCloud.Interfaces
{
    public interface IAsistenciaService
    {
        Task<IEnumerable<Asistencia>> GetAllAsistenciasAsync();
        Task<Asistencia?> GetAsistenciaByIdAsync(int id);
        Task<Asistencia> CreateAsistenciaAsync(Asistencia asistencia);
        Task<Asistencia> UpdateAsistenciaAsync(int id, Asistencia asistencia);
        Task<bool> DeleteAsistenciaAsync(int id);
        Task<IEnumerable<Asistencia>> GetAsistenciasByInscripcionIdAsync(int inscripcionId);
        Task<IEnumerable<Asistencia>> GetAsistenciasBySesionIdAsync(int sesionId);
    }
}
