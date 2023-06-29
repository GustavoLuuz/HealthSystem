using HealthSystem.Dominio.Entidades;

namespace HealthSystem.Infra.Repositorios.Interfaces
{
    public interface IPacienteRepositorio
    {
        Task<IEnumerable<Paciente>> ObterTodos();
        Task<Paciente> ObterPorId(int id);
        Task<IEnumerable<Paciente>> ObterPorCPF(string cpf);
        Task<int> Inserir(Paciente paciente);
        Task Atualizar(Paciente paciente);
        Task Remover(int id);
    }
}
