using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class CargoEmpleadoRepository : GenericRepository<CargoEmpleado>, ICargoEmpleado
{
    private readonly DbAppContext _Context;
    public CargoEmpleadoRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public override async Task<IEnumerable<CargoEmpleado>> GetAllAsync()
    {
        return await _Context.Set<CargoEmpleado>()
                                .Include(p => p.Empleados)
                                .ToListAsync();        
    }
}
