using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
{
    public void Configure(EntityTypeBuilder<Ciudad> builder)
    {
        builder.ToTable("Ciudad");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdCiudad")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Nombre)
            .HasColumnName("NombreCiudad")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.DepartamentoId)
            .HasColumnName("Departamento_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Departamentos)
            .WithMany(p => p.Ciudades)
            .HasForeignKey(p => p.DepartamentoId);

        builder.HasData(
            new {  
                Id = 1,  
                Nombre = "Bogota",  
                DepartamentoId = 6 
            },  
            new {  
                Id = 2,  
                Nombre = "Medellin",  
                DepartamentoId = 2 
            },  
            new {  
                Id = 3,  
                Nombre = "Cartagena",  
                DepartamentoId = 4 
            },  
            new {
                Id = 4,  
                Nombre = "Cali",  
                DepartamentoId = 1 
            },  
            new {  
                Id = 5,  
                Nombre = "Barranquilla",  
                DepartamentoId = 2 
            },  
            new {  
                Id = 6,  
                Nombre = "Santa Marta",  
                DepartamentoId = 4 
            },  
            new {  
                Id = 7,  
                Nombre = "Bucaramanga",  
                DepartamentoId = 6 
            }  
        );

    }
}
