using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class MetodoDePagoRepository : GenericRepository<MetodoDePago>, IMetodoDePago
{
    private readonly DbAppContext _Context;
    public MetodoDePagoRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public override async Task<IEnumerable<MetodoDePago>> GetAllAsync()
    {
        return await _Context.Set<MetodoDePago>()
                                    .Include(u => u.Compras)
                                    .Include(u => u.Ventas)
                                    .ToListAsync();
    }

}