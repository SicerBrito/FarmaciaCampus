using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class MedicamentosVendidosRepository : GenericRepository<MedicamentosVendidos>, IMedicamentosVendidos
{
    private readonly DbAppContext _Context;
    public MedicamentosVendidosRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public override async Task<IEnumerable<MedicamentosVendidos>> GetAllAsync()
    {
        return await _Context.Set<MedicamentosVendidos>()
                                .Include(p => p.Ventas)
                                .Include(p => p.Medicamentos)
                                .ToListAsync();
    }

    public async Task<MedicamentosVendidos> GetByMedicamentoAsync(string medicamento)
    {
        return (await _Context.Set<MedicamentosVendidos>()
                            .Include(u => u.Medicamentos)
                            .FirstOrDefaultAsync(u => u.Id!.ToString()==medicamento.ToLower()))!;
    }

    public async Task<MedicamentosVendidos> GetByVentaAsync(string venta)
    {
        return (await _Context.Set<MedicamentosVendidos>()
                            .Include(u => u.Ventas)
                            .FirstOrDefaultAsync(u => u.Id!.ToString()==venta.ToLower()))!;
    }
}
