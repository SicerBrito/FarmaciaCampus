using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class PaisConfiguration : IEntityTypeConfiguration<Pais>
{
    public void Configure(EntityTypeBuilder<Pais> builder)
    {
        builder.ToTable("Pais");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdPais")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Nombre)
            .HasColumnName("NombrePais")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.HasData(
            new {  
                Id = 1,  
                Nombre = "Estados Unidos"  
            },
            new {  
                Id = 2,  
                Nombre = "Canada"  
            },
            new {  
                Id = 3,  
                Nombre = "Mexico"  
            },
            new {  
                Id = 4,  
                Nombre = "Europa"  
            },
            new {  
                Id = 5,  
                Nombre = "Asia"  
            },
            new {  
                Id = 6,  
                Nombre = "Africa"  
            },
            new {  
                Id = 7,  
                Nombre = "Oceania"  
            },
            new {  
                Id = 8,  
                Nombre = "Australia"  
            },
            new {  
                Id = 9,  
                Nombre = "Brasil"  
            },
            new {  
                Id = 10,  
                Nombre = "China"  
            },
            new {  
                Id = 11,  
                Nombre = "India"  
            },
            new {  
                Id = 12,  
                Nombre = "Indonesia"  
            },
            new {  
                Id = 13,  
                Nombre = "Japon"  
            },
            new {  
                Id = 14,  
                Nombre = "Marruecos"  
            },
            new {  
                Id = 15,  
                Nombre = "Nigeria"  
            },
            new {  
                Id = 16,  
                Nombre = "Rusia"  
            },
            new {  
                Id = 17,  
                Nombre = "Sudafrica"  
            },
            new {  
                Id = 18,  
                Nombre = "Tailandia"  
            },
            new {  
                Id = 19,  
                Nombre = "Argentina"  
            },
            new {  
                Id = 20,  
                Nombre = "Austria"  
            },
            new {  
                Id = 21,  
                Nombre = "Belgica"  
            },
            new {  
                Id = 22,  
                Nombre = "Bulgaria"  
            },
            new {  
                Id = 23,  
                Nombre = "Chile"  
            },
            new {  
                Id = 24,  
                Nombre = "Colombia"  
            },
            new {  
                Id = 25,  
                Nombre = "Costa Rica"  
            }
        );
            
    }
}
