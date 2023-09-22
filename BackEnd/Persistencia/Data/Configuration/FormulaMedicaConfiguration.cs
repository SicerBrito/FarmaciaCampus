using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class FormulaMedicaConfiguration : IEntityTypeConfiguration<FormulaMedica>
{
    public void Configure(EntityTypeBuilder<FormulaMedica> builder)
    {
        builder.ToTable("FormulaMedica");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdFormulaMedica")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.PacienteId)
            .HasColumnName("Paciente_Id")
            .HasColumnType("int")
            .IsRequired();
            
        builder.HasOne(p => p.Pacientes)
            .WithMany(p => p.FormulasMedicas)
            .HasForeignKey(p => p.PacienteId);

        builder.Property(p => p.FechaPrescripcion)
            .HasColumnName("FechaPrescripcion")
            .HasColumnType("DateTime")
            .IsRequired();

        builder.Property(p => p.MedicoId)
            .HasColumnName("Medico_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Empleados)
            .WithMany(p => p.FormulasMedicas)
            .HasForeignKey(p => p.MedicoId);

        builder.Property(p => p.Posologia)  // Las instrucciones de dosificación para cada medicamento, incluyendo la cantidad y la frecuencia.
            .HasColumnName("Posologia")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.DuracionTratamiento)
            .HasColumnName("DuracionTratamiento")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Indicaciones)
            .HasColumnName("Indicaciones")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();


    }
}
