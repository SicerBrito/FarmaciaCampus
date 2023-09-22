using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class TipoDireccionRepository : GenericRepository<TipoDireccion>, ITipoDireccion
{
    private readonly DbAppContext _Context;
    public TipoDireccionRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
