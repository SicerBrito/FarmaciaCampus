using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamento
{
    private readonly DbAppContext _Context;
    public MedicamentoRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public override async Task<IEnumerable<Medicamento>> GetAllAsync()
    {
        return await _Context.Set<Medicamento>()
                                .Include(p => p.Tipos)
                                .Include(p => p.Categorias)
                                .Include(p => p.Presentaciones)
                                .Include(p => p.Proveedores)
                                .Include(p => p.MedicamentosComprados)
                                .Include(p => p.MedicamentosVendidos)
                                .Include(p => p.FormulaMedicamentos)
                                .ToListAsync();
    }

    //! Consulta Nro.1
    public IQueryable<Medicamento> GetAllMedicamentos()
    {
        return _Context.Set<Medicamento>().Where(m => m.Stock < 50);
    }


    //! Consulta Nro.2
    public async Task<IEnumerable<Medicamento?>> ObtenerMedicamentosCompradosPorProveedorId(int proveedorId)
    {
        return await _Context.MedicamentosComprados!
            .Where(c => c.Medicamentos!.ProveedorId == proveedorId)
            .Select(c => c.Medicamentos)
            .ToListAsync();
    }

    //! Consulta Nro.6
    public async Task<List<Medicamento>> ObtenerMedicamentosCaducanAntesDe2024()
    {
        var fechaLimite = new DateTime(2024, 1, 1);

        var medicamentosCaducanAntesDe2024 = await _Context.Medicamentos!
            .Where(medicamento => medicamento.FechaExpiracion < fechaLimite)
            .ToListAsync();

        return medicamentosCaducanAntesDe2024;
    }

    //!Consulta Nro.7
    public async Task<IEnumerable<object>> ObtenerTotalMedicamentosVendidosPorProveedor()
    {
        var medicamentosPorProveedor = await _Context.Medicamentos!
        .GroupBy(medicamento => medicamento.Proveedores!.Nombres)
        .Select(group => new         
        {
            group.First().Proveedores,
            TotalVendidos = group.Sum(medicamento => medicamento.MedicamentosVendidos!.Sum(vendido => vendido.CantidadVendida)) 
        })
        .ToListAsync();

        return medicamentosPorProveedor!;
    }

    // public async Task<Dictionary<string, int>> ObtenerTotalMedicamentosVendidosPorProveedor()
    // {
    //     var medicamentosPorProveedor = await _Context.Medicamentos!
    //         .GroupBy(medicamento => medicamento.Proveedores.Nombres)
    //         .Select(group => new
    //         {
    //             Proveedor = group.Key,
    //             TotalVendidos = group.Sum(medicamento => medicamento.MedicamentosVendidos.Sum(vendido => vendido.CantidadVendida))
    //         })
    //         .ToDictionary(result => result.Proveedor, result => result.TotalVendidos);

    //     return medicamentosPorProveedor!;
    // }

    public async Task<Medicamento> GetByCategoriaMedicamentoAsync(string categoriaMedicamento)
    {
        return (await _Context.Set<Medicamento>()
                            .Include(u => u.Categorias)
                            .FirstOrDefaultAsync(u => u.Nombre!.ToLower()==categoriaMedicamento.ToLower()))!;
    }

    public async Task<Medicamento> GetByPresentacionAsync(string presentacion)
    {
        return (await _Context.Set<Medicamento>()
                            .Include(u => u.Presentaciones)
                            .FirstOrDefaultAsync(u => u.Nombre!.ToLower()==presentacion.ToLower()))!;
    }

    public async Task<Medicamento> GetByProveedorAsync(string proveedor)
    {
        return (await _Context.Set<Medicamento>()
                            .Include(u => u.Proveedores)
                            .FirstOrDefaultAsync(u => u.Nombre!.ToLower()==proveedor.ToLower()))!;
    }

    public async Task<Medicamento> GetByTipoMedicamentoAsync(string tipoMedicamento)
    {
        return (await _Context.Set<Medicamento>()
                            .Include(u => u.Tipos)
                            .FirstOrDefaultAsync(u => u.Nombre!.ToLower()==tipoMedicamento.ToLower()))!;
    }


}
