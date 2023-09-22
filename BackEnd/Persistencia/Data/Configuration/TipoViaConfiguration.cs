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

        }
    }
