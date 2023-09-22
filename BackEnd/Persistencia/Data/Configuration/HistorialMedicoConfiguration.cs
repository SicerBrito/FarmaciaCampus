using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class HistorialMedicoConfiguration : IEntityTypeConfiguration<HistorialMedico>
{
    public void Configure(EntityTypeBuilder<HistorialMedico> builder)
    {
        builder.ToTable("HistorialMedico");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdHistorialMedico")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.PacienteId)
            .HasColumnName("Paciente_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Pacientes)
            .WithMany(p => p.HistorialesMedicos)
            .HasForeignKey(p => p.PacienteId);

        builder.Property(p => p.MedicoId)
            .HasColumnName("Medico_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Empleados)
            .WithMany(p => p.HistorialesMedicos)
            .HasForeignKey(p => p.MedicoId);

        builder.Property(p => p.Diagnostico)
            .HasColumnName("Diagnostico")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.Tratamiento)
            .HasColumnName("Tratamiento")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.Observaciones)
            .HasColumnName("Observaciones")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();

    }
}
