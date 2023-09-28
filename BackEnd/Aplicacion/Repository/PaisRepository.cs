using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class PaisRepository : GenericRepository<Pais>, IPais
{
    private readonly DbAppContext _Context;
    public PaisRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public override async Task<IEnumerable<Pais>> GetAllAsync()
    {
        return await _Context.Set<Pais>()
                                    .Include(u => u.Departamentos)
                                    .ToListAsync();
    }

}
