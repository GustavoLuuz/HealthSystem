using HealthSystem.Aplicacao.Servicos.Interfaces;
using HealthSystem.Dominio.Entidades;
using HealthSystem.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteServico _pacienteServico;

        public PacienteController(IPacienteServico pacienteServico)
        {
            _pacienteServico = pacienteServico;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> ObterTodosPacientes()
        {
            var pacientes = await _pacienteServico.ObterTodosPacientes();
            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> ObterPacientePorId(int id)
        {
            var paciente = await _pacienteServico.ObterPacientePorId(id);
            if (paciente == null)
                return NotFound();

            return Ok(paciente);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CadastrarPaciente([FromBody] Paciente paciente)
        {
            try
            {
                var pacienteId = await _pacienteServico.CadastrarPaciente(paciente);
                return CreatedAtAction(nameof(ObterPacientePorId), new { id = pacienteId }, pacienteId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarPaciente(int id, [FromBody] Paciente paciente)
        {
            if (id != paciente.Id)
                return BadRequest();

            try
            {
                await _pacienteServico.AtualizarPaciente(paciente);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoverPaciente(int id)
        {
            try
            {
                await _pacienteServico.RemoverPaciente(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
