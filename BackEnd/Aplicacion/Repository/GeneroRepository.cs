using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class GeneroRepository : GenericRepository<Genero>, IGenero
{
    private readonly DbAppContext _Context;
    public GeneroRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }

    public override async Task<IEnumerable<Genero>> GetAllAsync()
    {
        return await _Context.Set<Genero>()
                                    .Include(u => u.Pacientes)
                                    .ToListAsync();
    }

}
