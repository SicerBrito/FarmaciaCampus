using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class TipoViaRepository : GenericRepository<TipoVia>, ITipoVia
{
    private readonly DbAppContext _Context;
    public TipoViaRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
