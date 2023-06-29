using HealthSystem.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthSystem.Infra.Mapeamentos
{
    public class PacienteMap : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Paciente");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.Property(p => p.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.CPF)
                   .IsRequired()
                   .HasMaxLength(11);

            builder.Property(p => p.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.DataNascimento)
                   .IsRequired()
                   .HasColumnType("datetime")
                   .HasDefaultValue(DateTime.Now.ToUniversalTime());

            builder.Property(p => p.PlanoSaude)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(p => p.CPF)
                   .IsUnique();
        }
    }
}