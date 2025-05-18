using Microsoft.AspNetCore.Mvc;
using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Interfaces;

namespace VarelaProyectoCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEventos()
        {
            var eventos = await _eventoService.GetAllEventosAsync();
            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvento(int id)
        {
            var evento = await _eventoService.GetEventoByIdAsync(id);
            if (evento == null) return NotFound();
            return Ok(evento);
        }

        [HttpPost]
        public async Task<IActionResult> PostEvento(Evento evento)
        {
            var nuevo = await _eventoService.CreateEventoAsync(evento);
            return CreatedAtAction(nameof(GetEvento), new { id = nuevo.evento_id }, nuevo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(int id, Evento evento)
        {
            var success = await _eventoService.UpdateEventoAsync(id, evento);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            var success = await _eventoService.DeleteEventoAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}