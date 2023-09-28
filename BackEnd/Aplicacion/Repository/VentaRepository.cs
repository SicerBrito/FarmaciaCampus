using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class VentaRepository : GenericRepository<Venta>, IVenta
{
    private readonly DbAppContext _Context;
    public VentaRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public override async Task<IEnumerable<Venta>> GetAllAsync()
    {
        return await _Context.Set<Venta>()
                                .Include(p => p.Usuarios)
                                .Include(p => p.Empleados)
                                .Include(p => p.MetodosDePagos)
                                .Include(p => p.Inventarios)
                                .Include(p => p.MedicamentosVendidos)
                                .ToListAsync();
    }

    public async Task<Venta> GetByClienteAsync(string cliente)
    {
        return (await _Context.Set<Venta>()
                            .Include(u => u.Usuarios)
                            .FirstOrDefaultAsync(u => u.NumeroFactura!.ToString()==cliente.ToLower()))!;
    }

    public async Task<Venta> GetByEmpleadoAsync(string empleado)
    {
        return (await _Context.Set<Venta>()
                            .Include(u => u.Empleados)
                            .FirstOrDefaultAsync(u => u.NumeroFactura!.ToString()==empleado.ToLower()))!;
    }

    public async Task<Venta> GetByMetodoDePagoAsync(string metodoDePago)
    {
        return (await _Context.Set<Venta>()
                            .Include(u => u.MetodosDePagos)
                            .FirstOrDefaultAsync(u => u.NumeroFactura!.ToString()==metodoDePago.ToLower()))!;
    }
}
