using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class MedicamentosCompradosConfiguration : IEntityTypeConfiguration<MedicamentosComprados>
{
    public void Configure(EntityTypeBuilder<MedicamentosComprados> builder)
    {
        builder.ToTable("MedicamentosComprados");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdMedicamentosComprados")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.CompraId)
            .HasColumnName("Compra_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Compras)
            .WithMany(p => p.MedicamentosComprados)
            .HasForeignKey(p => p.CompraId);

        builder.Property(p => p.MedicamentoId)
            .HasColumnName("Medico_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Medicamentos)
            .WithMany(p => p.MedicamentosComprados)
            .HasForeignKey(p => p.MedicamentoId);

        builder.Property(p => p.CantidadCompra)
            .HasColumnName("CantidadCompra")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.ValorTotalCompra)
            .HasColumnName("ValorTotalCompra")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.HasData(
            new {  
                Id = 1,  
                CantidadCompra = 5,  
                ValorTotalCompra = "50000",  
                CompraId = 1,  
                MedicamentoId = 5  
            },  
            new {  
                Id = 2,  
                CantidadCompra = 2,  
                ValorTotalCompra = "60000",  
                CompraId = 2,  
                MedicamentoId = 1  
            },  
            new {  
                Id = 3,  
                CantidadCompra = 21,  
                ValorTotalCompra = "21000",  
                CompraId = 1,  
                MedicamentoId = 3  
            }  
        );

    }
}
