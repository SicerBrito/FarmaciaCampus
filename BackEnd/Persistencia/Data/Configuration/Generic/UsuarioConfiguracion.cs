using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuracion;
    public class UsuarioConfiguracion : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.Property(p => p.Id)
                .HasAnnotation("MySqlValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasColumnName("Id_Usuario")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Username)
                .HasColumnName("Username")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Password)
                .HasColumnName("Password")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(p => p.RefreshTokens)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            builder.HasData(
                new {
                    Id = 1,
                    Username = "Sicer Brito",
                    Email = "britodelgado514@gmail.com",
                    Password = "123456"
                },
                new {
                    Id = 2,
                    Username = "Angelica Morales",
                    Email = "angedeveloper@gmail.com",
                    Password = "123"
                }
            );
        
        }
    }