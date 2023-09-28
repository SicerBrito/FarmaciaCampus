using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class TipoViaConfiguration : IEntityTypeConfiguration<TipoVia>
    {
        public void Configure(EntityTypeBuilder<TipoVia> builder)
        {
            builder.ToTable("TipoVia");

            builder.Property(p => p.Id)
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasColumnName("IdTipoVia")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Nombre)
                .HasColumnName("NombreTipoVia")
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(p => p.Abreviatura)
                .HasColumnName("Abreviatura")
                .HasColumnType("varchar")
                .HasMaxLength(5)
                .IsRequired();

            builder.HasData(
                new {  
                    Id = 1,  
                    Nombre = "Calle",  
                    Abreviatura = "Cal"
                },
                new {  
                    Id = 2,  
                    Nombre = "Avenida",  
                    Abreviatura = "Av"
                },
                new {  
                    Id = 3,  
                    Nombre = "Boulevard",  
                    Abreviatura = "Blvd"
                },
                new {  
                    Id = 4,  
                    Nombre = "Carretera",  
                    Abreviatura = "Carr"
                },
                new {  
                    Id = 5,  
                    Nombre = "Paseo",  
                    Abreviatura = "Pso"
                },
                new {  
                    Id = 6,  
                    Nombre = "Camino",  
                    Abreviatura = "Cam"
                },
                new {  
                    Id = 7,  
                    Nombre = "Plaza",  
                    Abreviatura = "Plz"
                },
                new {  
                    Id = 8,  
                    Nombre = "Via",  
                    Abreviatura = "Via"
                }
            );

        }
    }
