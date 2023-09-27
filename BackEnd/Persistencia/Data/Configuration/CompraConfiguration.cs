using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class CompraConfiguration : IEntityTypeConfiguration<Compra>
{
    public void Configure(EntityTypeBuilder<Compra> builder)
    {
        builder.ToTable("Compra");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdCompra")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.FechaCompra)
            .HasColumnName("FechaCompra")
            .HasColumnType("DateTime")
            .IsRequired();

        builder.Property(p => p.ProveedorId)
            .HasColumnName("Proveedor_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Proveedores)
            .WithMany(p => p.Compras)
            .HasForeignKey(p => p.ProveedorId);

        builder.Property(p => p.MetodoDePagoId)
            .HasColumnName("MetodoDePago_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.MetodosDePagos)
            .WithMany(p => p.Compras)
            .HasForeignKey(p => p.MetodoDePagoId);

        builder.Property(p => p.NumeroFactura)
            .HasColumnName("NumeroFactura")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

    }
}
