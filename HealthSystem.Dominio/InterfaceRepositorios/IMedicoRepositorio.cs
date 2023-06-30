using HealthSystem.Dominio.Entidades;

namespace HealthSystem.Dominio.InterfaceRepositorios
{
    public interface IMedicoRepositorio
    {
        Task<IEnumerable<Medico>> ObterTodos();
        Task<Medico> ObterPorId(int id);
        Task<IEnumerable<Medico>> ObterPorEspecialidade(string especialidade);
        Task<int> Inserir(Medico medico);
        Task Atualizar(Medico medico);
        Task Remover(int id);
    }
}
