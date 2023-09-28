using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class CargoEmpleadoConfiguration : IEntityTypeConfiguration<CargoEmpleado>
{
    public void Configure(EntityTypeBuilder<CargoEmpleado> builder)
    {
        builder.ToTable("CargoEmpleado");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdCargoEmpleado")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Nombre)
            .HasColumnName("NombreCargo")
            .HasColumnType("varchar")
            .HasMaxLength(25)
            .IsRequired();

        builder.HasData(
            new {  
                Id = 1,
                Nombre = "Medico" 
            },  
            new {  
                Id = 2,
                Nombre = "Farmaceutico" 
            },  
            new {  
                Id = 3,
                Nombre = "Cajero" 
            },  
            new {  
                Id = 4,
                Nombre = "Repartidor" 
            },  
            new {  
                Id = 5,
                Nombre = "Contador" 
            }  
        );
    }
}
