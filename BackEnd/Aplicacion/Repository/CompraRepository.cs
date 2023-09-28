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
                                .Include(p => p.Inventarios)
                                .Include(p => p.MedicamentosComprados)
                                .ToListAsync();        
    }

    //! Consulta Nro.16
    public async Task<decimal> ObtenerGananciaTotalPorProveedorEn2023(int proveedorId)
    {
        var fechaInicio2023 = new DateTime(2023, 1, 1);
        var fechaFin2023 = new DateTime(2023, 12, 31);

        var gananciaTotal = await _Context.Compras!
            .Where(c => c.ProveedorId == proveedorId && c.FechaCompra >= fechaInicio2023 && c.FechaCompra <= fechaFin2023)
            .SumAsync(c => c.MedicamentosComprados!.Sum(mc => mc.CantidadCompra * Convert.ToDecimal(mc.Medicamentos!.ValorUnidad)));

        return gananciaTotal!;
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
