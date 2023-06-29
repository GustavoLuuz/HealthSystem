using HealthSystem.Dominio.Entidades;
using HealthSystem.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaServico _consultaServico;

        public ConsultaController(IConsultaServico consultaServico)
        {
            _consultaServico = consultaServico;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consulta>>> ObterTodasConsultas()
        {
            var consultas = await _consultaServico.ObterTodasConsultas();
            return Ok(consultas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Consulta>> ObterConsultaPorId(int id)
        {
            var consulta = await _consultaServico.ObterConsultaPorId(id);
            if (consulta == null)
                return NotFound();

            return Ok(consulta);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AgendarConsulta([FromBody] Consulta consulta)
        {
            try
            {
                var consultaId = await _consultaServico.AgendarConsulta(consulta);
                return CreatedAtAction(nameof(ObterConsultaPorId), new { id = consultaId }, consultaId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarConsulta(int id, [FromBody] Consulta consulta)
        {
            if (id != consulta.Id)
                return BadRequest();

            try
            {
                await _consultaServico.AtualizarConsulta(consulta);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoverConsulta(int id)
        {
            try
            {
                await _consultaServico.RemoverConsulta(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
