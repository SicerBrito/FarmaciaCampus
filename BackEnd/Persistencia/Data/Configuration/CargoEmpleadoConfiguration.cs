using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class CargoEmpleadoConfiguration : IEntityTypeConfiguration<CargoEmpleado>
{
    public void Configure(EntityTypeBuilder<CargoEmpleado> builder)
    {
        throw new NotImplementedException();
    }
}
