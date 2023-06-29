using HealthSystem.Dominio.Entidades;
using HealthSystem.Dominio.InterfaceRepositorios;
using HealthSystem.Servicos.Interfaces;

namespace HealthSystem.Servicos
{
    public class PacienteServico : IPacienteServico
    {
        private readonly IPacienteRepositorio _pacienteRepositorio;

        public PacienteServico(IPacienteRepositorio pacienteRepositorio)
        {
            _pacienteRepositorio = pacienteRepositorio;
        }

        public async Task<IEnumerable<Paciente>> ObterTodosPacientes()
        {
            return await _pacienteRepositorio.ObterTodos();
        }

        public async Task<Paciente> ObterPacientePorId(int id)
        {
            return await _pacienteRepositorio.ObterPorId(id);
        }

        public async Task<int> CadastrarPaciente(Paciente paciente)
        {
            return await _pacienteRepositorio.Inserir(paciente);
        }

        public async Task AtualizarPaciente(Paciente paciente)
        {
            await _pacienteRepositorio.Atualizar(paciente);
        }

        public async Task RemoverPaciente(int id)
        {
            await _pacienteRepositorio.Remover(id);
        }
    }
}
