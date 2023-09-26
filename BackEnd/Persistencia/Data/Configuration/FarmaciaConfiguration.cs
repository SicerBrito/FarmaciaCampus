using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class FarmaciaConfiguration : IEntityTypeConfiguration<Farmacia>
{
    public void Configure(EntityTypeBuilder<Farmacia> builder)
    {
        builder.ToTable("Farmacia");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdFarmacia")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.NombreFarmacia)
            .HasColumnName("NombreFarmacia")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Propietario)
            .HasColumnName("Propietario")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.FechaInauguracion)
            .HasColumnName("FechaInauguracion")
            .HasColumnType("DateTime")
            .IsRequired();

        builder.Property(p => p.NumeroContacto)
            .HasColumnName("NumeroContacto")
            .HasColumnType("varchar")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(p => p.URLSitioWeb)
            .HasColumnName("URLSitioWeb")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();

    }
}
