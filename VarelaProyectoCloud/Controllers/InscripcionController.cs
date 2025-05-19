using Microsoft.AspNetCore.Mvc;
using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Interfaces;

namespace VarelaProyectoCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscripcionController : ControllerBase
    {
        public readonly IInscripcionService _inscripcionService;

        public InscripcionController(IInscripcionService inscripcionService)
        {
            _inscripcionService = inscripcionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInscripciones()
        {
            var inscripciones = await _inscripcionService.GetAllInscripcionesAsync();
            return Ok(inscripciones);
        }
        // GET api/<InscripcionController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInscripcion(int id)
        {
            var inscripcion = await _inscripcionService.GetInscripcionByIdAsync(id);
            if (inscripcion == null) return NotFound();
            return Ok(inscripcion);
        }
        // POST api/<InscripcionController>
        [HttpPost]
        public async Task<IActionResult> PostInscripcion(Inscripcion inscripcion)
        {
            var nuevo = await _inscripcionService.CreateInscripcionAsync(inscripcion);
            return CreatedAtAction(nameof(GetInscripcion), new { id = nuevo.inscripcion_id }, nuevo);
        }
        // PUT api/<InscripcionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInscripcion(int id, [FromBody] Inscripcion inscripcion)
        {
            if (id != inscripcion.inscripcion_id)
                return BadRequest("ID en la URL no coincide con el del cuerpo.");

            var updated = await _inscripcionService.UpdateInscripcionAsync(id, inscripcion);
            if (updated == null)
                return NotFound();

            return Ok(updated); // Devuelve la inscripción actualizada
        }
        // DELETE api/<InscripcionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscripcion(int id)
        {
            var success = await _inscripcionService.DeleteInscripcionAsync(id);
            return success ? NoContent() : NotFound();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> CancelarInscripcion(int id)
        {
            var success = await _inscripcionService.CancelarInscripcionAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
