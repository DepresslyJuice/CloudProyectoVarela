using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Services;

namespace VarelaProyectoCloud.Interfaces
{
    public interface IPagoService
    {
        Task<IEnumerable<Pago>> GetAllPagosAsync();
        Task<Pago> GetPagoByAsync(int id);
        Task<Pago> CreatePagoAsync(Pago pago);
        Task<Pago> UpdatePagoAsync(int id, Pago pago);
        Task<bool> DeletePagoAsync(int id);

    }
}
