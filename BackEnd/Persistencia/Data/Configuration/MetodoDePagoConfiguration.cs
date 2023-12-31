using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class MetodoDePagoConfiguration : IEntityTypeConfiguration<MetodoDePago>
{
    public void Configure(EntityTypeBuilder<MetodoDePago> builder)
    {
        builder.ToTable("MetodoDePago");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdMetodoDePago")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Nombre)
            .HasColumnName("NombreMetodo")
            .HasColumnType("varchar")
            .HasMaxLength(25)
            .IsRequired();

        builder.HasData(
            new {  
                Id = 1,  
                Nombre = "Tarjeta de credito"  
            },
            new {  
                Id = 2,  
                Nombre = "Tarjeta de debito"  
            },
            new {  
                Id = 3,  
                Nombre = "Efectivo"  
            },
            new {  
                Id = 4,  
                Nombre = "Cheque"  
            },
            new {  
                Id = 5,  
                Nombre = "Transferencia bancaria"  
            }
        );
            
    }
}
