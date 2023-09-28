using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
{
    public void Configure(EntityTypeBuilder<Proveedor> builder)
    {
        builder.ToTable("Proveedor");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdProveedor")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Nombres)
            .HasColumnName("Nombres")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Apellidos)
            .HasColumnName("Apellidos")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.NroContacto)
            .HasColumnName("NroContacto")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.HasData(
            new {  
                Id = 1,  
                Nombres = "Nombres Proveedor A",  
                Apellidos = "Apellido Proveedor A",  
                NroContacto = "3208818203"  
            },
            new {  
                Id = 2,  
                Nombres = "Nombres Proveedor B",  
                Apellidos = "Apellido Proveedor B",  
                NroContacto = "3208818203" 
            },
            new {  
                Id = 3,  
                Nombres = "Nombres Proveedor C",  
                Apellidos = "Apellido Proveedor C",  
                NroContacto = "3208818203" 
            },
            new {  
                Id = 4,  
                Nombres = "Nombres Proveedor D",  
                Apellidos = "Apellido Proveedor D",  
                NroContacto = "3208818203" 
            },
            new {  
                Id = 5,  
                Nombres = "ProveedorA",  
                Apellidos = "ApellidoA",  
                NroContacto = "3208818203" 
            }
        );
    }
}
