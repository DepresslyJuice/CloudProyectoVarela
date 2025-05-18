using VarelaProyectoCloud.Models;
namespace VarelaProyectoCloud.Interfaces
{
    public interface IPonenteService
    {
        Task<IEnumerable<Ponente>> GetAllPonentesAsync();
        Task<Ponente?> GetPonenteByIdAsync(int id);
        Task<Ponente> CreatePonenteAsync(Ponente ponente);
        Task<bool> UpdatePonenteAsync(int id, Ponente ponente);
        Task<bool> DeletePonenteAsync(int id);
    }
}
