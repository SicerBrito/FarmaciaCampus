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
                                .ToListAsync();
    }

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
