using Microsoft.AspNetCore.Mvc;
using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Interfaces;
using VarelaProyectoCloud.Services;


namespace VarelaProyectoCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        public readonly IPagoService _pagoService;
        public PagoController(IPagoService pagoService)
        {
            _pagoService = pagoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetPagos()
        {
            var pagos = await _pagoService.GetAllPagosAsync();
            return Ok(pagos);
        }
        // GET api/<PagoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPago(int id)
        {
            var pago = await _pagoService.GetPagoByAsync(id);
            if (pago == null) return NotFound();
            return Ok(pago);
        }
        // POST api/<PagoController>
        [HttpPost]
        public async Task<IActionResult> PostPago(Pago pago)
        {
            var nuevo = await _pagoService.CreatePagoAsync(pago);
            return CreatedAtAction(nameof(GetPago), new { id = nuevo.pago_id }, nuevo);
        }
        // PUT api/<PagoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPago(int id, Pago pago)
        {
            var updated = await _pagoService.UpdatePagoAsync(id, pago);
            if (updated == null)
                return NotFound();
            return Ok(updated); // Devuelve el pago actualizado
        }
        // DELETE api/<PagoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePago(int id)
        {
            var success = await _pagoService.DeletePagoAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
