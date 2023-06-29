using HealthSystem.Aplicacao.Servicos.Interfaces;
using HealthSystem.Dominio.Entidades;
using HealthSystem.Infra.Repositorios.Interfaces;

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

        public async Task<int> CadastrarMedico(Medico medico)
        {
            if (medico == null)
                throw new ArgumentNullException(nameof(medico));

            return await _medicoRepositorio.Inserir(medico);
        }

        public async Task AtualizarMedico(Medico medico)
        {
            if (medico == null)
                throw new ArgumentNullException(nameof(medico));

            await _medicoRepositorio.Atualizar(medico);
        }

        public async Task RemoverMedico(int id)
        {
            await _medicoRepositorio.Remover(id);
        }
    }
}
