
using HealthSystem.Dominio.Entidades;
using HealthSystem.Dominio.InterfaceRepositorios;
using HealthSystem.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace HealthSystem.Infra.Repositorios
{
    public class MedicoRepositorio : IMedicoRepositorio
    {
        private readonly HealthSystemDbContext _dbContext;

        public MedicoRepositorio(HealthSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Medico>> ObterTodos()
        {
            return await _dbContext.Medicos.ToListAsync();
        }

        public async Task<Medico> ObterPorId(int id)
        {
            return await _dbContext.Medicos.FindAsync(id);
        }

        public async Task<IEnumerable<Medico>> ObterPorEspecialidade(string especialidade)
        {
            return await _dbContext.Medicos
                .Where(m => m.Especialidade == especialidade)
                .ToListAsync();
        }

        public async Task<int> Inserir(Medico medico)
        {
            _dbContext.Medicos.Add(medico);
            await _dbContext.SaveChangesAsync();
            return medico.Id;
        }

        public async Task Atualizar(Medico medico)
        {
            _dbContext.Entry(medico).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remover(int id)
        {
            var medico = await _dbContext.Medicos.FindAsync(id);
            if (medico != null)
            {
                _dbContext.Medicos.Remove(medico);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
