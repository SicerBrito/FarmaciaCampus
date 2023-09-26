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
            
    }
}
