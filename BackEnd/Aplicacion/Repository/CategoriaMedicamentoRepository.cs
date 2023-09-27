using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class CategoriaMedicamentoRepository : GenericRepository<CategoriaMedicamento>, ICategoriaMedicamento
{
    private readonly DbAppContext _Context;
    public CategoriaMedicamentoRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public override async Task<IEnumerable<CategoriaMedicamento>> GetAllAsync()
    {
        return await _Context.Set<CategoriaMedicamento>()
                                .Include(p => p.Medicamentos)
                                .ToListAsync();        
    }
}
