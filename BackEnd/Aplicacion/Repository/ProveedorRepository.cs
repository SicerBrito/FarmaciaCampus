using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class ProveedorRepository : GenericRepository<Proveedor>, IProveedor
{
    private readonly DbAppContext _Context;
    public ProveedorRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
