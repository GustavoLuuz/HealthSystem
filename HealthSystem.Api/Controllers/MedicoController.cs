using HealthSystem.Aplicacao.Comandos;
using HealthSystem.Aplicacao.Servicos.Interfaces;
using HealthSystem.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace HealthSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoServico _medicoServico;

        public MedicoController(IMedicoServico medicoServico)
        {
            _medicoServico = medicoServico;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medico>>> ObterTodosMedicos()
        {
            var medicos = await _medicoServico.ObterTodosMedicos();
            return Ok(medicos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Medico>> ObterMedicoPorId(int id)
        {
            var medico = await _medicoServico.ObterMedicoPorId(id);
            if (medico == null)
                return NotFound();

            return Ok(medico);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CadastrarMedico([FromBody] CriarMedicoComando comando)
        {
            try
            {
                var medicoId = await _medicoServico.CadastrarMedico(comando);
                return CreatedAtAction(nameof(ObterMedicoPorId), new { id = medicoId }, medicoId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarMedico(int id, [FromBody] AtualizarMedicoComando medicoComando)
        {
            if (id != medicoComando.Id)
                return BadRequest();

            try
            {
                await _medicoServico.AtualizarMedico(medicoComando);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoverMedico(int id)
        {
            try
            {
                await _medicoServico.RemoverMedico(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
