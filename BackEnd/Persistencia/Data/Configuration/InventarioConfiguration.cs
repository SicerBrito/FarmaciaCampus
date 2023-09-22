using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
{
    public void Configure(EntityTypeBuilder<Inventario> builder)
    {
        builder.ToTable("Inventario");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdInventario")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.FarmaciaId)
            .HasColumnName("Farmacia_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Farmacias)
            .WithMany(p => p.Inventarios)
            .HasForeignKey(p => p.FarmaciaId);

        builder.Property(p => p.CompraId)
            .HasColumnName("Compra_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Compras)
            .WithMany(p => p.Inventarios)
            .HasForeignKey(p => p.CompraId);

        builder.Property(p => p.VentaId)
            .HasColumnName("Usuario_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Ventas)
            .WithMany(p => p.Inventarios)
            .HasForeignKey(p => p.VentaId);
            
    }
}
