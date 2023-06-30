using HealthSystem.Aplicacao.Comandos;
using HealthSystem.Aplicacao.Comandos.ConsultaComandos;
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
        public async Task<ActionResult<int>> AgendarConsulta([FromBody] CriarConsultaComando consultaComando)
        {
            try
            {
                var consultaId = await _consultaServico.AgendarConsulta(consultaComando);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarConsulta(int id, [FromBody] AtualizarConsultaComando consultaComando)
        {
            if (id != consultaComando.Id)
                return BadRequest();

            try
            {
                await _consultaServico.AtualizarConsulta(consultaComando);
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
