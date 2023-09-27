using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class FarmaciaRepository : GenericRepository<Farmacia>, IFarmacia
{
    private readonly DbAppContext _Context;
    public FarmaciaRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public override async Task<IEnumerable<Farmacia>> GetAllAsync()
        {
            return await _Context.Set<Farmacia>()
                                .Include(p => p.Empleados)
                                .ToListAsync();
        }
}
