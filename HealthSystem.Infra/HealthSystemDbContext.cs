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


        protected override void OnConfiguring(
            DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost,1433;Database=HealthSystemDB;User ID=sa;Password=1q2w3eaa4r@#$");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConsultaMap());
            modelBuilder.ApplyConfiguration(new MedicoMap());
            modelBuilder.ApplyConfiguration(new PacienteMap());
        }
    }
}
