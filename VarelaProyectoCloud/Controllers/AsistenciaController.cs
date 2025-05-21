using Microsoft.AspNetCore.Mvc;
using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Interfaces;
using VarelaProyectoCloud.Services;

namespace VarelaProyectoCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsistenciaController : ControllerBase
    {
        public readonly IAsistenciaService _asistenciaService;

        public AsistenciaController(IAsistenciaService asistenciaService)
        {
            _asistenciaService = asistenciaService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsistencias()
        {
            var asistencias = await _asistenciaService.GetAllAsistenciasAsync();
            return Ok(asistencias);
        }
        // GET api/<AsistenciaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsistencia(int id)
        {
            var asistencia = await _asistenciaService.GetAsistenciaByIdAsync(id);
            if (asistencia == null) return NotFound();
            return Ok(asistencia);
        }
        // POST api/<AsistenciaController>
        [HttpPost]
        public async Task<IActionResult> PostAsistencia(Asistencia asistencia)
        {
            var nuevo = await _asistenciaService.CreateAsistenciaAsync(asistencia);
            return CreatedAtAction(nameof(GetAsistencia), new { id = nuevo.asistencia_id }, nuevo);
        }
        // PUT api/<AsistenciaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsistencia(int id, Asistencia asistencia)
        {
            var updated = await _asistenciaService.UpdateAsistenciaAsync(id, asistencia);
            if (updated == null)
                return NotFound();
            return Ok(updated); // Devuelve la asistencia actualizada
        }
        // DELETE api/<AsistenciaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsistencia(int id)
        {
            var success = await _asistenciaService.DeleteAsistenciaAsync(id);
            return success ? NoContent() : NotFound();
        }
        [HttpGet("inscripcion/{inscripcionId}")]
        public async Task<IActionResult> GetAsistenciasByInscripcionId(int inscripcionId)
        {
            var asistencias = await _asistenciaService.GetAsistenciasByInscripcionIdAsync(inscripcionId);
            return Ok(asistencias);
        }
        [HttpGet("sesion/{sesionId}")]
        public async Task<IActionResult> GetAsistenciasBySesionId(int sesionId)
        {
            var asistencias = await _asistenciaService.GetAsistenciasBySesionIdAsync(sesionId);
            return Ok(asistencias);
        }
    }
}
