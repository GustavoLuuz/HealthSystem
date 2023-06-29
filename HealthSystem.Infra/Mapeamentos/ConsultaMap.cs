using HealthSystem.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthSystem.Infra.Mapeamentos
{
    public class ConsultaMap : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
             builder.ToTable("Consulta");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.Property(c => c.DataHora)
                .IsRequired()
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now.ToUniversalTime());

            builder.Property(c => c.Observacoes)
                .HasMaxLength(200);

            builder.Property(c => c.Situacao)
                .IsRequired();

            builder.HasOne(c => c.Medico)
                .WithMany()
                .HasConstraintName("FK_Consulta_Medico")
                .IsRequired();

            builder.HasOne(c => c.Paciente)
                .WithMany()
                .HasConstraintName("FK_Consulta_Paciente")
                .IsRequired();        
        }
    }
}