using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class DireccionRepository : GenericRepository<Direccion>, IDireccion
{
    private readonly DbAppContext _Context;
    public DireccionRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
