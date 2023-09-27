using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class DireccionConfiguration : IEntityTypeConfiguration<Direccion>
{
    public void Configure(EntityTypeBuilder<Direccion> builder)
    {
        builder.ToTable("Direccion");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdDireccion")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.NombreDireccion)
            .HasColumnName("Direccion")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.TipoDireccionId)
            .HasColumnName("TipoDireccion_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.TipoDirecciones)
            .WithMany(p => p.Direcciones)
            .HasForeignKey(p => p.TipoDireccionId);

        builder.Property(p => p.TipoViaId)
            .HasColumnName("TipoVia_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.TipoVias)
            .WithMany(p => p.Direcciones)
            .HasForeignKey(p => p.TipoViaId);

        builder.Property(p => p.NroDireccion)
            .HasColumnName("NroDireccion")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.CiudadId)
            .HasColumnName("Ciudad_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Ciudades)
            .WithMany(p => p.Direcciones)
            .HasForeignKey(p => p.CiudadId);

        builder.Property(p => p.CodigoPostal)
            .HasColumnName("CodigoPostal")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.FarmaciaId)
            .HasColumnName("Farmacia_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Farmacias)
            .WithMany(p => p.Direcciones)
            .HasForeignKey(p => p.FarmaciaId);
        
    }
}
