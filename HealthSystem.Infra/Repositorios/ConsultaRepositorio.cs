using HealthSystem.Dominio.Entidades;
using HealthSystem.Dominio.InterfaceRepositorios;
using HealthSystem.Infra.Data;

using Microsoft.EntityFrameworkCore;

namespace HealthSystem.Infra.Repositorios
{
    public class ConsultaRepositorio : IConsultaRepositorio
    {
        private readonly HealthSystemDbContext _dbContext;

        public ConsultaRepositorio(HealthSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Consulta>> ObterTodos()
        {
            return await _dbContext.Consultas
                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .ToListAsync();
        }

        public async Task<Consulta> ObterPorId(int id)
        {
            return await _dbContext.Consultas
                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<int> Inserir(Consulta consulta)
        {
            _dbContext.Consultas.Add(consulta);
            await _dbContext.SaveChangesAsync();
            return consulta.Id;
        }

        public async Task Atualizar(Consulta consulta)
        {
            _dbContext.Entry(consulta).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remover(int id)
        {
            var consulta = await _dbContext.Consultas.FindAsync(id);
            if (consulta != null)
            {
                _dbContext.Consultas.Remove(consulta);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
