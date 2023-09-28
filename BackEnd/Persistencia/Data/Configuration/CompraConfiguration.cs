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

        builder.HasData(
            new {  
                Id = 1,  
                NumeroFactura = "1112245",  
                FechaCompra = new DateTime (2023,02,04),
                ProveedorId = 1,
                MetodoDePagoId = 2  
            },  
            new {  
                Id = 2,  
                NumeroFactura = "324324234",  
                FechaCompra = new DateTime (2023,05,24),
                ProveedorId = 2,
                MetodoDePagoId = 3 
            },  
            new {  
                Id = 3,  
                NumeroFactura = "3245435325",  
                FechaCompra = new DateTime (2023,12,01),
                ProveedorId = 4,
                MetodoDePagoId = 4 
            },  
            new {
                Id = 4,  
                NumeroFactura = "3453245435",  
                FechaCompra = new DateTime (2023,01,30),
                ProveedorId = 3,
                MetodoDePagoId = 1 
            },  
            new {  
                Id = 5,  
                NumeroFactura = "4343255",  
                FechaCompra = new DateTime (2023,06,11),
                ProveedorId = 2,
                MetodoDePagoId = 2 
            },  
            new {  
                Id = 6,  
                NumeroFactura = "345325345",  
                FechaCompra = new DateTime (2023,10,19),
                ProveedorId = 1,
                MetodoDePagoId = 3 
            },  
            new {  
                Id = 7,  
                NumeroFactura = "34523452345",  
                FechaCompra = new DateTime (2023,08,06),
                ProveedorId = 2,
                MetodoDePagoId = 4 
            }  
        );

    }
}
