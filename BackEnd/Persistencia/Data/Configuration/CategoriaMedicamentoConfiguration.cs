using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class CategoriaMedicamentoConfiguration : IEntityTypeConfiguration<CategoriaMedicamento>
{
    public void Configure(EntityTypeBuilder<CategoriaMedicamento> builder)
    {
        builder.ToTable("CategoriaMedicamento");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdCategoriaMedicamento")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Nombre)
            .HasColumnName("NombreMedicamento")
            .HasColumnType("varchar")
            .HasMaxLength(25)
            .IsRequired();

        builder.HasData(
            new { 
                Id = 1,    
                Nombre = "Analgesico"
            },
            new {  
                Id = 2,  
                Nombre = "Antiinflamatorio"  
            },
            new {  
                Id = 3,  
                Nombre = "Antibiotico"  
            },  
            new {  
                Id = 4,  
                Nombre = "Antiulceroso"  
            } 
        );
    }
}
