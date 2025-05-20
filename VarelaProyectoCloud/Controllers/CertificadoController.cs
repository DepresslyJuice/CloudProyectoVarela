using Microsoft.AspNetCore.Mvc;
using VarelaProyectoCloud.Models;
using VarelaProyectoCloud.Interfaces;
using VarelaProyectoCloud.Services;

namespace VarelaProyectoCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificadoController : ControllerBase
    {
        public readonly ICertificadosService _certificadoService;
        public CertificadoController(ICertificadosService certificadoService)
        {
            _certificadoService = certificadoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCertificados()
        {
            var certificados = await _certificadoService.GetAllCertificadosAsync();
            return Ok(certificados);
        }
        // GET api/<CertificadoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCertificado(int id)
        {
            var certificado = await _certificadoService.GetCertificadoByIdAsync(id);
            if (certificado == null) return NotFound();
            return Ok(certificado);
        }
        // POST api/<CertificadoController>
        [HttpPost]
        public async Task<IActionResult> PostCertificado(Certificado certificado)
        {
            var nuevo = await _certificadoService.CreateCertificadoAsync(certificado);
            return CreatedAtAction(nameof(GetCertificado), new { id = nuevo.certificado_id }, nuevo);
        }
        // PUT api/<CertificadoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertificado(int id, Certificado certificado)
        {
            var updated = await _certificadoService.UpdateCertificadoAsync(id, certificado);
            if (updated == null)
                return NotFound();
            return Ok(updated); // Devuelve el certificado actualizado
        }
        // DELETE api/<CertificadoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificado(int id)
        {
            var success = await _certificadoService.DeleteCertificadoAsync(id);
            return success ? NoContent() : NotFound();
        }
        [HttpPost("generar-codigo")]
        public async Task<IActionResult> GenerarCodigoVerificacion()
        {
            var codigo = await _certificadoService.GenerarCodigoVerificacionAsync();
            return Ok(new { codigo });
        }
        [HttpGet("obtener-url/{inscripcionId}")]
        public async Task<IActionResult> ObtenerUrlCertificado(int inscripcionId)
        {
            var url = await _certificadoService.ObtenerUrlCertificadoAsync(inscripcionId);
            return Ok(new { url });
        }
        [HttpPost("validar-codigo")]
        public async Task<IActionResult> ValidarCodigoVerificacion(string codigoVerificacion)
        {
            var esValido = await _certificadoService.ValidarCodigoVerificacionAsync(codigoVerificacion);
            return Ok(new { esValido });
        }
        [HttpGet("inscripcion/{inscripcionId}")]
        public async Task<IActionResult> ObtenerCertificadoPorInscripcion(int inscripcionId)
        {
            var certificado = await _certificadoService.GetAllCertificadosAsync();
            var certificadoInscripcion = certificado.FirstOrDefault(c => c.inscripcion_id == inscripcionId);
            if (certificadoInscripcion == null) return NotFound();
            return Ok(certificadoInscripcion);
        }
        [HttpGet("inscripcion/{inscripcionId}/validar-codigo")]
        public async Task<IActionResult> ValidarCodigoPorInscripcion(int inscripcionId, string codigoVerificacion)
        {
            var certificado = await _certificadoService.GetAllCertificadosAsync();
            var certificadoInscripcion = certificado.FirstOrDefault(c => c.inscripcion_id == inscripcionId);
            if (certificadoInscripcion == null) return NotFound();
            var esValido = await _certificadoService.ValidarCodigoVerificacionAsync(codigoVerificacion);
            return Ok(new { esValido });
        }
    }
}
