
using HealthSystem.Aplicacao.Comandos;
using HealthSystem.Dominio.Entidades;

namespace HealthSystem.Aplicacao.Servicos.Interfaces
{
    public interface IMedicoServico
    {
        Task<IEnumerable<Medico>> ObterTodosMedicos();
        Task<Medico> ObterMedicoPorId(int id);
        Task<int> CadastrarMedico(CriarMedicoComando medico);
        Task AtualizarMedico(AtualizarMedicoComando medico);
        Task RemoverMedico(int id);
    }
}