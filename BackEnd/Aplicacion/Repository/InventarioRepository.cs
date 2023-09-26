using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class InventarioRepository : GenericRepository<Inventario>, IInventario
{    
    private readonly DbAppContext _Context;
    public InventarioRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public async Task<Inventario> GetByCompraAsync(string compra)
    {
        return (await _Context.Set<Inventario>()
                            .Include(u => u.Compras)
                            .FirstOrDefaultAsync(u => u.Id!.ToString()==compra.ToLower()))!;
    }

    public async Task<Inventario> GetByFarmaciaAsync(string farmacia)
    {
        return (await _Context.Set<Inventario>()
                            .Include(u => u.Farmacias)
                            .FirstOrDefaultAsync(u => u.Id!.ToString()==farmacia.ToLower()))!;
    }

    public async Task<Inventario> GetByVentaAsync(string venta)
    {
        return (await _Context.Set<Inventario>()
                            .Include(u => u.Ventas)
                            .FirstOrDefaultAsync(u => u.Id!.ToString()==venta.ToLower()))!;
    }
}
