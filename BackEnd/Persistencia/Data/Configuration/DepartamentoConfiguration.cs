using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("Departamento");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdDepartamento")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Nombre)
            .HasColumnName("NombreDepartamento")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.PaisId)
            .HasColumnName("Pais_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasData(
            new {  
                Id = 1,  
                Nombre = "Putumayo",  
                PaisId = 24 
            },  
            new {  
                Id = 2,  
                Nombre = "Huila",  
                PaisId = 24 
            },  
            new {  
                Id = 3,  
                Nombre = "La Guajira",  
                PaisId = 24 
            },  
            new {  
                Id = 4,  
                Nombre = "Magdalena",  
                PaisId = 24 
            },  
            new {  
                Id = 5,  
                Nombre = "Meta",  
                PaisId = 24 
            },  
            new {  
                Id = 6,  
                Nombre = "Santander",  
                PaisId = 24 
            } 
        );
            
    }
}
