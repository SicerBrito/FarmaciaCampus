using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class CargoEmpleadoRepository : GenericRepository<CargoEmpleado>, ICargoEmpleado
{
    private readonly DbAppContext _Context;
    public CargoEmpleadoRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
