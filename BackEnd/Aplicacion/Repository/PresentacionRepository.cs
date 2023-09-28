using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class PresentacionRepository : GenericRepository<Presentacion>, IPresentacion
{
    private readonly DbAppContext _Context;
    public PresentacionRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public override async Task<IEnumerable<Presentacion>> GetAllAsync()
    {
        return await _Context.Set<Presentacion>()
                                    .Include(u => u.Medicamentos)
                                    .ToListAsync();
    }

}
