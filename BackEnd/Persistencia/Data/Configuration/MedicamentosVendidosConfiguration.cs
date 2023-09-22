using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class MedicamentosVendidosConfiguration : IEntityTypeConfiguration<MedicamentosVendidos>
{
    public void Configure(EntityTypeBuilder<MedicamentosVendidos> builder)
    {
        builder.ToTable("MedicamentosVendidos");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdMedicamentosVendidos")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.VentaId)
            .HasColumnName("Venta_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Ventas)
            .WithMany(p => p.MedicamentosVendidos)
            .HasForeignKey(p => p.VentaId);

        builder.Property(p => p.MedicamentoId)
            .HasColumnName("Medicamento_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Medicamentos)
            .WithMany(p => p.MedicamentosVendidos)
            .HasForeignKey(p => p.MedicamentoId);

        builder.Property(p => p.CantidadVendida)
            .HasColumnName("CantidadVendida")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.ValorTotalVenta)
            .HasColumnName("ValorTotalVenta")
            .HasColumnType("BIGINT")
            .IsRequired();
    }
}
