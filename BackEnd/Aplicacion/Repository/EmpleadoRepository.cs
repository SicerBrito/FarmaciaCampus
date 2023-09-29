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

    public override async Task<IEnumerable<Empleado>> GetAllAsync()
    {
        return await _Context.Set<Empleado>()
                                .Include(p => p.Farmacias)
                                .Include(p => p.Cargos)
                                .Include(u => u.Citas)
                                .Include(u => u.HistorialesMedicos)
                                .Include(u => u.FormulasMedicas)
                                .Include(u => u.Ventas)
                                .ToListAsync();
    }

    //! Consulta Nro.20
    public async Task<List<Empleado>> ObtenerEmpleadosConMasDe5Ventas()
    {
        var empleadosConMasDe5Ventas = await _Context.Empleados!
            .Where(e => e.Ventas!.Count > 5)
            .ToListAsync();

        return empleadosConMasDe5Ventas;
    }

    //! Consulta Nro.23
    public async Task<List<Empleado>> ObtenerEmpleadosSinVentasEn2023()
    {
        var empleadosSinVentasEn2023 = await _Context.Empleados!
            .Where(e => !e.Ventas!.Any(v => v.FechaVenta.Year == 2023))
            .ToListAsync();

        return empleadosSinVentasEn2023;
    }

    //! Consulta Nro.32
    public async Task<Empleado> ObtenerEmpleadoMayorCantidadMedicamentosVendidosEn2023()
    {
        var empleadoConMayorCantidad = await _Context.Empleados!
            .Where(e => e.Ventas!.Any(v => v.FechaVenta.Year == 2023))
            .OrderByDescending(e => e.Ventas!
                .Where(v => v.FechaVenta.Year == 2023)
                .SelectMany(v => v.MedicamentosVendidos!)
                .Select(mv => mv.MedicamentoId)
                .Distinct()
                .Count())
            .FirstOrDefaultAsync();

        return empleadoConMayorCantidad!;
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
