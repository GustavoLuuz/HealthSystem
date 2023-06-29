using HealthSystem.Dominio.Entidades;

namespace HealthSystem.Infra.Repositorios.Interfaces
{
    public interface IConsultaRepositorio
    {
        Task<IEnumerable<Consulta>> ObterTodos();
        Task<Consulta> ObterPorId(int id);
        Task<int> Inserir(Consulta consulta);
        Task Atualizar(Consulta consulta);
        Task Remover(int id);
    }
}
