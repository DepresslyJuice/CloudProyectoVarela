using VarelaProyectoCloud.Models;
namespace VarelaProyectoCloud.Interfaces
{
    public interface IEspacioService
    {
        Task<IEnumerable<Espacio>> GetAllEspaciosAsync();
        Task<Espacio?> GetEspacioByIdAsync(int id);
        Task<Espacio> CreateEspacioAsync(Espacio espacio);
        Task<bool> UpdateEspacioAsync(int id, Espacio espacio);
        Task<bool> DeleteEspacioAsync(int id);
    }
}
