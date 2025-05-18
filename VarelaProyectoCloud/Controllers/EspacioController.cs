using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Interfaces;

namespace VarelaProyectoCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspacioController : ControllerBase
    {
        public readonly IEspacioService _espacioService;

        public EspacioController(IEspacioService espacioService)
        {
            _espacioService = espacioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEspacios()
        {
            var espacios = await _espacioService.GetAllEspaciosAsync();
            return Ok(espacios);
        }
        // GET api/<EspacioController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEspacio(int id)
        {
            var espacio = await _espacioService.GetEspacioByIdAsync(id);
            if (espacio == null) return NotFound();
            return Ok(espacio);
        }
        // POST api/<EspacioController>
        [HttpPost]
        public async Task<IActionResult> PostEspacio(Espacio espacio)
        {
            var nuevo = await _espacioService.CreateEspacioAsync(espacio);
            return CreatedAtAction(nameof(GetEspacio), new { id = nuevo.espacio_id }, nuevo);
        }
        // PUT api/<EspacioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspacio(int id, Espacio espacio)
        {
            var success = await _espacioService.UpdateEspacioAsync(id, espacio);
            return success ? NoContent() : NotFound();
        }
        // DELETE api/<EspacioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspacio(int id)
        {
            var success = await _espacioService.DeleteEspacioAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
