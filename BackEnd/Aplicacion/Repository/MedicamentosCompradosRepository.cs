using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class MedicamentosCompradosRepository : GenericRepository<MedicamentosComprados>, IMedicamentosComprados
{
    private readonly DbAppContext _Context;
    public MedicamentosCompradosRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public override async Task<IEnumerable<MedicamentosComprados>> GetAllAsync()
    {
        return await _Context.Set<MedicamentosComprados>()
                                .Include(p => p.Compras)
                                .Include(p => p.Medicamentos)
                                .ToListAsync();
    }

    public async Task<MedicamentosComprados> GetByComprasAsync(string compras)
    {
        return (await _Context.Set<MedicamentosComprados>()
                            .Include(u => u.Compras)
                            .FirstOrDefaultAsync(u => u.Id!.ToString()==compras.ToLower()))!;
    }

    public async Task<MedicamentosComprados> GetByMedicamentoAsync(string medicamento)
    {
        return (await _Context.Set<MedicamentosComprados>()
                            .Include(u => u.Medicamentos)
                            .FirstOrDefaultAsync(u => u.Id!.ToString()==medicamento.ToLower()))!;
    }
}
