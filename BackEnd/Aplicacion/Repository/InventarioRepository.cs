using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository;
public class InventarioRepository : GenericRepository<Inventario>, IInventario
{    
    private readonly DbAppContext _Context;
    public InventarioRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
}
