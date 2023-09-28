using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
{
    public void Configure(EntityTypeBuilder<Paciente> builder)
    {
        builder.ToTable("Paciente");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdPaciente")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Nombres)
            .HasColumnName("Nombres")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Apellidos)
            .HasColumnName("Apellidos")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.NumeroContacto)
            .HasColumnName("NroContacto")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.FechaNacimiento)
            .HasColumnName("FechaNacimiento")
            .HasColumnType("DateTime")
            .IsRequired();

        builder.Property(p => p.GeneroId)
            .HasColumnName("Genero_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Generos)
            .WithMany(p => p.Pacientes)
            .HasForeignKey(p => p.GeneroId);

        builder.HasData(
            new {  
                Id = 1,  
                Nombres = "Owell Andry",  
                Apellidos = "Polanco Silva",  
                NumeroContacto = "3221243579",  
                FechaNacimiento = new DateTime (2003,03,12),  
                GeneroId = 1  
            },  
            new {  
                Id = 2,  
                Nombres = "Sherman Andres",  
                Apellidos = "Torres Alvares",  
                NumeroContacto = "6355050",  
                FechaNacimiento = new DateTime (2003,08,10),  
                GeneroId = 1  
            }
        );
            
    }
}
