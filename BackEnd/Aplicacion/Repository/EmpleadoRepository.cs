using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
{
    private readonly DbAppContext _Context;
    public EmpleadoRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public async Task<Empleado> GetByCargoAsync(string cargo)
    {
        return (await _Context.Set<Empleado>()
                            .Include(u => u.Cargos)
                            .FirstOrDefaultAsync(u => u.Nombres!.ToLower()==cargo.ToLower()))!;
    }

    public async Task<Empleado> GetByFarmaciaAsync(string farmacia)
    {
        return (await _Context.Set<Empleado>()
                            .Include(u => u.Farmacias)
                            .FirstOrDefaultAsync(u => u.Nombres!.ToLower()==farmacia.ToLower()))!;
    }
}
