using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Interfaces;
using VarelaProyectoCloud.Data;
using Microsoft.EntityFrameworkCore;

namespace VarelaProyectoCloud.Services
{
    public class PagoService : IPagoService
    {
        private readonly ApplicationDbContext _context;
        
        public PagoService(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Pago>> GetAllPagosAsync()
        {
            return await _context.Pagos
                .Include(i=>i.pago_id)
                .ToListAsync();
        }

        public async Task<Pago> GetPagoByAsync(int id)
        {
            return await _context.Pagos
                .Include(i => i.pago_id)
                .FirstOrDefaultAsync(i => i.inscripcion_id == id);
        }

        public async Task<Pago> CreatePagoAsync(Pago pago)
        {
            _context.Pagos.AddAsync(pago);
            await _context.SaveChangesAsync();
            return pago;
        }

        public async Task<Pago> UpdatePagoAsync(int id, Pago pago)
        {
            var existing = await _context.Pagos.FindAsync(id);
            if (existing == null)
                return null;
            // Actualiza campos necesarios
            existing.monto = pago.monto;
            existing.fecha_pago = pago.fecha_pago;
            existing.metodo_pago = pago.metodo_pago;
            existing.inscripcion_id = pago.inscripcion_id;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeletePagoAsync(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null) return false;
            _context.Pagos.Remove(pago);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
