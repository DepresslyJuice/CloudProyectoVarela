using Microsoft.AspNetCore.Mvc;
using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Interfaces;

namespace VarelaProyectoCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PonenteSesionController : ControllerBase
    {
        private readonly IPonenteSesionService _ponenteSesionService;
        public PonenteSesionController(IPonenteSesionService ponenteSesionService)
        {
            _ponenteSesionService = ponenteSesionService;
        }
        [HttpGet]
        public async Task<IActionResult> GetPonenteSesiones()
        {
            var ponenteSesiones = await _ponenteSesionService.GetAllPonenteSesionesAsync();
            return Ok(ponenteSesiones);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPonenteSesion(int id)
        {
            var ponenteSesion = await _ponenteSesionService.GetPonenteSesionByIdAsync(id);
            if (ponenteSesion == null) return NotFound();
            return Ok(ponenteSesion);
        }
        [HttpPost]
        public async Task<IActionResult> PostPonenteSesion(PonenteSesion ponenteSesion)
        {
            var nuevo = await _ponenteSesionService.CreatePonenteSesionAsync(ponenteSesion);
            return CreatedAtAction(nameof(GetPonenteSesion), new { id = nuevo.ponente_id }, nuevo);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePonenteSesion(int id)
        {
            var success = await _ponenteSesionService.DeletePonenteSesionAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
