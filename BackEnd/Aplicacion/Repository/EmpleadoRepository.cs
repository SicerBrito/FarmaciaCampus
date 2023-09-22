using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
{
    private readonly DbAppContext _Context;
    public EmpleadoRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
