using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class MedicamentosCompradosConfiguration : IEntityTypeConfiguration<MedicamentosComprados>
{
    public void Configure(EntityTypeBuilder<MedicamentosComprados> builder)
    {
        builder.ToTable("MedicamentosComprados");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdMedicamentosComprados")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.CompraId)
            .HasColumnName("Compra_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Compras)
            .WithMany(p => p.MedicamentosComprados)
            .HasForeignKey(p => p.CompraId);

        builder.Property(p => p.MedicamentoId)
            .HasColumnName("Medico_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Medicamentos)
            .WithMany(p => p.MedicamentosComprados)
            .HasForeignKey(p => p.MedicamentoId);

        builder.Property(p => p.CantidadCompra)
            .HasColumnName("CantidadCompra")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.ValorTotalCompra)
            .HasColumnName("ValorTotalCompra")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

    }
}
