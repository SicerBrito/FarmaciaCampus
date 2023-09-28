using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("Empleado");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdEmpleado")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.FarmaciaId)
            .HasColumnName("Farmacia_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Farmacias)
            .WithMany(p => p.Empleados)
            .HasForeignKey(p => p.FarmaciaId);

        builder.Property(p => p.Nombres)
            .HasColumnName("Nombres")
            .HasColumnType("varchar")
            .HasMaxLength(60)
            .IsRequired();

        builder.Property(p => p.Apellidos)
            .HasColumnName("Apellidos")
            .HasColumnType("varchar")
            .HasMaxLength(60)
            .IsRequired();

        builder.Property(p => p.CargoId)
            .HasColumnName("Cargo_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Cargos)
            .WithMany(p => p.Empleados)
            .HasForeignKey(p => p.CargoId);

        builder.Property(p => p.Sueldo)
            .HasColumnName("Sueldo")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.FechaContratacion)
            .HasColumnName("FechaContratacion")
            .HasColumnType("DateTime")
            .IsRequired();

        builder.HasData(
            new {  
                Id = 1,  
                Nombres = "Juan David",  
                Apellidos = "Perez Numa",  
                Sueldo = "5000000",  
                FechaContratacion = new DateTime (2023,09,24),  
                FarmaciaId = 1,  
                CargoId = 1  
            },  
            new {  
                Id = 2,  
                Nombres = "Konny Liseth",  
                Apellidos = "Alucema Torres",  
                Sueldo = "2000000",  
                FechaContratacion = new DateTime (2024,09,11),  
                FarmaciaId = 1,  
                CargoId = 1  
            },  
            new {  
                Id = 3,  
                Nombres = "Maria Angelica",  
                Apellidos = "Morales Silva",  
                Sueldo = "2200000",  
                FechaContratacion = new DateTime (2024,03,18),  
                FarmaciaId = 1,  
                CargoId = 2  
            }
        );
            
    }
}
