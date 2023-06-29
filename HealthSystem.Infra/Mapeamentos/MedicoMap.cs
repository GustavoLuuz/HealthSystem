using HealthSystem.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthSystem.Infra.Mapeamentos
{
    public class MedicoMap : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("Medico");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.Property(m => m.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(m => m.CPF)
                   .IsRequired()
                   .HasMaxLength(11);

            builder.Property(m => m.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(m => m.DataNascimento)
                   .IsRequired()
                   .HasColumnType("datetime")
                   .HasDefaultValue(DateTime.Now.ToUniversalTime());

            builder.Property(m => m.Especialidade)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(m => m.CRM)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.HasIndex(m => m.CRM)
                   .IsUnique();
        }
    }
}