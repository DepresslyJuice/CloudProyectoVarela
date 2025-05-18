using VarelaProyectoCloud.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VarelaProyectoCloud.Interfaces
{
    public interface IEventoService
    {
        Task<IEnumerable<Evento>> GetAllEventosAsync();
        Task<Evento?> GetEventoByIdAsync(int id);
        Task<Evento> CreateEventoAsync(Evento evento);
        Task<bool> UpdateEventoAsync(int id, Evento evento);
        Task<bool> DeleteEventoAsync(int id);
    }
}