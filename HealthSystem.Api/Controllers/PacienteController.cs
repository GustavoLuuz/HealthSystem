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
    }
}
