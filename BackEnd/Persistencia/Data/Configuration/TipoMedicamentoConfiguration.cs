using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class TipoMedicamentoConfiguration : IEntityTypeConfiguration<TipoMedicamento>
{
    public void Configure(EntityTypeBuilder<TipoMedicamento> builder)
    {
        builder.ToTable("TipoMedicamento");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdTipoMedicamento")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Nombre)
            .HasColumnName("NombreTipo")
            .HasColumnType("varchar")
            .HasMaxLength(30)
            .IsRequired();

        builder.HasData(
            new {  
                Id = 1,  
                Nombre = "Tableta"  
            },
            new {  
                Id = 2,  
                Nombre = "Capsula"  
            }
        );
    }
}
