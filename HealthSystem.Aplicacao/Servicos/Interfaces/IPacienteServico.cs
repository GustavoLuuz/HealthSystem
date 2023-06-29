using HealthSystem.Dominio.Entidades;

namespace HealthSystem.Servicos.Interfaces
{
    public interface IPacienteServico
    {
        Task<IEnumerable<Paciente>> ObterTodosPacientes();
        Task<Paciente> ObterPacientePorId(int id);
        Task<int> CadastrarPaciente(Paciente paciente);
        Task AtualizarPaciente(Paciente paciente);
        Task RemoverPaciente(int id);
    }
}
