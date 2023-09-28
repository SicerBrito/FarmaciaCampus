using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class PresentacionConfiguration : IEntityTypeConfiguration<Presentacion>
{
    public void Configure(EntityTypeBuilder<Presentacion> builder)
    {
        builder.ToTable("Presentacion");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdPresentacion")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Descripcion)
            .HasColumnName("Descripcion")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();

        builder.HasData(
            new {  
                Id = 1,  
                Descripcion = "Caja de 30 tabletas"  
            },
            new {  
                Id = 2,  
                Descripcion = "Botella de 100 capsulas"  
            },
            new {  
                Id = 3,  
                Descripcion = "Caja de 50 tabletas"  
            },
            new {  
                Id = 4,  
                Descripcion = "Botella de 30 capsulas"  
            },
            new {  
                Id = 5,  
                Descripcion = "Caja de 60 capsulas"  
            }
        );
    }
}
