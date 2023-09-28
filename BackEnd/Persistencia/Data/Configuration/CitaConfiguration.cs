using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class CitaConfiguration : IEntityTypeConfiguration<Cita>
{
    public void Configure(EntityTypeBuilder<Cita> builder)
    {
        builder.ToTable("Cita");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdCita")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.FechaCita)
            .HasColumnName("FechaCita")
            .HasColumnType("DateTime")
            .IsRequired();

        builder.Property(p => p.EstadoCitaId)
            .HasColumnName("EstadoCita_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.EstadoCitas)
            .WithMany(p => p.Citas)
            .HasForeignKey(p => p.EstadoCitaId);

        builder.Property(p => p.MedicoId)
            .HasColumnName("Medico_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Empleados)
            .WithMany(p => p.Citas)
            .HasForeignKey(p => p.MedicoId);

        builder.Property(p => p.UsuarioId)
            .HasColumnName("Usuario_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Usuarios)
            .WithMany(p => p.Citas)
            .HasForeignKey(p => p.UsuarioId);

        builder.HasData(
            new {
                Id = 1,
                FechaCita = new DateTime (2023,10,21),
                EstadoCitaId = 1,
                MedicoId = 1,
                UsuarioId = 2
            },
            new {
                Id = 2,
                FechaCita = new DateTime (2023,10,21),
                EstadoCitaId = 6,
                MedicoId = 2,
                UsuarioId = 1
            }
        );

    }
}
