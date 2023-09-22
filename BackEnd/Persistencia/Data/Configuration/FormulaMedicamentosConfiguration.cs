using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class FormulaMedicamentosConfiguration : IEntityTypeConfiguration<FormulaMedicamentos>
{
    public void Configure(EntityTypeBuilder<FormulaMedicamentos> builder)
    {
        builder.ToTable("FormulaMedicamentos");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdFormulaMedicamentos")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.FomulaMedicaId)
            .HasColumnName("FomulaMedica_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.FormulasMedicas)
            .WithMany(p => p.FormulaMedicamentos)
            .HasForeignKey(p => p.FomulaMedicaId);

        builder.Property(p => p.MedicamentoId)
            .HasColumnName("Medicamento_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Medicamentos)
            .WithMany(p => p.FormulaMedicamentos)
            .HasForeignKey(p => p.MedicamentoId);

    }
}
