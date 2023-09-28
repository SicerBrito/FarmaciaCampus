using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>
{
    public void Configure(EntityTypeBuilder<Medicamento> builder)
    {
        builder.ToTable("Medicamento");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdMedicamento")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Nombre)
            .HasColumnName("NombreMedicamento")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.TipoId)
            .HasColumnName("TipoMedicamento_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Tipos)
            .WithMany(p => p.Medicamentos)
            .HasForeignKey(p => p.TipoId);

        builder.Property(p => p.CategoriaId)
            .HasColumnName("CategoriaMedicamento_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Categorias)
            .WithMany(p => p.Medicamentos)
            .HasForeignKey(p => p.CategoriaId);

        builder.Property(p => p.PresentacionId)
            .HasColumnName("PresentacionMedicamento_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Presentaciones)
            .WithMany(p => p.Medicamentos)
            .HasForeignKey(p => p.PresentacionId);

        builder.Property(p => p.FechaExpiracion)
            .HasColumnName("FechaExpiracion")
            .HasColumnType("DateTime")
            .IsRequired();

        builder.Property(p => p.ValorUnidad)
            .HasColumnName("ValorUnidad")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.ProveedorId)
            .HasColumnName("Proveedor_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Proveedores)
            .WithMany(p => p.Medicamentos)
            .HasForeignKey(p => p.ProveedorId);

        builder.Property(p => p.Stock)
            .HasColumnName("Stock")
            .HasColumnType("BIGINT")
            .IsRequired();

        builder.HasData(
            new {  
                Id = 1,  
                Nombre = "Aspirina",  
                FechaExpiracion = new DateTime (2024,08,31),
                ValorUnidad = "2000",
                TipoId = 1,  
                CategoriaId = 1,  
                PresentacionId = 2,  
                ProveedorId = 2,  
                Stock = 80  
            },  
            new {  
                Id = 2,  
                Nombre = "Ibuprofeno",  
                FechaExpiracion = new DateTime (2024,10,15),
                ValorUnidad = "5000",
                TipoId = 2,  
                CategoriaId = 2,  
                PresentacionId = 2,  
                ProveedorId = 2,  
                Stock = 20  
            },  
            new {  
                Id = 3,  
                Nombre = "Paracetamol",  
                FechaExpiracion = new DateTime (2023,12,31),
                ValorUnidad = "1000",
                TipoId = 1,  
                CategoriaId = 1,  
                PresentacionId = 2,  
                ProveedorId = 2,  
                Stock = 45  
            },  
            new {  
                Id = 4,  
                Nombre = "Amoxicilina",  
                FechaExpiracion = new DateTime (2024,09,30),
                ValorUnidad = "3500",
                TipoId = 2,  
                CategoriaId = 3,  
                PresentacionId = 2,  
                ProveedorId = 2,  
                Stock = 70  
            },   
            new {  
                Id = 5,  
                Nombre = "Omeprazol",  
                FechaExpiracion = new DateTime (2024,11,30),
                ValorUnidad = "2200",
                TipoId = 2,  
                CategoriaId = 4,  
                PresentacionId = 2,  
                ProveedorId = 2,  
                Stock = 10  
            },  
            new { 
                Id = 6,  
                Nombre = "Loratadina",  
                FechaExpiracion = new DateTime (2022,09,04),
                ValorUnidad = "10000",
                TipoId = 1,  
                CategoriaId = 1,  
                PresentacionId = 3,  
                ProveedorId = 1,  
                Stock = 100  
            }
        );

    }
}
