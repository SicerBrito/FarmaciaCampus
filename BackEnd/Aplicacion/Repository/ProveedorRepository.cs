using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class ProveedorRepository : GenericRepository<Proveedor>, IProveedor
{
    private readonly DbAppContext _Context;
    public ProveedorRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public override async Task<IEnumerable<Proveedor>> GetAllAsync()
    {
        return await _Context.Set<Proveedor>()
                                    .Include(u => u.Compras)
                                    .Include(u => u.Medicamentos)
                                    .ToListAsync();
    }
    
    //! Consulta Nro. 2
    public async Task<List<Proveedor>> ListarProveedoresConInformacionDeContacto()
    {
        return await _Context.Proveedores!
            .Include(p => p.Medicamentos)
            .Select(p => new Proveedor
            {
                Nombres = p.Nombres + " " + p.Apellidos,
                Apellidos = p.Apellidos,
                Compras = p.Compras,
                Medicamentos = p.Medicamentos!.Select(m => new Medicamento
                {
                    Nombre = m.Nombre,
                    ValorUnidad = m.ValorUnidad,
                    Stock = m.Stock
                }).ToList()
            })
            .ToListAsync();
    }

    //! Consulta Nro.13
    public async Task<List<Proveedor>> ObtenerProveedoresQueNoHanVendidoEnUltimoAnio()
    {
        var fechaHaceUnAnio = DateTime.Now.AddYears(-1);

        var proveedores = await _Context.Proveedores!
            .Where(proveedor => !proveedor.Compras!.Any(compra => compra.FechaCompra >= fechaHaceUnAnio))
            .ToListAsync();

        return proveedores;
    }

    //! Consulta Nro.24
    public async Task<Proveedor> ObtenerProveedorConMasSuministrosEn2023()
    {
        var proveedorConMasSuministros = await _Context.Proveedores!
            .Include(p => p.Compras)
            .Where(p => p.Compras!.Any(c => c.FechaCompra.Year == 2023))
            .OrderByDescending(p => p.Compras!.Count(c => c.FechaCompra.Year == 2023))
            .FirstOrDefaultAsync();

        return proveedorConMasSuministros!;
    }

    //! Consulta Nro.28
    public async Task<int> ObtenerNumeroProveedoresSuministraronMedicamentosEn2023()
    {
        var proveedoresEn2023 = await _Context.Compras!
            .Where(c => c.FechaCompra.Year == 2023)
            .Select(c => c.ProveedorId)
            .Distinct()
            .CountAsync();

        return proveedoresEn2023;
    }

    //! Consulta Nro.29
    public async Task<List<Proveedor>> ObtenerProveedoresDeMedicamentosConStockBajo()
    {
        var proveedoresDeMedicamentosConStockBajo = await _Context.Medicamentos!
            .Where(m => m.Stock < 50)
            .Select(m => m.Proveedores)
            .Distinct()
            .ToListAsync();

        return proveedoresDeMedicamentosConStockBajo!;
    }

    //! Consulta Nro.35
    public async Task<List<Proveedor>> ObtenerProveedoresCon5MedicamentosDiferentesEn2023()
    {
        var proveedoresCon5Medicamentos = await _Context.Proveedores!
            .Where(p => p.Compras!
                .Where(c => c.FechaCompra.Year == 2023)
                .SelectMany(c => c.MedicamentosComprados!.Select(mc => mc.MedicamentoId))
                .Distinct()
                .Count() >= 5)
            .ToListAsync();

        return proveedoresCon5Medicamentos;
    }

}
