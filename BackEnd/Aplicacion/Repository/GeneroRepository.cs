using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class GeneroRepository : GenericRepository<Genero>, IGenero
{
    private readonly DbAppContext _Context;
    public GeneroRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
