using Microsoft.EntityFrameworkCore;
using HealthSystem.Dominio.Entidades;
using HealthSystem.Infra.Mapeamentos;

namespace HealthSystem.Infra.Data
{
    public class HealthSystemDbContext : DbContext
    {
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }

        public HealthSystemDbContext(DbContextOptions<HealthSystemDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConsultaMap());
            modelBuilder.ApplyConfiguration(new MedicoMap());
            modelBuilder.ApplyConfiguration(new PacienteMap());
        }
    }
}
