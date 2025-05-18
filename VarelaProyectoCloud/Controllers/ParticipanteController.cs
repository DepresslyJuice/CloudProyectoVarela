using Microsoft.AspNetCore.Mvc;
using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VarelaProyectoCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipanteController : ControllerBase
    {

        public readonly IParticipanteService _participanteService;

        public ParticipanteController(IParticipanteService participanteService)
        {
            _participanteService = participanteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetParticipantes()
        {
            var participantes = await _participanteService.GetAllParticipantesAsync();
            return Ok(participantes);
        }
        // GET api/<ParticipanteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParticipante(int id)
        {
            var participante = await _participanteService.GetParticipanteByIdAsync(id);
            if (participante == null) return NotFound();
            return Ok(participante);
        }

        // POST api/<ParticipanteController>
        [HttpPost]
        public async Task<IActionResult> PostParticipante(Participante participante)
        {
            var nuevo = await _participanteService.CreateParticipanteAsync(participante);
            return CreatedAtAction(nameof(GetParticipante), new { id = nuevo.participante_id }, nuevo);
        }

        // PUT api/<ParticipanteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipante(int id, Participante participante)
        {
            var success = await _participanteService.UpdateParticipanteAsync(id, participante);
            return success ? NoContent() : NotFound();
        }

        // DELETE api/<ParticipanteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipante(int id)
        {
            var success = await _participanteService.DeleteParticipanteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
