using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class EstadoCitaConfiguration : IEntityTypeConfiguration<EstadoCita>
{
    public void Configure(EntityTypeBuilder<EstadoCita> builder)
    {
        builder.ToTable("EstadoCita");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdEstadoCita")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Nombre)
            .HasColumnName("NombreEstado")
            .HasColumnType("varchar")
            .HasMaxLength(25)
            .IsRequired();
            
        builder.HasData(
            new {  
                Id = 1,  
                Nombre = "Programada"  
            },  
            new {  
                Id = 2,  
                Nombre = "Confirmada"  
            },  
            new {  
                Id = 3,  
                Nombre = "No confirmada"  
            },  
            new {  
                Id = 4,  
                Nombre = "Cancelada"  
            },  
            new {  
                Id = 5,  
                Nombre = "Atendida"  
            },  
            new {  
                Id = 6,  
                Nombre = "En espera"  
            },  
            new {  
                Id = 7,  
                Nombre = "Reprogramada"  
            },  
            new {  
                Id = 8,  
                Nombre = "Rechazada"  
            }
        );
    }
}
