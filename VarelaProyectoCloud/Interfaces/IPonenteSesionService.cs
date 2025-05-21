using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Services;

namespace VarelaProyectoCloud.Interfaces
{
    public interface IPonenteSesionService
    {
        Task<IEnumerable<PonenteSesion>> GetAllPonenteSesionesAsync();
        Task<PonenteSesion?> GetPonenteSesionByIdAsync(int id);
        Task<PonenteSesion> CreatePonenteSesionAsync(PonenteSesion ponenteSesion);
        Task<PonenteSesion> UpdatePonenteSesionAsync(int id, PonenteSesion ponenteSesion);
        Task<bool> DeletePonenteSesionAsync(int id);
        Task<IEnumerable<PonenteSesion>> GetPonentesBySesionIdAsync(int sesionId);
        Task<IEnumerable<PonenteSesion>> GetSesionesByPonenteIdAsync(int ponenteId);
    }
}
