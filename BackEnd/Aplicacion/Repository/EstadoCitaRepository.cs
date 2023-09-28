using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class EstadoCitaRepository : GenericRepository<EstadoCita>, IEstadoCita
{
    private readonly DbAppContext _Context;
    public EstadoCitaRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public override async Task<IEnumerable<EstadoCita>> GetAllAsync()
    {
        return await _Context.Set<EstadoCita>()
                                    .Include(u => u.Citas)
                                    .ToListAsync();
    }
}
