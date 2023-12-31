using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class VentaConfiguration : IEntityTypeConfiguration<Venta>
{
    public void Configure(EntityTypeBuilder<Venta> builder)
    {
        builder.ToTable("Venta");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdVenta")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.FechaVenta)
            .HasColumnName("FechaVenta")
            .HasColumnType("DateTime")
            .IsRequired();

        builder.Property(p => p.ClienteId)
            .HasColumnName("Cliente_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Usuarios)
            .WithMany(p => p.Ventas)
            .HasForeignKey(p => p.ClienteId);

        builder.Property(p => p.VentaEmpleadoId)
            .HasColumnName("VentaEmpleado_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Empleados)
            .WithMany(p => p.Ventas)
            .HasForeignKey(p => p.VentaEmpleadoId);

        builder.Property(p => p.MetodoDePagoId)
            .HasColumnName("MetodoDePago_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.MetodosDePagos)
            .WithMany(p => p.Ventas)
            .HasForeignKey(p => p.MetodoDePagoId);

        builder.Property(p => p.NumeroFactura)
            .HasColumnName("NumeroFactura")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.HasData(
            new {  
                Id = 1,  
                NumeroFactura = "5363634231",  
                FechaVenta = new DateTime (2023,05,24),  
                ClienteId = 1,  
                VentaEmpleadoId = 2,  
                MetodoDePagoId = 1  
            },  
            new {  
                Id = 2,  
                NumeroFactura = "473567356465",  
                FechaVenta = new DateTime (2023,02,04),  
                ClienteId = 1,  
                VentaEmpleadoId = 2,  
                MetodoDePagoId = 1  
            }  
        );
    }
}
