using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HealthSystem.Infra.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<HealthSystemDbContext>
    {
        public HealthSystemDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HealthSystemDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=HealthSystemDB;User ID=sa;Password=1q2w3eaa4r@#$",
            sqlServerOptions => sqlServerOptions.MigrationsAssembly("HealthSystem.Infra"));

            return new HealthSystemDbContext(optionsBuilder.Options);
        }
    }
}
