using Microsoft.AspNetCore.Mvc;
using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Interfaces;
namespace VarelaProyectoCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PonenteController : ControllerBase
    {
        public readonly IPonenteService _ponenteService;

        public PonenteController(IPonenteService ponenteService)
        {
            _ponenteService = ponenteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPonentes()
        {
            var ponentes = await _ponenteService.GetAllPonentesAsync();
            return Ok(ponentes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPonente(int id)
        {
            var ponente = await _ponenteService.GetPonenteByIdAsync(id);
            if (ponente == null) return NotFound();
            return Ok(ponente);
        }


        [HttpPost]
        public async Task<IActionResult> PostPonente(Ponente ponente)
        {
            var nuevo = await _ponenteService.CreatePonenteAsync(ponente);
            return CreatedAtAction(nameof(GetPonente), new { id = nuevo.ponente_id }, nuevo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPonente(int id, Ponente ponente)
        {
            var success = await _ponenteService.UpdatePonenteAsync(id, ponente);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePonente(int id)
        {
            var success = await _ponenteService.DeletePonenteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
