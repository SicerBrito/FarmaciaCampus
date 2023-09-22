using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class CiudadRepository : GenericRepository<Ciudad>, ICiudad
{
    private readonly DbAppContext _Context;
    public CiudadRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
