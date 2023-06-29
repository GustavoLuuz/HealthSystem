using HealthSystem.Dominio.Entidades;
using HealthSystem.Dominio.InterfaceRepositorios;
using HealthSystem.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace HealthSystem.Infra.Repositorios
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private readonly HealthSystemDbContext _dbContext;

        public PacienteRepositorio(HealthSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Paciente>> ObterTodos()
        {
            return await _dbContext.Pacientes.ToListAsync();
        }

        public async Task<Paciente> ObterPorId(int id)
        {
            return await _dbContext.Pacientes.FindAsync(id);
        }

        public async Task<IEnumerable<Paciente>> ObterPorCPF(string cpf)
        {
            return await _dbContext.Pacientes
                .Where(p => p.CPF == cpf)
                .ToListAsync();
        }

        public async Task<int> Inserir(Paciente paciente)
        {
            _dbContext.Pacientes.Add(paciente);
            await _dbContext.SaveChangesAsync();
            return paciente.Id;
        }

        public async Task Atualizar(Paciente paciente)
        {
            _dbContext.Entry(paciente).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remover(int id)
        {
            var paciente = await _dbContext.Pacientes.FindAsync(id);
            if (paciente != null)
            {
                _dbContext.Pacientes.Remove(paciente);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
