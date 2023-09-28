using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class TipoViaRepository : GenericRepository<TipoVia>, ITipoVia
{
    private readonly DbAppContext _Context;
    public TipoViaRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public override async Task<IEnumerable<TipoVia>> GetAllAsync()
    {
        return await _Context.Set<TipoVia>()
                                    .Include(u => u.Direcciones)
                                    .ToListAsync();
    }

}
