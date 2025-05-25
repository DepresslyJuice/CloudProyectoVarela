using Microsoft.AspNetCore.Mvc;
using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Interfaces;
using VarelaProyectoCloud.Services;

namespace VarelaProyectoCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : ControllerBase
    {
        public readonly ISesionService _sesionService;

        public SesionController(ISesionService sesionService)
        {
            _sesionService = sesionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSesiones()
        {
            var sesiones = await _sesionService.GetAllSesionesAsync();
            return Ok(sesiones);
        }
        // GET api/<SesionController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSesion(int id)
        {
            var sesion = await _sesionService.GetSesionByIdAsync(id);
            if (sesion == null) return NotFound();
            return Ok(sesion);
        }
        // POST api/<SesionController>
        [HttpPost]
        public async Task<IActionResult> PostSesion(Sesion sesion)
        {
            var nuevo = await _sesionService.CreateSesionAsync(sesion);
            return CreatedAtAction(nameof(GetSesion), new { id = nuevo.sesion_id }, nuevo);
        }
        // PUT api/<SesionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSesion(int id, Sesion sesion)
        {
            var updated = await _sesionService.UpdateSesionAsync(id, sesion);
            if (updated == null)
                return NotFound();
            return Ok(updated); // Devuelve la sesión actualizada
        }
        // DELETE api/<SesionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSesion(int id)
        {
            var success = await _sesionService.DeleteSesionAsync(id);
            return success ? NoContent() : NotFound();
        }
        [HttpGet("sesionesporevento/{eventoId}")]
        public async Task<IActionResult> GetSesionesByEventoId(int eventoId)
        {
            var sesiones = await _sesionService.GetSesionesByEventoIdAsync(eventoId);
            return Ok(sesiones);
        }
        [HttpGet("sesionesporespacio/{espacioId}")]
        public async Task<IActionResult> GetSesionesByEspacioId(int espacioId)
        {
            var sesiones = await _sesionService.GetSesionesByEspacioIdAsync(espacioId);
            return Ok(sesiones);
        }
    }
}
