using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
{
    public void Configure(EntityTypeBuilder<Genero> builder)
    {
        builder.ToTable("Genero");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdGenero")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Nombre)
            .HasColumnName("NombreGenero")
            .HasColumnType("varchar")
            .HasMaxLength(25)
            .IsRequired();

        builder.HasData(
            new {    
                Id = 1,    
                Nombre = "Masculino"  
            },  
            new {  
                Id = 2,  
                Nombre = "Femenino"  
            },  
            new {  
                Id = 3,  
                Nombre = "Otro"  
            },  
            new {  
                Id = 4,  
                Nombre = "Helicoptero"  
            },  
            new {  
                Id = 5,  
                Nombre = "Prefiero no decirlo"  
            } 
        );
            
    }
}
