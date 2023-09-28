using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class TipoDireccionConfiguration : IEntityTypeConfiguration<TipoDireccion>
    {
        public void Configure(EntityTypeBuilder<TipoDireccion> builder)
        {
            builder.ToTable("TipoDireccion");

            builder.Property(p => p.Id)
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasColumnName("IdTipoDireccion")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Nombre)
                .HasColumnName("NombreDireccion")
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();

            builder.HasData(
               new {  
                    Id = 1,  
                    Nombre = "Residencial" 
                },
                new {  
                    Id = 2,  
                    Nombre = "Distrital"
                },
                new {  
                    Id = 3,  
                    Nombre = "Oficina Principal"
                },
                new {  
                    Id = 4,  
                    Nombre = "Comercial"  
                }
            );
        }
    }
