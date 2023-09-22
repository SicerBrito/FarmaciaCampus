using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class PresentacionRepository : GenericRepository<Presentacion>, IPresentacion
{
    private readonly DbAppContext _Context;
    public PresentacionRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
