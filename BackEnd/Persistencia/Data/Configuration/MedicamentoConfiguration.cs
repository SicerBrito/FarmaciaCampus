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

    }
}
