
using HealthSystem.Dominio.Entidades;

namespace HealthSystem.Aplicacao.Servicos.Interfaces
{
    public interface IMedicoServico
    {
        Task<IEnumerable<Medico>> ObterTodosMedicos();
        Task<Medico> ObterMedicoPorId(int id);
        Task<int> CadastrarMedico(Medico medico);
        Task AtualizarMedico(Medico medico);
        Task RemoverMedico(int id);
    }
}