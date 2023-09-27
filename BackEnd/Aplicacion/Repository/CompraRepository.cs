using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class CompraRepository : GenericRepository<Compra>, ICompra
{
    private readonly DbAppContext _Context;
    public CompraRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public override async Task<IEnumerable<Compra>> GetAllAsync()
    {
        return await _Context.Set<Compra>()
                                .Include(p => p.Proveedores)
                                .Include(p => p.MetodosDePagos)
                                .ToListAsync();        
    }

    public async Task<Compra> GetByProveedorAsync(string proveedor)
    {
        return (await _Context.Set<Compra>()
                            .Include(u => u.Proveedores)
                            .FirstOrDefaultAsync(u => u.NumeroFactura!.ToString()==proveedor.ToLower()))!;
    }

    public async Task<Compra> GetByMetodoDePagoAsync(string metododepago)
    {
        return (await _Context.Set<Compra>()
                                .Include(u => u.MetodosDePagos)
                                .FirstOrDefaultAsync(u => u.NumeroFactura!.ToString()==metododepago.ToLower()))!;
    }

}
