using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Services;

namespace VarelaProyectoCloud.Interfaces
{
    public interface ISesionService
    {
        Task<IEnumerable<Sesion>> GetAllSesionesAsync();
        Task<Sesion?> GetSesionByIdAsync(int id);
        Task<Sesion> CreateSesionAsync(Sesion sesion);
        Task<Sesion> UpdateSesionAsync(int id, Sesion sesion);
        Task<bool> DeleteSesionAsync(int id);
        Task<IEnumerable<Sesion>> GetSesionesByEventoIdAsync(int eventoId);
        Task<IEnumerable<Sesion>> GetSesionesByEspacioIdAsync(int espacioId);
    }
}
