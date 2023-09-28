using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class TipoMedicamentoRepository : GenericRepository<TipoMedicamento>, ITipoMedicamento
{
    private readonly DbAppContext _Context;
    public TipoMedicamentoRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public override async Task<IEnumerable<TipoMedicamento>> GetAllAsync()
    {
        return await _Context.Set<TipoMedicamento>()
                                    .Include(u => u.Medicamentos)
                                    .ToListAsync();
    }

}
