using HealthSystem.Aplicacao.Comandos;
using HealthSystem.Aplicacao.Servicos.Interfaces;
using HealthSystem.Dominio.Entidades;
using HealthSystem.Dominio.InterfaceRepositorios;

namespace HealthSystem.Servicos
{
    public class MedicoServico : IMedicoServico
    {
        private readonly IMedicoRepositorio _medicoRepositorio;

        public MedicoServico(IMedicoRepositorio medicoRepositorio)
        {
            _medicoRepositorio = medicoRepositorio;
        }

        public async Task<IEnumerable<Medico>> ObterTodosMedicos()
        {
            return await _medicoRepositorio.ObterTodos();
        }

        public async Task<Medico> ObterMedicoPorId(int id)
        {
            return await _medicoRepositorio.ObterPorId(id);
        }

        public async Task<int> CadastrarMedico(CriarMedicoComando medicoComando)
        {
            if (medicoComando == null)
                throw new ArgumentNullException(nameof(medicoComando));

            var medico = new Medico(
                medicoComando.Nome,
                medicoComando.Cpf,
                medicoComando.DataNascimento,
                medicoComando.Email,
                medicoComando.Especialidade,
                medicoComando.CRM);

            return await _medicoRepositorio.Inserir(medico);
        }

        public async Task AtualizarMedico(AtualizarMedicoComando medicoComando)
        {
            if (medicoComando == null)
                throw new ArgumentNullException(nameof(medicoComando));

            var medicoExistente = await _medicoRepositorio.ObterPorId(medicoComando.Id);

            if (medicoExistente == null)
                throw new Exception("Médico não encontrado.");

            medicoExistente.AtualizarMedico(
                medicoComando.Nome,
                medicoComando.Cpf,
                medicoComando.DataNascimento,
                medicoComando.Email,
                medicoComando.Especialidade,
                medicoComando.CRM
             );
            await _medicoRepositorio.Atualizar(medicoExistente);
        }


        public async Task RemoverMedico(int id)
        {
            await _medicoRepositorio.Remover(id);
        }
    }
}
